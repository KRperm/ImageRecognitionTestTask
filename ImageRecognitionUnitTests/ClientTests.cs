using ImageRecognitionTestTask.Client;
using ImageRecognitionTestTask.Lifetime;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ImageRecognitionUnitTests
{
    [TestFixture]
    public class ClientTests
    {
        public const int Port = 2100;
        public const string ClientName = "Тест";

        private AppClient _testTarget;
        private TcpListener _mockServer;
        private CancellationTokenSource _serverTokenSource;
        private CancellationTokenSource _clientTokenSource;

        [SetUp]
        public void SetUp()
        {
            _mockServer = new TcpListener(IPAddress.Any, Port);
            _mockServer.Start();
            var endPoint = new IPEndPoint(IPAddress.Loopback, Port);
            _testTarget = new AppClient(endPoint, ClientName, Encoding.UTF8);

            _serverTokenSource = new CancellationTokenSource();
            _serverTokenSource.CancelAfter(10000);
            _clientTokenSource = new CancellationTokenSource();
            _clientTokenSource.CancelAfter(10000);
        }

        [Test]
        public async Task CanChangeState()
        {
            var states = new List<LifetimeObjectBase.Status>();
            _testTarget.StatusChanged += OnStatusChanged;
            var clientTask = _testTarget.RunLifetimeAsync(_clientTokenSource.Token);
            using var connection = await _mockServer.AcceptTcpClientAsync(_serverTokenSource.Token);
            _clientTokenSource.CancelAfter(1000);
            await clientTask;
            _testTarget.StatusChanged -= OnStatusChanged;

            Assert.That(states, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(states[0], Is.EqualTo(LifetimeObjectBase.Status.StartingUp));
                Assert.That(states[1], Is.EqualTo(LifetimeObjectBase.Status.Running));
                Assert.That(states[2], Is.EqualTo(LifetimeObjectBase.Status.Finished));
            });

            void OnStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
            {
                states.Add(e.NewStatus);
            }
        }

        [TestCase("Тест")]
        public async Task CanRecieveResponse(string testMessage)
        {
            string recievedMessage = null;

            _testTarget.MessageRecieved += OnMessageRecieved;
            var clientTask = _testTarget.RunLifetimeAsync(_clientTokenSource.Token);
            using var connection = await _mockServer.AcceptTcpClientAsync(_serverTokenSource.Token);

            var nameBuffer = new byte[connection.ReceiveBufferSize];
            var nameReadSize = await connection.GetStream().ReadAsync(nameBuffer, _serverTokenSource.Token);
            var recievedName = Encoding.UTF8.GetString(nameBuffer, 0, nameReadSize);
            Assert.That(recievedName, Is.EqualTo(ClientName));

            var buffer = Encoding.UTF8.GetBytes(testMessage);
            await connection.GetStream().WriteAsync(buffer, _serverTokenSource.Token);
            _clientTokenSource.CancelAfter(1000);
            await clientTask;
            _testTarget.MessageRecieved -= OnMessageRecieved;

            Assert.That(recievedMessage, Is.EqualTo(testMessage));

            void OnMessageRecieved(object sender, ServerMessageRecievedEventArgs e)
            {
                recievedMessage = e.Message;
            }
        }

        [Test]
        public async Task SuddenServerDisconnect()
        {
            Exception exception = null;

            _testTarget.StatusChanged += OnStatusChanged;
            var clientTask = _testTarget.RunLifetimeAsync(_clientTokenSource.Token);
            using var connection = await _mockServer.AcceptTcpClientAsync(_serverTokenSource.Token);

            _ = Task.Delay(2000).ContinueWith(_ => connection.Close());
            await clientTask;
            _testTarget.StatusChanged -= OnStatusChanged;

            Assert.That(exception, Is.InstanceOf<IOException>());
            Assert.That(exception.InnerException, Is.InstanceOf<SocketException>());

            void OnStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
            {
                exception = e.Exception;
            }
        }

        [TearDown]
        public void TearDown()
        {
            _serverTokenSource.Cancel();
            _serverTokenSource.Dispose();
            _clientTokenSource.Cancel();
            _clientTokenSource.Dispose();
            _mockServer.Stop();
            _mockServer.Dispose();
            _testTarget.Dispose();
        }
    }
}

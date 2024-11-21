using ImageRecognitionTestTask.Lifetime;
using ImageRecognitionTestTask.Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ImageRecognitionUnitTests
{
    [TestFixture]
    public class ServerTests
    {
        public const int Port = 2100;
        private AppServer _testTarget;
        private CancellationTokenSource _serverTokenSource;
        private CancellationTokenSource _clientTokenSource;

        [SetUp]
        public void SetUp()
        {
            var endPoint = new IPEndPoint(IPAddress.Any, Port);
            _testTarget = new AppServer(endPoint, Encoding.UTF8);
            _serverTokenSource = new CancellationTokenSource();
            _clientTokenSource = new CancellationTokenSource();
            _serverTokenSource.CancelAfter(10000);
            _clientTokenSource.CancelAfter(10000);
        }

        [Test]
        public async Task CanChangeState()
        {
            var states = new List<LifetimeObjectBase.Status>();

            _testTarget.StatusChanged += OnStatusChanged;
            _serverTokenSource.CancelAfter(2000);
            await _testTarget.RunLifetimeAsync(_serverTokenSource.Token);
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
        public async Task CanSessionRecieveMessage(string clientMessage)
        {
            string clientRecievedMessage = null;

            _testTarget.ClientMessageRecieved += OnClientMessageRecieved;
            var serverTask = _testTarget.RunLifetimeAsync(_serverTokenSource.Token);
            using var mockClient = new TcpClient();
            await MockClientSendMessage(mockClient, clientMessage);
            _serverTokenSource.CancelAfter(2000);
            await serverTask;
            _testTarget.ClientMessageRecieved -= OnClientMessageRecieved;

            Assert.That(clientRecievedMessage, Is.EqualTo(clientMessage));

            void OnClientMessageRecieved(object sender, ClientMessageRecievedEventArgs e)
            {
                clientRecievedMessage = e.Message;
            }
        }

        [TestCase("TestImage.jpg")]
        public async Task CanSessionRecieveImage(string clientMessage)
        {
            string recievedPath = null;

            _testTarget.ClientImagePathRecieved += OnClientImagePathRecieved;
            var serverTask = _testTarget.RunLifetimeAsync(_serverTokenSource.Token);
            using var mockClient = new TcpClient();
            await MockClientSendMessage(mockClient, clientMessage);
            _serverTokenSource.CancelAfter(2000);
            await serverTask;
            _testTarget.ClientImagePathRecieved -= OnClientImagePathRecieved;

            Assert.That(recievedPath, Is.EqualTo(clientMessage));

            void OnClientImagePathRecieved(object sender, ImagePathRecievedEventArgs e)
            {
                recievedPath = e.Path;
            }
        }

        private async Task MockClientSendMessage(TcpClient mockClient, string message)
        {
            var endPoint = new IPEndPoint(IPAddress.Loopback, Port);
            await mockClient.ConnectAsync(endPoint, _clientTokenSource.Token);
            await mockClient.GetStream().WriteAsync(new byte[1], _clientTokenSource.Token); // Сервер ждёт имя. Отправляем что-нибудь
            var buffer = Encoding.UTF8.GetBytes(message);
            await mockClient.GetStream().WriteAsync(buffer, _clientTokenSource.Token);
        }

        [TearDown]
        public void TearDown()
        {
            _serverTokenSource.Cancel();
            _serverTokenSource.Dispose();
            _clientTokenSource.Cancel();
            _clientTokenSource.Dispose();
            _testTarget?.Dispose();
        }
    }
}

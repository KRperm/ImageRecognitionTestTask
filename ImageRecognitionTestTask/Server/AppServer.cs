using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using ImageRecognitionTestTask.Lifetime;

namespace ImageRecognitionTestTask.Server
{
    public partial class AppServer : LifetimeObjectBase
    {
        public event EventHandler<LifetimeObjectStatusChangedEventArgs> SessionStatusChanged;
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;

        private TcpListener _listener;
        private readonly IPEndPoint _endPoint;
        private readonly Encoding _encoding;

        public AppServer(IPEndPoint endPoint, Encoding encoding)
        {
            _encoding = encoding;
            _endPoint = endPoint;
        }

        protected override Task Start(CancellationToken token)
        {
            _listener = new TcpListener(_endPoint);
            _listener.Start();
            return Task.CompletedTask;
        }

        protected override async Task<bool> Run(CancellationToken token)
        {
            var client = await _listener.AcceptTcpClientAsync(token).ConfigureAwait(false);

            var session = new Session(client, _encoding);
            session.StatusChanged += OnSessionStatusChanged;
            session.ClientMessageRecieved += OnClientMessageRecieved;
            _ = session.RunLifetime(token).ContinueWith(_ =>
            {
                session.StatusChanged -= OnSessionStatusChanged;
                session.ClientMessageRecieved -= OnClientMessageRecieved;
            }, CancellationToken.None);
            return true;
        }

        protected override void End()
        {
            _listener?.Stop();
            _listener?.Dispose();
        }

        private void OnClientMessageRecieved(object sender, ClientMessageRecievedEventArgs e)
        {
            ClientMessageRecieved?.Invoke(sender, e);
        }

        private void OnSessionStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
        {
            SessionStatusChanged?.Invoke(sender, e);
        }
    }
}

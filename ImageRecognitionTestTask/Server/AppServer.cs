using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using HalconDotNet;

namespace ImageRecognitionTestTask.Server
{
    public partial class AppServer : IDisposable
    {
        public event EventHandler<ServerStatusChangedEventArgs> StatusChanged;
        public event EventHandler<SessionStatusChangedEventArgs> SessionStatusChanged;
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        private TcpListener _listener;

        public async Task RunServerLifecycleAsync(IPEndPoint endPoint, CancellationToken token)
        {
            if (_listener is not null)
            {
                return;
            }

            Exception exception = null;
            try
            {
                _listener = new TcpListener(endPoint);
                _listener.Start();
                var connectedArgs = new ServerStatusChangedEventArgs(true);
                StatusChanged?.Invoke(this, connectedArgs);
                while (!token.IsCancellationRequested)
                {
                    var client = await _listener.AcceptTcpClientAsync(token).ConfigureAwait(false);

                    var session = new Session(client, Encoding);
                    session.StatusChanged += OnSessionStatusChanged;
                    session.ClientMessageRecieved += OnSessionClientMessageRecieved;
                    _ = session.RunSessionLifecycleAsync(token).ContinueWith(_ =>
                    {
                        session.StatusChanged -= OnSessionStatusChanged;
                        session.ClientMessageRecieved -= OnSessionClientMessageRecieved;
                    }, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                // disconnect
                _listener?.Stop();
                _listener?.Dispose();
                _listener = null;
                var disconnectedArgs = new ServerStatusChangedEventArgs(false, exception);
                StatusChanged?.Invoke(this, disconnectedArgs);
            }
        }

        private void OnSessionClientMessageRecieved(object sender, ClientMessageRecievedEventArgs e)
        {
            ClientMessageRecieved?.Invoke(sender, e);
        }

        private void OnSessionStatusChanged(object sender, SessionStatusChangedEventArgs e)
        {
            SessionStatusChanged?.Invoke(sender, e);
        }

        public void Dispose()
        {
            _listener?.Stop();
            _listener?.Dispose();
            _listener = null;
        }
    }
}

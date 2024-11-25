﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using ImageRecognitionTestTask.Lifetime;

namespace ImageRecognitionTestTask.Server
{
    /// <summary>
    /// Сервер данного приложения.
    /// Всегда ожидает новые подключения.
    /// При новом подключении создаёт новую сессию.
    /// </summary>
    public partial class AppServer : LifetimeObjectBase
    {
        /// <summary>
        /// Состояние одной из сессий поменялось.
        /// </summary>
        public event EventHandler<LifetimeObjectStatusChangedEventArgs> SessionStatusChanged;
        /// <summary>
        /// От определённого клиента пришло сообщение
        /// </summary>
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;
        /// <summary>
        /// От определённого клиента пришёл путь к валидной картинке
        /// </summary>
        public event EventHandler<ImagePathRecievedEventArgs> ClientImagePathRecieved;

        private TcpListener _listener;
        private readonly IPEndPoint _endPoint;
        private readonly Encoding _encoding;

        public AppServer(IPEndPoint endPoint, Encoding encoding)
        {
            _encoding = encoding;
            _endPoint = endPoint;
        }

        protected override Task StartAsync(CancellationToken token)
        {
            _listener = new TcpListener(_endPoint);
            _listener.Start();
            return Task.CompletedTask;
        }

        protected override async Task<bool> RunAsync(CancellationToken token)
        {
            var client = await _listener.AcceptTcpClientAsync(token).ConfigureAwait(false);

            var session = new Session(client, _encoding);
            session.StatusChanged += OnSessionStatusChanged;
            session.ClientMessageRecieved += OnClientMessageRecieved;
            session.ImagePathRecieved += OnClientImagePathRecieved;
            _ = session.RunLifetimeAsync(token).ContinueWith(_ =>
            {
                session.StatusChanged -= OnSessionStatusChanged;
                session.ClientMessageRecieved -= OnClientMessageRecieved;
                session.ImagePathRecieved -= OnClientImagePathRecieved;
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

        private void OnClientImagePathRecieved(object sender, ImagePathRecievedEventArgs e)
        {
            ClientImagePathRecieved?.Invoke(sender, e);
        }
    }
}

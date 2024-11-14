using System;
using System.Net.Sockets;

namespace ImageRecognitionTestTask.Server
{
    public class Session
    {
        public Guid Id { get; init; }
        public string ClientName { get; init; }
        public TcpClient Client { get; init; }
    }
}
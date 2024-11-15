using DevExpress.Xpo;
using System;

namespace ImageRecognitionTestTask.Server
{
    public class SessionMessageRecievedEventArgs(Guid sessionId, string clientName, string message, string response) : EventArgs
    {
        public Guid SessionId { get; init; } = sessionId;
        public string ClientName { get; init; } = clientName;
        public string Message { get; init; } = message;
        public string Response { get; init; } = response;
    }
}

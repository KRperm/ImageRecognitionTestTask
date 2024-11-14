using System;

namespace ImageRecognitionTestTask.Server
{
    public class SessionStatusChangedEventArgs(Guid sessionId, string clientName, bool isConnected, Exception exception = null) : EventArgs
    {
        public Guid SessionId { get; init; } = sessionId;
        public string ClientName { get; init; } = clientName;
        public bool IsConnected { get; init; } = isConnected;
        public Exception Exception { get; init; } = exception;
    }
}
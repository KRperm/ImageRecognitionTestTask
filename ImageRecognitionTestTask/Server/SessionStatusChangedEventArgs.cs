using System;

namespace ImageRecognitionTestTask.Server
{
    public class SessionStatusChangedEventArgs(bool isConnected, Exception exception = null) : EventArgs
    {
        public bool IsConnected { get; init; } = isConnected;
        public Exception Exception { get; init; } = exception;
    }
}
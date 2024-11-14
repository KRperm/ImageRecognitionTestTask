using System;

namespace ImageRecognitionTestTask.Server
{
    public class ServerStatusChangedEventArgs(bool isRunning, Exception exception = null) : EventArgs
    {
        public bool IsRunning { get; init; } = isRunning;
        public Exception Exception { get; init; } = exception;
    }
}
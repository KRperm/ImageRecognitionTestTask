using System;

namespace ImageRecognitionTestTask.Client
{
    public class ClientStatusChangedEventArgs(AppClient.Status newStatus, Exception exception = null) : EventArgs
    {
        public AppClient.Status NewStatus { get; init; } = newStatus;
        public Exception Exception { get; init; } = exception;
    }
}

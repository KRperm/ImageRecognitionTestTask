using System;

namespace ImageRecognitionTestTask.Lifetime
{
    public class LifetimeObjectStatusChangedEventArgs(LifetimeObjectBase.Status newStatus, Exception exception) : EventArgs
    {
        public LifetimeObjectBase.Status NewStatus { get; private init; } = newStatus;
        public Exception Exception { get; private init; } = exception;
    }
}
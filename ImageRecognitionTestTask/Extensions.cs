using System;

namespace ImageRecognitionTestTask
{
    public static class Extensions
    {
        public static bool IsNotIntended(this Exception exception)
        {
            return exception is not null && exception is not OperationCanceledException;
        }
    }
}

using System;
using System.IO;

namespace ImageRecognitionTestTask
{
    public static class Extensions
    {
        public static bool IsNotIntended(this Exception exception)
        {
            return exception is not null && exception is not OperationCanceledException;
        }

        public static string TryGetIOExceptionMessage(this Exception exception)
        {
            return exception is IOException 
                ? exception.InnerException.Message 
                : exception.Message;
        }
    }
}

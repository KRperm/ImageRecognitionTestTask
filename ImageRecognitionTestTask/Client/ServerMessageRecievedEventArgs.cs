using System;

namespace ImageRecognitionTestTask.Client
{
    public class ServerMessageRecievedEventArgs(string message) : EventArgs
    {
        public string Message { get; init; } = message;
    }
}

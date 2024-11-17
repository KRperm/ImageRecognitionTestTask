using System;

namespace ImageRecognitionTestTask.Server
{
    public class ClientMessageRecievedEventArgs(string message, string response) : EventArgs
    {
        public string Message { get; init; } = message;
        public string Response { get; init; } = response;
    }
}

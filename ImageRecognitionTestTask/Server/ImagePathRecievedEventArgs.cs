using System;

namespace ImageRecognitionTestTask.Server
{
    public class ImagePathRecievedEventArgs(string path, int objectCount) : EventArgs
    {
        public string Path { get; init; } = path;
        public int ObjectCount { get; init; } = objectCount;
    }
}
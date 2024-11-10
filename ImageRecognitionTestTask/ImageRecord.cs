using Microsoft.EntityFrameworkCore;
using System;

namespace ImageRecognitionTestTask
{
    [PrimaryKey(nameof(Id))]
    public class ImageRecord
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public int ObjectCount { get; set; }
    }
}

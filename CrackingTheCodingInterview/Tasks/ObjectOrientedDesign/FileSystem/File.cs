using System;

namespace Tasks.ObjectOrientedDesign.FileSystem
{
    public class File: FileSystemElement
    {
        public File(string name, string extension, int size)
        {
            if(size < 0 ) throw new ArgumentOutOfRangeException();
            Name = name;
            Extension = extension;
            Size = size;
        }

        public int Size { get; set; }
        public string Extension { get; set; }
    }
}
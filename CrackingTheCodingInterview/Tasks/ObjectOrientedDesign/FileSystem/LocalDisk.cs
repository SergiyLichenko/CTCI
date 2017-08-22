using System.Collections.Generic;

namespace Tasks.ObjectOrientedDesign.FileSystem
{
    public class LocalDisk: Directory
    {
        public LocalDisk(string name, ICollection<File> files,
            ICollection<Directory> directories):base(name, files, directories)
        {
            
        }
    }
}
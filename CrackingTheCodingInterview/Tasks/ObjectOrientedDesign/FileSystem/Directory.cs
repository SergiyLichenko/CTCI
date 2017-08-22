using System;
using System.Collections.Generic;

namespace Tasks.ObjectOrientedDesign.FileSystem
{
    public class Directory: FileSystemElement
    {
        public Directory(string name, ICollection<File> files,
            ICollection<Directory> directories)
        {
            if(files == null || directories == null)
                throw new ArgumentNullException();
            Name = name;
            Files = files;
            Directories = directories;
        }
        public ICollection<File> Files { get; private set; }
        public ICollection<Directory> Directories { get; private set; }
        public IEnumerable<FileSystemElement> FindByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            foreach (var item in Files)
            {
                if (item.Name.Contains(name))
                    yield return item;
            }
            foreach (var item in Directories)
            {
                if (item.Name.Contains(name))
                    yield return item;
                foreach (var res in item.FindByName(name))
                    yield return res;
            }
        }
    }
}
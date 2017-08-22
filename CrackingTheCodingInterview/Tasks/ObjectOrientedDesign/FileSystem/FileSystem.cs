using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.FileSystem
{
    public class FileSystem
    {
        public FileSystem(IEnumerable<LocalDisk> localDisks)
        {
            LocalDisks = localDisks ?? throw new ArgumentNullException();
        }

        public IEnumerable<LocalDisk> LocalDisks { get; private set; }

        public IEnumerable<FileSystemElement> FindByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            foreach (var item in LocalDisks)
            {
                foreach (var res in item.FindByName(name))
                    yield return res;
            }
        }
    }

    public class LocalDisk: Directory
    {
        public LocalDisk(string name, ICollection<File> files,
            ICollection<Directory> directories):base(name, files, directories)
        {
            
        }
    }

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

    public abstract class FileSystemElement
    {
        public string Name { get; protected set; }
    }
}

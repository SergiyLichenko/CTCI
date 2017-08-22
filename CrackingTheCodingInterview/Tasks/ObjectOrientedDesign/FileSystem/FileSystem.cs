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
}

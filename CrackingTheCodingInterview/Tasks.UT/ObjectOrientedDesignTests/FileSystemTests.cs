using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.FileSystem;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class FileSystemTests
    {
        [Fact]
        public void FileSystem_Should_Create_FileSystem()
        {
            //arrange
            var disks = new List<LocalDisk>();

            //act
            var result = new FileSystem(disks);

            //assert
            result.LocalDisks.ShouldBeEquivalentTo(disks);
        }

        [Fact]
        public void FileSystem_Should_Create_LocalDisk()
        {
            //arrange
            var files = new List<File>();
            var directories = new List<Directory>();
            var name = string.Empty;

            //act
            var disk = new LocalDisk(name, files, directories);

            //assert
            disk.Files.ShouldBeEquivalentTo(files);
            disk.Directories.ShouldBeEquivalentTo(directories);
            disk.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void FileSystem_Should_Create_Directory()
        {
            //arrange
            var files = new List<File>();
            var directories = new List<Directory>();
            var name = string.Empty;

            //act
            var directory = new Directory(name, files, directories);

            //assert
            directory.Files.ShouldBeEquivalentTo(files);
            directory.Directories.ShouldBeEquivalentTo(directories);
            directory.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void FileSystem_Should_Create_File()
        {
            //arrange
            string name = string.Empty;
            string extension = string.Empty;
            int size = 1;

            //act
            var file = new File(name, extension, size);

            //assert
            file.Extension.ShouldBeEquivalentTo(extension);
            file.Name.ShouldBeEquivalentTo(name);
            file.Size.ShouldBeEquivalentTo(size);
        }

        [Fact]
        public void FileSystem_Should_Throw_Create_File_If_Not_In_Range()
        {
            //arrange
            string name = string.Empty;
            string extension = string.Empty;
            int size = -1;

            //act
            Action act = () => new File(name, extension, size);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void FileSystem_Should_Throw_Create_Directory_If_Null()
        {
            //arrange
            string name = string.Empty;
            ICollection<File> files = new List<File>();
            ICollection<Directory> directories = new List<Directory>();

            //act
            Action actFirst = () => new Directory(name, null, directories);
            Action actSecond = () => new Directory(name, files, null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FileSystem_Should_Throw_Create_LocalDisk_If_Null()
        {
            //arrange
            string name = string.Empty;
            ICollection<File> files = new List<File>();
            ICollection<Directory> directories = new List<Directory>();

            //act
            Action actFirst = () => new LocalDisk(name, null, directories);
            Action actSecond = () => new LocalDisk(name, files, null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FileSystem_Should_Throw_Create_FileSystem_If_Null()
        {
            //arrange

            //act
            Action act = () => new FileSystem(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void FileSystem_Should_Throw_LocalDisk_Find_By_Name_If_Null()
        {
            //arrange
            var localDisk = new LocalDisk(string.Empty, new List<File>(), new List<Directory>());

            //act
            Action act = () => localDisk.FindByName(null).ToArray();

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FileSystem_Should_Throw_Directory_Find_By_Name_If_Null()
        {
            //arrange
            var directory = new Directory(string.Empty, new List<File>(), new List<Directory>());

            //act
            Action act = () => directory.FindByName(null).ToArray();

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FileSystem_Should_Throw_FileSystem_Find_By_Name_If_Null()
        {
            //arrange
            var fileSystem = new FileSystem(new List<LocalDisk>());

            //act
            Action act = () => fileSystem.FindByName(null).ToArray();

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FileSystem_Should_Check_My_File_System()
        {
            //arrange
            var notePadFile = new File("notepad", ".exe", 241);
            var windowsSubDirectories = new List<Directory>()
            {
                new Directory("addins", new List<File>(), new List<Directory>())
            };
            var diskCDirectories = new List<Directory>()
            {
                new Directory("Intel", new List<File>(), new List<Directory>()),
                new Directory("Windows",  new List<File>() {notePadFile}, windowsSubDirectories)
            };
            var diskC = new LocalDisk("C", new List<File>(), diskCDirectories);

            var googleDriveFiles = new List<File>()
            {
                new File("CV, Sergiy Lichenko", "docx", 21200),
                new File("CV, Sergiy Lichenko", "pdf", 184000),
                new File("VladimirDorokhov_CV.doc", "doc", 18000)
            };
            var diskDDirectories = new List<Directory>()
            {
                new Directory("GoogleDrive", googleDriveFiles, new List<Directory>())
            };
            var diskD = new LocalDisk("D", new List<File>(), diskDDirectories);

            //act
            var fileSystem = new FileSystem(new List<LocalDisk>() { diskC, diskD });

            //assert
            fileSystem.LocalDisks.Count().ShouldBeEquivalentTo(2);
            fileSystem.LocalDisks.ElementAt(1).ShouldBeEquivalentTo(diskD);
            fileSystem.LocalDisks.ElementAt(0).ShouldBeEquivalentTo(diskC);

            fileSystem.LocalDisks.ElementAt(1).Directories.ShouldBeEquivalentTo(diskDDirectories);
            fileSystem.LocalDisks.ElementAt(1).Directories.ElementAt(0).Files.ShouldBeEquivalentTo(googleDriveFiles);
            fileSystem.LocalDisks.ElementAt(1).Directories.ElementAt(0).Directories.Count.ShouldBeEquivalentTo(0);

            fileSystem.LocalDisks.ElementAt(0).Directories.ShouldBeEquivalentTo(diskCDirectories);
            fileSystem.LocalDisks.ElementAt(0).Files.Count.ShouldBeEquivalentTo(0);
            fileSystem.LocalDisks.ElementAt(0).Directories.ElementAt(0).Directories.Count.ShouldBeEquivalentTo(0);
            fileSystem.LocalDisks.ElementAt(0).Directories.ElementAt(0).Files.Count.ShouldBeEquivalentTo(0);

            fileSystem.LocalDisks.ElementAt(0).Directories.ElementAt(1).Directories.ShouldBeEquivalentTo(windowsSubDirectories);
            fileSystem.LocalDisks.ElementAt(0).Directories.ElementAt(1).Files.ElementAt(0).ShouldBeEquivalentTo(notePadFile);
            fileSystem.LocalDisks.ElementAt(0).Directories.ElementAt(1).Files.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void FileSystem_Should_Find_By_Name_File()
        {
            //arrange
            var notePadFileName = "notepad";
            var notePadFile = new File(notePadFileName, ".exe", 241);
            var windowsSubDirectories = new List<Directory>()
            {
                new Directory("addins", new List<File>(), new List<Directory>())
            };
            var diskCDirectories = new List<Directory>()
            {
                new Directory("Intel", new List<File>(), new List<Directory>()),
                new Directory("Windows",  new List<File>() {notePadFile}, windowsSubDirectories)
            };
            var diskC = new LocalDisk("C", new List<File>(), diskCDirectories);

            var googleDriveFiles = new List<File>()
            {
                new File("CV, Sergiy Lichenko", "docx", 21200),
                new File("CV, Sergiy Lichenko", "pdf", 184000),
                new File("VladimirDorokhov_CV.doc", "doc", 18000)
            };
            var diskDDirectories = new List<Directory>()
            {
                new Directory("GoogleDrive", googleDriveFiles, new List<Directory>())
            };
            var diskD = new LocalDisk("D", new List<File>(), diskDDirectories);
            var fileSystem = new FileSystem(new List<LocalDisk>() { diskC, diskD });

            //act
            var result = fileSystem.FindByName(notePadFileName).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(notePadFile);
        }

        [Fact]
        public void FileSystem_Should_Find_By_Name_Directory()
        {
            //arrange
            var notePadFileName = "notepad";
            var notePadFile = new File(notePadFileName, ".exe", 241);
            var windowsSubDirectories = new List<Directory>()
            {
                new Directory("addins", new List<File>(), new List<Directory>())
            };
            var diskCDirectories = new List<Directory>()
            {
                new Directory("Intel", new List<File>(), new List<Directory>()),
                new Directory("Windows",  new List<File>() {notePadFile}, windowsSubDirectories)
            };
            var diskC = new LocalDisk("C", new List<File>(), diskCDirectories);

            var googleDriveFiles = new List<File>()
            {
                new File("CV, Sergiy Lichenko", "docx", 21200),
                new File("CV, Sergiy Lichenko", "pdf", 184000),
                new File("VladimirDorokhov_CV.doc", "doc", 18000)
            };
            var diskDDirectories = new List<Directory>()
            {
                new Directory("GoogleDrive", googleDriveFiles, new List<Directory>())
            };
            var diskD = new LocalDisk("D", new List<File>(), diskDDirectories);
            var fileSystem = new FileSystem(new List<LocalDisk>() { diskC, diskD });

            //act
            var result = fileSystem.FindByName("Windows").ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(diskCDirectories[1]);
        }

        [Fact]
        public void FileSystem_Should_Find_By_Name_DirectoryAndFile_Multiple()
        {
            //arrange
            var notePadFileName = "notepad";
            var notePadFile = new File(notePadFileName, ".exe", 241);
            var windowsSubDirectories = new List<Directory>()
            {
                new Directory("addins", new List<File>(), new List<Directory>())
            };
            var diskCDirectories = new List<Directory>()
            {
                new Directory("Intel", new List<File>(), new List<Directory>()),
                new Directory("notepad",  new List<File>() {notePadFile}, windowsSubDirectories)
            };
            var diskC = new LocalDisk("C", new List<File>(), diskCDirectories);

            var googleDriveFiles = new List<File>()
            {
                new File("CV, Sergiy Lichenko", "docx", 21200),
                new File("CV, Sergiy Lichenko", "pdf", 184000),
                new File("VladimirDorokhov_CV.doc", "doc", 18000)
            };
            var diskDDirectories = new List<Directory>()
            {
                new Directory("GoogleDrive", googleDriveFiles, new List<Directory>())
            };
            var diskD = new LocalDisk("D", new List<File>(), diskDDirectories);
            var fileSystem = new FileSystem(new List<LocalDisk>() { diskC, diskD });

            //act
            var result = fileSystem.FindByName("notepad").ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(2);
            result[0].ShouldBeEquivalentTo(diskCDirectories[1]);
            result[1].ShouldBeEquivalentTo(notePadFile);
        }
    }
}

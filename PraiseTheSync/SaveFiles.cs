using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseTheSync
{
    class SaveFiles
    {
        private List<string> _paths;
        private string _backupLoc;

        public SaveFiles(List<string> paths, string backupLoc)
        {
            _paths = paths;
            _backupLoc = backupLoc;
        }

        public void Save()
        {
            string bkUpFolderName = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
            string bkUpFolderNameSanitised = bkUpFolderName.Replace('/', '-').Replace(':', '-');

            DirectoryInfo dirInfo = Directory.CreateDirectory(_backupLoc + '\\' +  bkUpFolderNameSanitised);

            foreach (var value in _paths)
            {
                DirectoryInfo sourcePath = new DirectoryInfo(value);
                CopyFilesRecursively(sourcePath, dirInfo);
                Console.WriteLine($"Successfully backed up {sourcePath} to {dirInfo}.");
            }

            Console.WriteLine($"All done. Backed up {_paths.Count} folders.");
        }


        static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            var newDirectoryInfo = target.CreateSubdirectory(source.Name);
            foreach (var fileInfo in source.GetFiles())
                fileInfo.CopyTo(Path.Combine(newDirectoryInfo.FullName, fileInfo.Name));

            foreach (var childDirectoryInfo in source.GetDirectories())
                CopyFilesRecursively(childDirectoryInfo, newDirectoryInfo);
        }
    }
}

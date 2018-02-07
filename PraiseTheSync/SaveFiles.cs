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
            Console.WriteLine(_backupLoc + bkUpFolderNameSanitised);
            foreach (var value in _paths)
            {
                Console.WriteLine(value);
            }
        }
    }
}

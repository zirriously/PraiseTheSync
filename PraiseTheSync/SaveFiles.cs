using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseTheSync
{
    class SaveFiles
    {
        private List<string> _paths;
        private string _backupLoc = String.Empty;

        public SaveFiles(List<string> paths, string backupLoc)
        {
            _paths = paths;
            _backupLoc = backupLoc;
        }
    }
}

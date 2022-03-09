using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSync.Models
{
    public class FileModel
    {
        public string File { get; set; }
        public int Code { get; set; }   // 0: Same, 1: New & 2: Delete
        public string ModifiedDate { get; set; }
    }
}

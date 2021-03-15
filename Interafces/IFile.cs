using System;
using System.Collections.Generic;
using System.Text;

namespace TransposeTool.Interafces {
    public interface IFile {
        public string Path { get; set; }
        public Enums.fileType FileType { get; set; }
        }
    }

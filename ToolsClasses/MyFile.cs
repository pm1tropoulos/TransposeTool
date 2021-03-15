using System;
using System.Collections.Generic;
using System.Text;
using TransposeTool.Enums;

namespace TransposeTool.Interafces {
    public class MyFile : IFile {

        fileType _type;
        string _path = string.Empty;
        string _delimitter = string.Empty;

        public fileType FileType{
            get {
                return _type;
                }
            set {

                }
            }

        
        public string Path{
            get {
                return _path;
                }
            set { 
                }
            }

        public string Delimitter {
            get {
                return _delimitter;
                }
            }
     

        public MyFile(fileType type, string path, string delimitter) {
            _type = type;
            _path = path;
            _delimitter = delimitter;
            }
        }
    }

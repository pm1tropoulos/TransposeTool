using System;
using System.Collections.Generic;
using System.Text;
using TransposeTool.Interafces;
using TransposeTool.Tools;

namespace TransposeTool.ToolsClasses {
    class ProcessFactory {
        public IFileProcess process;
        public MyFile file;

        public ProcessFactory(MyFile _file) {
            file = _file;
            }
    public IFileProcess GetProcess() {
            switch (file.FileType) {
                case Enums.fileType.csv:
                    process = new TransposeToolCsv();
                    break;
                }
            return process;
            }

        }
    }

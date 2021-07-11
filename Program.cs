using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TransposeTool.Tools;
using TransposeTool.Interafces;
using TransposeTool.ToolsClasses;

namespace TransposeTool {
    class Program {

        static void Main(string[] args) {
            //another comment
            Console.WriteLine("Please insert the csv File path...");
            string path = Console.ReadLine().ToString();
            string ext = Path.GetExtension(path).Remove(0,1);
            Enums.fileType fileType = (Enums.fileType)Enum.Parse(typeof(Enums.fileType),ext,true);
            Console.WriteLine($"I will read the .csv from the path: {path}\n");
            MyFile myFile = new MyFile(fileType, path, ";");
            ProcessFactory factory = new ProcessFactory(myFile);
            IFileProcess csvProcess = factory.GetProcess();
            csvProcess.processTranspose(myFile);
            }

        }
    }

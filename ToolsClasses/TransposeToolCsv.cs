using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransposeTool.Interafces;
using System.Linq;

namespace TransposeTool.Tools {
    public class TransposeToolCsv : IFileProcess {

        /// <summary>
        /// Concrete ReadFile for csv files
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public void processTranspose(MyFile file) {
            DataTable myDt = new DataTable {
                TableName = "TransportedCSV"
                };
            if (file.FileType == Enums.fileType.csv) {
                try {
                    using (var sr = new StreamReader(file.Path)) {
                        while (!sr.EndOfStream) {
                            //TODO: 
                            //To Be replaced with ';'
                            string[] line = sr.ReadLine().Split(file.Delimitter);
                            DataColumn column = myDt.Columns.Add();
                            foreach (string lstElement in line) {
                                myDt.Rows.Add();
                                myDt.Rows[Array.IndexOf(line, lstElement)][column] = lstElement;
                                }
                            }
                        }
                    Console.WriteLine("Parsing Fininshed ok!!!");
                    exportFile(myDt, file.Path);
                    }
                catch (Exception ex) {
                    Console.WriteLine("**************************************");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("**************************************\n");
                    }
                }
            else
                Console.WriteLine("The File Type you Choosed is not a .csv!!");
            }

        /// <summary>
        /// Exports the dataTable parameter into a specific path
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="path"></param>
        public void exportFile(DataTable tbl, string path) {
            var exportPath = path.Insert(path.LastIndexOf(".csv"), "_transposed");
            Console.WriteLine($"Export started .... \n");
            StringBuilder sb = new StringBuilder();
            try {
                foreach (DataRow row in tbl.Rows) {
                    if (!row.ItemArray.All(r => r is DBNull)) {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(';', fields));
                        }
                    }
                }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                }
            
            File.WriteAllText(exportPath, sb.ToString());
            Console.WriteLine($"File is placed at: {exportPath}");
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadTextFileCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = null;
            string prevFileName = "";

            try
            {
                string newFileName = @"C:\Users\Shahzad.Hasan\Desktop\Output\AllLogsJPG1_new.txt";

                // Check if file already exists. If yes, delete it.     
                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                }

                Console.Write("Processing...");

                // Returns an enumerable collection of file names that match a search pattern in a specified path.
                var txtFiles = Directory.EnumerateFiles(@"C:\Users\Shahzad.Hasan\Desktop\Logs", "*.txt");
                foreach (string currentFile in txtFiles)
                {

                    //if (prevFileName != currentFile)
                    //{
                    //    using (sw = File.AppendText(newFileName))
                    //    {
                    //        sw.WriteLine("");
                    //        sw.WriteLine("---------------------------------------------------------------------------------");
                    //        sw.WriteLine("File Name: {0}", currentFile);
                    //        sw.WriteLine("---------------------------------------------------------------------------------");
                    //        sw.WriteLine("");
                    //    }
                    //}

                    // Read a text file using StreamReader
                    using (StreamReader sr = new StreamReader(currentFile))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(".jpg"))
                            {
                                var temp = line.Replace("Page		: ", "Images/").Replace(": Saveed in IMAGES folder on AWS successfully.", "");
                                temp = "Insert into [ImageQueuePath] Values ('" + temp + "')";
                                // Create a new file     
                                using (sw = File.AppendText(newFileName))
                                {
                                    //sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                                    sw.WriteLine(temp);
                                }

                                //File.WriteAllText(newFileName, line);
                            }
                        }
                    }
                    prevFileName = currentFile;
                }



                //string fileName = @"C:\Mahesh\McTextFile.txt";                

                Console.WriteLine("StreamReader Done");
                Console.WriteLine("========================");

                // Read using File.OpenText
                //if (System.IO.File.Exists(fileName))
                //{
                //    using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
                //    {
                //        String input;
                //        while ((input = sr.ReadLine()) != null)
                //        {
                //            Console.WriteLine(input);
                //        }
                //        Console.WriteLine("END.");
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("File not found");
                //}

                //Console.WriteLine("File.Opentext Done - Neel wrote it");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                throw;
            }
            //try
            //{
            //    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, true))
            //    {
            //        writer.Write("Write some text here");
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.WriteLine(exp.Message);
            //}
        }

    }
}

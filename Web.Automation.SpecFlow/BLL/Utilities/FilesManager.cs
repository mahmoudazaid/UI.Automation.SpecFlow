using System;
using System.IO;

namespace BLL.Utilities
{
    public class FilesManager
    {
        public static string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

        public static bool FileDownloaded(string filename)
        {
            bool exist = false;
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }

        public static void DeleteFile(string filename)
        {
            string[] files = Directory.GetFiles(Path);

            File.Delete(filename);
            Console.WriteLine($"{filename} is deleted.");
        }
    }
}

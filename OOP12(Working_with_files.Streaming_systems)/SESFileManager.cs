using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.WebRequestMethods;

namespace OOP12_Working_with_files.Streaming_systems_
{
    public static class SESFileManager
    {
        public static void GetInfoDisk(string disk)
        {
            string DiskInfo= "\n-----------------------   SESFileManager   -----------------------\n";
            DriveInfo drivers = new DriveInfo(disk);
            string[] files=Directory.GetFiles(disk);
            string[] dirs= Directory.GetDirectories(disk);
            DiskInfo = "\nПапки:\n";
            foreach (string dir in dirs)
            {
                DiskInfo += dir + "\n";
            }
            DiskInfo += "\nФайлы\n";
            foreach(string file in files)
            {
                DiskInfo += file + "\n";
            }
            DirectoryInfo inspect= new DirectoryInfo("SESInspect");
            if (!inspect.Exists)
            {
                inspect.Create();
                DiskInfo += "\nДиректорий создан";
            }
            FileInfo inspectFile=new FileInfo(inspect.FullName+"\\SESInspect.txt");
            StreamWriter streamInspect = inspectFile.AppendText();
            streamInspect.WriteLine(DiskInfo);
            DiskInfo += "\nФайл создан";
            streamInspect.Close();
            SESLog.WriteInLog(DiskInfo);
        }
        public static void CopyFile(string pathSource,string pattern)
        {
            string classLogInfo = "\n-----------------------   SESFileManager(Copy)   -----------------------\n";
            string CopyFileLog = "";
            DirectoryInfo SESFiles=new DirectoryInfo("SESFile");
            if (!SESFiles.Exists)
            {
                SESFiles.Create();
            }
            string[] files=Directory.GetFiles(pathSource,pattern);
            foreach (string file in files)
            {
                try
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(SESFiles.FullName, fileName);
                    if (System.IO.File.Exists(destFile))
                    {
                        System.IO.File.Delete(destFile);
                    }
                    System.IO.File.Copy(file, destFile, true);
                    CopyFileLog = classLogInfo + "\nФайл скопирован";
                }
                catch(Exception e)
                {
                    CopyFileLog = classLogInfo + "\nОшибка копирования файла: " + e.Message;
                }
            }
            try
            {
                if (Directory.Exists(Path.Combine("SESInspect", Path.GetFileName("SESFiles"))))
                {
                    Directory.Delete(Path.Combine("SESInspect", Path.GetFileName("SESFiles")), true);
                }
                Directory.Move("SESFile", Path.Combine("SESInspect", Path.GetFileName("SESFiles")));
                CopyFileLog = classLogInfo + "\nФайлы перемещены";
            }
            catch(Exception e)
            {
                CopyFileLog = classLogInfo + "\nОшибка перемещения файлов: " + e.Message;
            }
            SESLog.WriteInLog(CopyFileLog);
        }
        public static void archive(string path)
        {
            ZipFile.CreateFromDirectory(path, "D:\\");
        }
    }
}

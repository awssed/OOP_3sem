using OOP12_Working_with_files.Streaming_systems_;
using System;
using System.IO;

namespace OOP12
{
    public class Programm
    {
        static void Main(string[] args)
        {
            SESDiskInfo.GetDiskInfo();
            SESFileInfo.GetFileInfo("D:\\MFST.h");
            SESDirInfo.GetDirInfo("D:\\Учёба");
            SESFileManager.GetInfoDisk("D:\\");
            SESFileManager.CopyFile("D:\\", "*.txt");
            SESLog.Count();
            SESLog.FindLogInfo("GPAFileManager");
            SESLog.FindLogInfoDay(new DateTime(2023, 10, 30));
            SESLog.FindLogInfoTime(new DateTime(2023, 10, 30, 9, 9, 29), new DateTime(2023, 10, 30, 15, 18, 38));
        }
    }
}   
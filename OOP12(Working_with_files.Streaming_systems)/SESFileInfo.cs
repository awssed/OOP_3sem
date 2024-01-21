using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP12_Working_with_files.Streaming_systems_
{
    public static class SESFileInfo
    {
        public static void GetFileInfo(string NameFile)
        {
            if(NameFile is null)
            {
                throw new ArgumentNullException(nameof(NameFile));
            }
            FileInfo fileInfo= new FileInfo(NameFile);
            if(!fileInfo.Exists)
            {
                throw new FileNotFoundException(NameFile);
            }
            string Info= "\n-----------------------   SESFileInfo   -----------------------\n"+
                              "\nПолный путь:              " + fileInfo.DirectoryName +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;
            Console.WriteLine(Info);
            SESLog.WriteInLog(Info);
        }
    }
}

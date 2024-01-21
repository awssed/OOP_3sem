using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace OOP12_Working_with_files.Streaming_systems_
{
    public static class SESDirInfo
    {
        public static void GetDirInfo(string pathDir)
        {
            if (pathDir is null)
            {
                throw new ArgumentNullException(nameof(pathDir));
            }
            DirectoryInfo direct=new DirectoryInfo(pathDir);
            if(!direct.Exists)
            {
                throw new DirectoryNotFoundException(pathDir);
            }
            string directInfo= "\n-----------------------   SESFileInfo   -----------------------\n"+
                                 "\nИмя директории:           " + direct.Name +
                                 "\nКоличество файлов:        " + direct.GetFiles().Length +
                                 "\nВремя создания:           " + direct.LastWriteTime +
                                 "\nКол-во поддиректориев:    " + direct.GetDirectories().Length +
                                 "\nРодительский директорий:  " + direct.Parent.Name;
            Console.WriteLine(directInfo);
            SESLog.WriteInLog(directInfo);
        }
    }
}

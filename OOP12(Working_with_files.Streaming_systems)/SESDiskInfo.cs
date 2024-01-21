using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP12_Working_with_files.Streaming_systems_
{
    public static class SESDiskInfo
    {
       public static void GetDiskInfo()
        {
            string classLogInfo = "\n-----------------------   SESDiskInfo   -----------------------\n";
            string DiskInfo="";
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                DiskInfo+=("\nИмя диска:                " + drives[0].Name +//имя диска
                       "\nФайловая система:         " + drives[0].DriveFormat +//имя файловой системы
                       "\nДоступное место:          " + drives[0].AvailableFreeSpace +//свободное место на диске
                       "\nРазмер диска:             " + drives[0].TotalSize +//размер диска
                       "\nМетка тома диска:         " + drives[0].VolumeLabel + "\n");
                Console.WriteLine(("\nИмя диска:                " + drives[0].Name +//имя диска
                       "\nФайловая система:         " + drives[0].DriveFormat +//имя файловой системы
                       "\nДоступное место:          " + drives[0].AvailableFreeSpace +//свободное место на диске
                       "\nРазмер диска:             " + drives[0].TotalSize +//размер диска
                       "\nМетка тома диска:         " + drives[0].VolumeLabel + "\n"));
            }
            SESLog.WriteInLog(classLogInfo + DiskInfo);
        }
    }
}

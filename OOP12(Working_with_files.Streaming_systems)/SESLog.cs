using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP12_Working_with_files.Streaming_systems_
{
    public static class SESLog
    {
        public static void WriteLogInfo()               /// запись в файл лога инфы о работе самого логгера
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("\n===========================================   SESLog   ===================================================\n");
                sw.WriteLine("Имя файла лога:           " + Path.GetFileName(logPath));
                sw.WriteLine("Полный путь лога:         " + logPath);
                sw.WriteLine("Время записи лога:        " + DateTime.Now);
            }
        }
        public static void WriteInLog(string message)   /// запись в файл лога инфы из остальных классов
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                sw.WriteLine(message+DateTime.Now);
        }
        public static string ReadLog()
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            StreamReader sr = new StreamReader(logPath);
            return sr.ReadToEnd();
        }
        public static void FindLogInfo(string keyWord)
        {
            string logPath = Path.GetFullPath("Seslog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] keyWordArray = keyWord.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                for (int j = 0; j < keyWordArray.Length; j++)
                {
                    if (logInfoArray[i].Contains(keyWordArray[j]))
                    {
                        logInfoArray2[count] = logInfoArray[i];
                        count++;
                    }
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        public static void FindLogInfoDay(DateTime date)
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        public static void FindLogInfoTime(DateTime date1, DateTime date2)
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date1.ToString()) && logInfoArray[i].Contains(date2.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        public static void Count()
        {
            string logInfo = ReadLog();
            string check = "===========================================   SESLog   ===================================================";
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;
            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(check))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }
            Console.WriteLine("Количесво записей:       " + count);
        }
        public static void DeleteLogInfo()
        {
            string logPath = Path.GetFullPath(@"Seslog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;
            DateTime date = DateTime.Now;
            date.AddHours(-1);
            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }
            string logInfo2 = "";
            for (int i = 0; i < count; i++)
                logInfo2 += logInfoArray2[i] + "\n";
            File.WriteAllText(logPath, logInfo2);
        }

    }
}

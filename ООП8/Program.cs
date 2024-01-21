using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ООП8.Programmer;
using static ООП8.StringProcessing;

namespace ООП8
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Programmer> group1 = new List<Programmer>();
            DeleteHandler deleteHandler = (programmer) =>
            {
                Console.WriteLine($"Событиt удаление :удаление элемента списка со значение {programmer.Value}");
                group1.Remove(programmer);
            };
            MutantHandler mutantHandler = () =>
            {
                Console.WriteLine("Событие мутация: случайное пермещение элементов");
                Random random = new Random();
                for (int i = 0; i < group1.Count; i++)
                {
                    int index1 = random.Next(group1.Count);
                    int index2 = random.Next(group1.Count);

                    Programmer temp = group1[index1];
                    group1[index1] = group1[index2];
                    group1[index2] = temp;
                }
            };
            for (int i = 0; i < 10; i++)
            {
                Programmer programmer = new Programmer(i);
                programmer.delete += deleteHandler;
                programmer.mutant += mutantHandler;
                group1.Add(programmer);
                group1[i].Display();
            }
            group1[2].Delete();
            foreach (var programmer in group1)
            {
                programmer.Display();
            }
            group1[2].Mutant();
            foreach (var programmer in group1)
            {
                programmer.Display();
            }
            //task with standart delegates
            string inputString = "Example string, for    processing algorithm";
            Func<string,string> stringProcessingAlgorithm = RemovePunctuation;

            stringProcessingAlgorithm += RemovePunctuation;
            inputString = stringProcessingAlgorithm.Invoke(inputString);
            stringProcessingAlgorithm += AddSuffix; 
            inputString = stringProcessingAlgorithm.Invoke(inputString);
            stringProcessingAlgorithm += ConvertToUpperCase;
            inputString = stringProcessingAlgorithm.Invoke(inputString);
            stringProcessingAlgorithm += RemoveExtraSpaces;
            inputString = stringProcessingAlgorithm.Invoke(inputString);
            Console.WriteLine(inputString);
        }
    }
}

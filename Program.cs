using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Sermone
{
    class Program
    {
        static void Main(string[] args)
        {
            int selIDX = 0; // selected dictionary index
            string path = AppDomain.CurrentDomain.BaseDirectory;

            List<Dictionary> dictionaries = new List<Dictionary>();
            
            if (Directory.Exists(path + "dict"))
            {
                foreach(string dictPath in Directory.GetFiles(path + "dict"))
                {
                    List<string> original = new List<string>();
                    List<string> translated = new List<string>();


                    using (StreamReader sr = new StreamReader(dictPath))
                    {
                        int count = 0;
                        count++;
                        while (true)
                        {
                            string temp = sr.ReadLine();
                            if (temp == null)
                            {
                                dictionaries.Add(new Dictionary(count, original, translated, dictPath));
                                break;
                            }
                            string[] tempArr = temp.Split(':'); // we get the original word and its translation
                            original.Add(tempArr[0]);
                            translated.Add(tempArr[1]);
                            count++;                    
                        }
                    }
                }
            }
            int dictIDXtemp = 0;
            foreach(Dictionary dict in dictionaries)
            {
                Console.WriteLine(dictIDXtemp + " - " + dict.getName);
                dictIDXtemp++;
            }
            Console.WriteLine("Введите номер словаря:");
            selIDX = Int32.Parse(Console.ReadLine());
            if (selIDX >= dictionaries.Count) Console.WriteLine("Несуществующий номер словаря!");
            else
            {
                Dictionary dict = dictionaries[selIDX];
                List<string> localWordsOriginal = new List < string > (dict.getAllWordsOriginal);
                List<string> localWordsTranslated = new List<string>(dict.getAllWordsTranslated);
                /*while (true)
                {
                    Random random = new Random();
                    
                    int rndWordIDX = random.Next(localWordsOriginal.Count);
                    string tempOriginalWord = localWordsOriginal[rndWordIDX];

                    Console.WriteLine(localWordsTranslated[rndWordIDX]);
                    Console.WriteLine(Console.ReadLine() == tempOriginalWord);
                    Console.WriteLine("================================================");

                }*/
                while (localWordsOriginal.Count > 0)
                {
                    Random random = new Random();

                    int rndWordIDX = random.Next(localWordsOriginal.Count);
                    string tempOriginalWord = localWordsOriginal[rndWordIDX];

                    Console.WriteLine(localWordsTranslated[rndWordIDX]);
                    Console.WriteLine(Console.ReadLine() == tempOriginalWord);
                    Console.WriteLine("================================================");
                    localWordsOriginal.RemoveAt(rndWordIDX);
                    localWordsTranslated.RemoveAt(rndWordIDX);
                }
            }
            Console.ReadLine();
        }
    }
}

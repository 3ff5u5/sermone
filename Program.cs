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
            const int MAX_DICT_SIZE = 100; // maximum words in dictionary
            int selIDX = 0; // selected dictionary index
            string path = AppDomain.CurrentDomain.BaseDirectory;

            List<Dictionary> dictionaries = new List<Dictionary>();
            
            if (Directory.Exists(path + "dict"))
            {
                foreach(string dictPath in Directory.GetFiles(path + "dict"))
                {
                    string[] original = new string[MAX_DICT_SIZE];
                    string[] translated = new string[MAX_DICT_SIZE];

                    
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
                            original[count] = tempArr[0];
                            translated[count] = tempArr[1];
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
                while (true)
                {
                    Random random = new Random();
                    Dictionary dict = dictionaries[selIDX];
                    int rndWordIDX = random.Next(0, dict.wordsCount);
                    string tempOriginalWord = dict.getWordOriginal(rndWordIDX);

                    Console.WriteLine(dict.getWordTranslated(rndWordIDX));
                    Console.WriteLine(Console.ReadLine() == tempOriginalWord);
                    Console.WriteLine("================================================");

                }
            }
            Console.ReadLine();
        }
    }
}

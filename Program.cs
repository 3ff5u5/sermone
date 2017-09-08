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
            const int MAX_DICT_SIZE = 100;
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
                                dictionaries.Add(new Dictionary(count, original, translated));
                                break;
                            }
                            string[] tempArr = temp.Split(':');
                            original[count] = tempArr[0];
                            translated[count] = tempArr[1];
                            count++;                    
                        }
                    }
                }
            }
            //demo
            while(true)
            {
                Random random = new Random();
                Dictionary dict = dictionaries[0];
                int rndWordIDX = random.Next(0, dict.wordsCount);
                string tempOriginalWord = dict.getWordOriginal(rndWordIDX);

                Console.WriteLine(dict.getWordTranslated(rndWordIDX));
                Console.WriteLine(Console.ReadLine() == tempOriginalWord);
                Console.WriteLine("================================================");

            }
            //
            Console.ReadLine();
        }
    }
}

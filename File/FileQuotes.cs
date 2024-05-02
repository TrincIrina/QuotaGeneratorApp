using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotaGeneratorApp.File
{
    // Класс для работы с файлом, содержащим цитаты
    internal class FileQuotes
    {
        // Путь к файлу
        private readonly string path = "Короткие позитивные цитаты.txt";     
        // Текст цитаты
        public string Quote { get; set; }
        // Автор цитаты
        public string Author { get; set; }
        // Конструктор
        public FileQuotes()
        {
            Quote = string.Empty;
            Author = string.Empty;
        }
        // Метод выделения цитаты
        public void RandomQuote(Random r)
        {
            List<string> list = new List<string>();
            using(StreamReader sr = new StreamReader(path))
            {                
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }
            string[] quotes = new string[list.Count];
            for (int i = 0; i < quotes.Length; i++)
            {
                quotes[i] = list[i];
            }
            string str = quotes[r.Next(quotes.Length)];
            Quote = str.Split(':')[0];
            Author = str.Split(':')[1];
        }
        public override string ToString()
        {
            return $"{Quote} - {Author}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace find_content
{
    internal class content
    {
        private string title;
        private string isbn;
        private string bookContent;
        private List<string> words;
        Dictionary<string, int> wordcount = new Dictionary<string, int>();
        private int numOfWords;
        private double sumTF_IDF=0; //đây là tổng chỉ số IF của các từ trong xâu chứa các từ cần tìm 

        public content(string title, string isbn, string bookContent) 
        {
            this.bookContent = bookContent;
            bookContent=bookContent.ToLower();
            this.title = title;
            this.isbn = isbn;
            this.words = bookContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = Regex.Replace(words[i], "[^a-zA-Z-]", "");
            }
            numOfWords =words.Count; 
        }

        public void countWord()
        {
            foreach (string word in words)
            {
                if (wordcount.ContainsKey(word))
                {
                    // Tăng số lượng nếu từ đã tồn tại trong từ điển
                    wordcount[word]++;
                }
                else
                {
                    // Thêm từ mới vào từ điển nếu chưa tồn tại
                    wordcount[word] = 1;
                }
            }
            // Xóa các từ bị lặp từ danh sách
            words = wordcount.Keys.ToList();

        }

        public void displayTF()
        {
            foreach (var TF in wordcount)
            {
                Console.WriteLine($"word: {TF.Key}, TF: {TF.Value}");
            }
        }

        public bool checkExist(string word)
        {
            bool check = false;
            foreach(string temp in words)
            {
                if(temp==word)
                { check = true; break; }
            }
            return check;
        }

        public double getTF(string word)
        {
            double TF = 0;
            if(checkExist(word))
            {
                foreach(var temp in wordcount)
                {
                    if(temp.Key==word)
                    { TF= (double)temp.Value; }
                }
            }
            return TF;
        }

        public double getSumTF_IDF()
        {
            return sumTF_IDF;
        }

        public void addSumTF_IDF(double TF)
        {
            sumTF_IDF += TF;
        }

        public void setSumTF_IDF()
        {
            sumTF_IDF = 0;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string BookContent
        {
            get { return bookContent; }
            set { bookContent = value; }
        }
        public string getTitle()
        {
            return title;
        }

        public string getISBN()
        {
            return isbn;
        }

        public void printContent(string[] redWords, string isbn)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("-------------= CONTENT =-----------");
            string file = "D:\\Library_data\\BookContent\\" + isbn + ".txt";
            string information = File.ReadAllText(file);
            information = information.ToLower();
            string[] wordsPrint;
            wordsPrint = information.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) ;
            foreach(string word in wordsPrint)
            {
                if (redWords.Contains(Regex.Replace(word, "[^a-zA-Z-]", "")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{word} ");
                    Console.ResetColor();
                } 
                else
                {
                    Console.Write($"{word} ");
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("-------------=---------=-----------");
            Console.WriteLine();
        }
    }
}


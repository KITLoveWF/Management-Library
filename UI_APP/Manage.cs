using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using find_content;


namespace UI_APP
{
    internal class Manage
    {
        List<Book> books = new List<Book>();
        List<History> historys = new List<History>();
        List<Account> accounts = new List<Account>();
        FindContent findcontent = new FindContent();
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
        public List<History> Historys
        {
            set { historys = value; }
            get { return historys; }
        }
        public List <Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        public void ReadDataContent()
        {
            findcontent.readfile("D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\InforBook.csv");
        }
        public List<content> FindBookContent(string conTent)
        {
            findcontent.resetDataFindContent();
            List<content> contents = new List<content>();
            findcontent.setInput(conTent);
            findcontent.caculateIDF();
            contents = findcontent.caculateTF_IDF();
            contents = contents.OrderByDescending(temp => temp.getSumTF_IDF()).ToList();
            return contents;
        }
        public void ReadHistory(string fileHistory)
        {
            try
            {
                string[] file = File.ReadAllLines(fileHistory);
                for (int i = 1; i < file.Length; i++)
                {

                    string[] s = file[i].Split(',');
                    History history = new History(s[0], s[1], s[2], s[3], s[4], s[5]);
                    historys.Add(history);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReadFile1(string file1)
        {
            try
            {
                string[] file = File.ReadAllLines(file1);
                for (int i = 0; i < file.Length; i++)
                {

                    string[] s = file[i].Split(',');
                    Book newBook = new Book(s[0], s[1], s[2], s[3], int.Parse(s[4]));
                    newBook.Content = File.ReadAllText($"D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\all\\{s[3]}.txt");
                    books.Add(newBook);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReadFile2(string file2)
        {
            try
            {
                string[] file = File.ReadAllLines(file2);
                for (int i = 1; i < file.Length; i++)
                {
                    //Console.WriteLine(file[i]);
                    string[] s = file[i].Split(',');
                    Account newAccount = new Account(s[0], s[1], s[2], s[3], s[4]);
                    accounts.Add(newAccount);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public List<Book> FindBookCategory(string category)
        {
            List<Book> booksTempt = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Category.ToLower() == category.ToLower())
                {
                    booksTempt.Add(books[i]);
                }
            }
            if (booksTempt.Count > 0) return booksTempt;
            else return null;
        }
        public List<Book> FindBookTitle(string title)
        {
            List<Book> booksTempt = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == title.ToLower())
                {
                    booksTempt.Add(books[i]);
                }
            }
            if (booksTempt.Count > 0) return booksTempt;
            else return null;
        }
        public List<Book> FindBookAuthor(string author)
        {
            List<Book> booksTempt = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.ToLower() == author.ToLower())
                {
                    booksTempt.Add(books[i]);
                }
            }
            if (booksTempt.Count > 0) return booksTempt;
            else return null;
        }
        public List<Book> FindBookIsbn(string isbn)
        {
            List<Book> booksTempt = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Isbn.ToLower() == isbn.ToLower())
                {
                    booksTempt.Add(books[i]);
                }
            }
            if (booksTempt.Count > 0) return booksTempt;
            else return null;
        }
        public Book FindBookIsbnOne(string isbn)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Isbn.ToLower() == isbn.ToLower())
                {
                    return books[i];
                }
            }
            return null;
        }
    }
}

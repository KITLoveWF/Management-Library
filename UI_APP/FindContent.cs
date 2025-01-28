using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using find_content;

internal class FindContent
{
    private string content;
    private string[] stopWords = {
    "a", "an", "and", "are", "as", "at", "be", "but", "by", "for",
    "if", "in", "into", "is", "it", "no", "not", "of", "on", "or",
    "such", "that", "the", "their", "then", "there", "these", "they",
    "this", "to", "was", "will", "with","about", "above", "after", "all", "also", "an", "any", "as", "ask",
    "back", "be", "because", "been", "but", "by", "can", "could",
    "do", "even", "every", "first", "from", "get", "give", "go",
    "have", "her", "here", "him", "his", "how", "i", "if", "in",
    "into", "it", "its", "just", "know", "like", "look", "make", "me",
    "most", "my", "new", "no", "not", "now", "of", "on", "only", "or",
    "other", "our", "out", "over", "people", "say", "see", "she", "so",
    "some", "take", "than", "that", "the", "their", "them", "then",
    "there", "these", "they", "think", "this", "time", "up", "use",
    "very", "want", "way", "we", "well", "what", "when", "which",
    "who", "will", "with", "work", "would", "year", "you", "your"," "
    };
    private string input;
    string[] wordsInInput;
    private List<content> contents= new List<content> ();
    Dictionary<string, double> IDF = new Dictionary<string, double> ();
    private List<content> bookfinded = new List<content> ();
    int countWordsInInput;

    public FindContent() { }
    public void setInput(string input)
    {
        this.input = input;
        countWordsInInput = 0;
        //chuẩn hóa lại input
        input = input.Trim();  // bỏ bớt dấu space thừa 2 đầu
        input = input.ToLower(); // chuyển hết thành chữ thường
        wordsInInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        input = string.Join(" ", wordsInInput.Where(word => !stopWords.Contains(word)));
        //Console.WriteLine(input);
        wordsInInput = input.Split(' ');
        for (int i = 0; i < wordsInInput.Length; i++)
        {
            wordsInInput[i] = Regex.Replace(wordsInInput[i], "[^a-zA-Z-]", "");
            countWordsInInput++;
        }

    }


    public void readfile(string file)
    {
        string file2;
        string[] read = new string[200];
        try
        {
            // Read all content from the file
            read = File.ReadAllLines(file);
        }
        catch (Exception ex)
        {
            // Handle exception if there is an issue reading the file
            Console.WriteLine("Error reading the file: " + ex.Message);
        }
        foreach(string line in read)
        {
            string[] infor = new string[40];
            infor = line.Split(',');
            if (infor.Length >= 4)
            {
                file2 = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\all\\" + infor[3] + ".txt";
                //Console.WriteLine(file2);
                string information = File.ReadAllText(file2);
                content newContent = new content(infor[1], infor[3], information);
                newContent.countWord();
                contents.Add(newContent);
            }
        }

        //foreach(content temp in contents)
        //{
        //    temp.displayTF();
        //}
    }

    public void caculateIDF()
    {
        foreach(string word in wordsInInput)
        {
            int i = 0;
            foreach (content temp in contents)
            {
                //temp.displayTF();
                if (temp.checkExist(word)) i++;
            }
            IDF[word] =Math.Log((double) contents.Count/(i+1));
        }
        //foreach(var temp in IDF)
        //{
        //    Console.WriteLine($"word: {temp.Key}, IDF: {temp.Value.ToString("0.###")}");
        //}
    }

    public List<content> caculateTF_IDF()       
    {
        if (wordsInInput[0] != "" && wordsInInput.Length >= 1)
        {
            foreach (content temp in contents)
            {
                foreach (var word in IDF)
                {
                    temp.addSumTF_IDF((double)temp.getTF(word.Key) * word.Value);
                    //if (temp.checkExist(word.Key))
                    //{
                    //    Console.WriteLine($"TF: {temp.getTF(word.Key)},IDF: {word.Value} ");
                    //    Console.WriteLine($"book: {temp.getTitle()}, TF_IDF: {temp.getSumTF_IDF()}");
                    //}
                }
                if (temp.getSumTF_IDF() != 0)
                {
                    string file = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\all\\" + temp.getISBN() + ".txt";
                    string information = File.ReadAllText(file);
                    content newcontent = new content(temp.getTitle(), temp.getISBN(), information);
                    newcontent.addSumTF_IDF(temp.getSumTF_IDF());
                    bookfinded.Add(newcontent);
                }
                //temp.setSumTF_IDF();
            }
            bookfinded = bookfinded.OrderByDescending(temp => temp.getSumTF_IDF()).ToList();
            //if (bookfinded.Count() > 0)
            //{
            //    if (bookfinded.Count() < 10)
            //    {
            //        foreach (content temp in bookfinded)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.WriteLine("-------------=  BOOK  =-----------");
            //            Console.ResetColor();
            //            Console.WriteLine($"book: {temp.getTitle()}, {temp.getISBN()}, TF_IDF: {temp.getSumTF_IDF()}");
            //            temp.printContent(wordsInInput, temp.getISBN());

            //        }
            //    }
            //    else
            //    {
            //        int i = 0;
            //        foreach (content temp in bookfinded)
            //        {
            //            i++;
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.WriteLine("-------------=  BOOK  =-----------");
            //            Console.ResetColor();
            //            Console.WriteLine($"book: {temp.getTitle()}, {temp.getISBN()}, TF_IDF: {temp.getSumTF_IDF()}");
            //            temp.printContent(wordsInInput, temp.getISBN());
            //            if (i == 10) break;
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("book that you want to find is not exist");
            //}
        }
        else return null;
        return bookfinded;
    }

    public void resetDataFindContent()
    {
        // reset lại data 
        // chuyển list chứa sách tìm được về rỗng
        // chuyển các giá trị lưu TF,IDF về rỗng
        IDF.Clear();
        foreach (content temp in contents)
        {
            temp.setSumTF_IDF();
        }
        bookfinded.Clear();
    }

    

}


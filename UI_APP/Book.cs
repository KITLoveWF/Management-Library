using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_APP
{
    internal class Book
    {
        private string category;
        private string title;
        private string author;
        private string isbn;
        private string content;
        private int quantityHaving;
        public Book(string CAtegory, string TItle, string AUthor, string ISbn, int QUantityHaving)
        {
            category = CAtegory;
            title = TItle;
            author = AUthor;
            isbn = ISbn;
            quantityHaving = QUantityHaving;
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Isbn
        {
            get { return isbn; }
            set
            {
                isbn = value;
            }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public int QuantityHaving
        {
            get { return quantityHaving; }
            set { quantityHaving = value; }
        }
    }
}

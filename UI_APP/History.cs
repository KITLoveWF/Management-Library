using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_APP
{
    internal class History
    {
        private string name;
        private string userName;
        private string nameBook;
        private string isbn;
        private string dateBegin;
        private string dateEnd;
        public History(string name, string userName, string nameBook, string isbn, string dateBegin, string dateEnd)
        {
            this.name = name;
            this.userName = userName;
            this.nameBook = nameBook;
            this.isbn = isbn;
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string NameBook
        {
            get { return nameBook; }
            set { nameBook = value; }
        }
        public string Isbn
        {
            get { return isbn; }
            set
            {
                isbn = value;
            }
        }
        public string DateBegin
        {
            get { return dateBegin; }
            set
            {
                dateBegin = value;
            }
        }
        public string DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
            }
        }

    }
}

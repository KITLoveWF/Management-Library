using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_APP
{
    internal class Account
    {
        private string name;
        private string birthday;
        private string gender;
        private string userName;
        private string passWord;
        public Account(string NAme, string BIrthday, string GEnder, string USerName, string PAssWord)
        {
            name = NAme;
            birthday = BIrthday;
            gender = GEnder;
            userName = USerName;
            passWord = PAssWord;
        }
        
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }

        }
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }
    }
}

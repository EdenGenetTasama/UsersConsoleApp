using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersConsoleApp
{
    class User : IComparable
    {
        string fName;
        string lName;
        int yearOfBirth;
        string email;

        public User(string _fName, string _lName, int _yearOfBirth, string _email)
        {
            this.fName = _fName;
            this.lName = _lName;
            this.yearOfBirth = _yearOfBirth;
            this.email = _email;
        }

        public string Fname
        {
            get { return this.fName; }
            set { this.fName = value; }
        }

        public string LName
        {
            get { return this.lName; }
            set { this.lName = value; }
        }

        public int YearOfBirth
        {
            get { return this.yearOfBirth; }
            set { this.yearOfBirth = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public virtual void PrintingInfo()
        {
            Console.WriteLine($"{this.Fname} {this.LName} , {this.YearOfBirth} : {this.Email}");
        }

        public int CompareTo(object obj)
        {
            User p = (User)obj;
            if (this.YearOfBirth < p.yearOfBirth) return -1;
            if (this.YearOfBirth > p.yearOfBirth) return 1;
            return 0;
        }
    }
}
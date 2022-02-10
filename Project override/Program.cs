using System;

namespace Project_override
{
    class Program
    {
        static void Main(string[] args)
        {
            Student jacob = new Student("5A", "Jacob", "Sørensen", "m", 18, 23232323);
            jacob.PrintInfo(true);
            jacob.PrintInfo();
        }
    }

    
    class Person
    {
        string firstName;
        string lastName;
        string gender;
        int age;
        long cpr;

        public Person(string firstName, string lastName, string gender, int age, long cpr)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
            this.cpr = cpr;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine(this.firstName);
            Console.WriteLine(this.lastName);
            Console.WriteLine(this.gender);
            Console.WriteLine(this.age);
            Console.WriteLine(this.cpr);
        }
        public string PrintInfo(bool fullNameOnly)
        {
            string fullName = $"{this.firstName} {this.lastName}";
            Console.WriteLine(fullName);
            return fullName;
        }
    }

    class Student : Person
    {
        string class1;
        public Student(string class1, string firstName, string lastName, string gender
            , int age, long cpr) : base(firstName, lastName, gender, age, cpr)
        {
            this.class1= class1;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(this.class1);
        }
    }

}

using System;

namespace guess_a_number
{
    class Program
    {
        static void Main(string[] args)
        {   int interval = 100;
            FindNumber findnumber = new FindNumber(interval);
            int number = findnumber.number;
            var input = 0;
            string exitkey = "p";
            while (String.Compare(exitkey, "q") == -1)
            {
                Console.WriteLine("Gæt et nummer!");
                Console.WriteLine("");
                Console.WriteLine("Indtast et nummer fra 0-99");
                input = Int32.Parse(Console.ReadLine());
                if (input != number)
                {
                    if (input > number)
                    {
                        Console.WriteLine("The number is smaller!");
                    }
                    else Console.WriteLine("the number is bigger");
                    Console.WriteLine("WRONG GUESS");
                    Console.WriteLine("PRESS Q TO QUIT LIKE A QUITTER or PRESS ANY KEY TO TRY AGAIN");
                }
                else
                {
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine("PRESS Q TO QUIT WITH GREAT HONOR or PRESS ANY KEY TO TRY AGAIN");
                    number = findnumber.updateNumber();
                }
                exitkey = Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class FindNumber
    {   Random rnd = new Random();
        public int number;
        int interval;
        public FindNumber(int interval)
        {
            this.interval = interval;
        number = rnd.Next(interval);

        }
        public int updateNumber()
        {
            rnd = new Random();
            number = rnd.Next(interval);
            return number;             
        }
    }
}

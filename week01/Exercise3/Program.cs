using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, where the user specified the number...
        Console.Write("What is the magic number? ");
        string responce;
        responce = Console.ReadLine();
        //int magicNumber = int.Parse(Console.ReadLine());
        int magicNumber = int.Parse(responce);
        
        //Random randomGenerator = new Random();
        //int magicNumber = randomGenerator.Next(1, 210);

        int guess = -1;

        // We could also use a do-while loop here...
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }                    
    }
}
namespace NumberGuessingGame
{
    class NumberGuessingGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is the Number Guessing Game.");
            while (true)
            {
                Console.WriteLine("Please, enter lower and upper bounds.");
                Console.WriteLine("Lower bound:");
                int lower = getInt();
                Console.WriteLine("Upper bound:");
                int upper = getInt();

                while (true)
                {
                    if (upper > lower)
                        break;
                    Console.WriteLine("Upper bound must greater than lower!");
                    upper = getInt();
                }

                int secret = new Random().Next(lower, upper + 1);
                int tryNum = (int)Math.Log2((double)(upper - lower + 1));

                bool playAgain;
                while (true)
                {
                    Console.WriteLine("You have " + tryNum + " lives");
                    Console.WriteLine("Your guess?");
                    int guess = getInt();
                    if (guess == secret)
                    {
                        Console.WriteLine("Congratulations! You guess the number!");
                        playAgain = getPlayAgain();
                        break;
                    }
                    tryNum--;
                    if (tryNum == 0)
                    {
                        Console.WriteLine("You Lost :(  The number was " + secret);
                        playAgain = getPlayAgain();
                        break;
                    }
                    if (guess > secret)
                        Console.WriteLine("Too high...");
                    else
                        Console.WriteLine("Too low...");
                }
                if (!playAgain)
                    break;
            }
            Console.WriteLine("Thanks for playing ^_^");
        }

        private static bool getPlayAgain()
        {
            Console.WriteLine("Play again? (y/n)");
            string input = Console.ReadLine();
            while (true)
            {
                input = input.ToLower();
                if (input.Equals("y"))
                    return true;
                if (input.Equals("n"))
                    return false;
                Console.WriteLine("Illegal input!");
                input = Console.ReadLine();
            }
        }

        private static int getInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Illegal input! Please, enter integer.");
                }
            }
        }
    }
}

using System;

namespace NumberGuesser
{
    class Program
    {
        // Entry Point Method
        static void Main(string[] args)
        {
            // Run Function to get app info
            GetAppInfo();

            // Asks for name and greets user
            GreetUser();
         
            // Main Game Loop, will only close if user says they don't want to play another round
            while (true)
            {
                // Create a new instance of the Random object that we can use later.
                Random random = new Random();

                // Init correct number using our random object.  This lets us set correctNumber to a random number between 1 and 100
                int correctNumber = random.Next(1, 100);

                int guess = 0;

                // Ask user for number
                Console.WriteLine($"Guess a number between 1 and 100");

                // While guess is not correct
                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    // Make sure input is a number
                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please use an actual number");                     
                        continue;
                    }

                    // Cast to int and put in guess variable
                    guess = Int32.Parse(input);
    
                    // Match guess to correct number
                    if (guess != correctNumber && guess < correctNumber)
                    {
                        // Let user know they're guess is too low
                        PrintColorMessage(ConsoleColor.Blue, "Too Low! try again!");
                    }
                    else if (guess != correctNumber && guess > correctNumber)
                    {
                        // Let user know they're guess is too high
                        PrintColorMessage(ConsoleColor.Magenta, "Too High! try again!");
                    }
                }

                // Victory Message
                PrintColorMessage(ConsoleColor.Yellow, "You are CORRECT!");

                // Ask to play again
                Console.WriteLine("Play Again? [Y or N]");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        // Methods

        // Sets app variable and Displays app info
        static void GetAppInfo()
        {
            string appName = "Number Guess";
            string appVersion = "1.0.0";
            string appAuthor = "Ryan DuPerow";
            PrintColorMessage(ConsoleColor.Green, $"{appName}: Version {appVersion} by {appAuthor}");
        }

        // Gets name from user and greets them
        static void GreetUser()
        {
            Console.WriteLine("What is your name?");
            string inputName = Console.ReadLine();
            Console.WriteLine($"Hello {inputName}, let's play a game....");
        }

        /* Prints a Message in the color that you choose
         * Change color to parameter given
         * Output message given in parameter
         * reset color
         */
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

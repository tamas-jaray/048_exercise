using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _048_exercise
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Program1();
            //Program2();
            //Program3();
            //Program4();
            Program5();

        }



        /// <summary>
        /// Program to count numbers between 1 and 100 
        /// which are divisible by 3 without remainder.
        /// </summary>
        private static void Program1()
        {
            int countOf3Divisibles = 0;
            int lowerRange = 1;
            int upperRange = 100;
            for (int i = lowerRange; i <= upperRange; i++)
            {
                if (i % 3 == 0)
                {
                    countOf3Divisibles++;
                }
            }
            Console.WriteLine("The amount of the 3 divisible numbers between {0} and {1} is: {2}", lowerRange, upperRange, countOf3Divisibles);
            Console.ReadLine();

        }



        /// <summary>
        ///A program to ask user for numbers till the user types the word "ok", 
        ///also integrated input check.
        /// </summary>
        private static void Program2()
        {
            string ExitWord = "ok";
            double numberByUser = 0;
            bool Exit = false;

            do
            {
                Console.WriteLine("Type the next number:");
                var inputByUser = Console.ReadLine();

                //Input from the user is "ok"
                if (inputByUser == ExitWord)
                {
                    Exit = true;
                    Console.WriteLine("The sum of the numbers is:" + numberByUser);
                }

                //Input from the user is different
                else
                {
                    if (int.TryParse(inputByUser, out int parseSucceed))
                    {
                        numberByUser += Convert.ToInt32(inputByUser);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again!");
                    }

                }
            } while (!Exit);

            Console.ReadLine();
        }
        
        /// <summary>
        ///A program which asks for user input,
        ///then calculates and displays the factorials.
        /// </summary>
        private static void Program3()
        {

            Console.WriteLine("Input your number for factorial:");
            var numberAsString = Console.ReadLine();

            int age;
            while (!int.TryParse(numberAsString, out age))
            {
                Console.WriteLine("This is not a number, try again!");
                numberAsString = Console.ReadLine();
            }
            int numberAsInt = Convert.ToInt32(numberAsString);
            long factorial = 1;

            for (int i = 1; i <= numberAsInt; i++)
            {
                factorial *= i;
            }
            Console.WriteLine("The factorial is: {0}! = {1}", numberAsString, factorial);
            Console.ReadLine();
        }

        public static void Program4()
        {
            Random r = new Random();

            //lowerRange and upperRange
            const int lowerRange = 1;
            const int upperRange = 10;
            const int MAXnumberOfTries = 4;

            bool UserGuessedRight = false;
            int numberFromUserAsInt = 0;
            string numberFromUserAsString;
            int currentNumberOfTries = 0;
            int[] numbersFromUser = new int[4];

            int randomNumber = r.Next(lowerRange, upperRange);


            Console.WriteLine("The random number is:" + randomNumber);
            do
            {
                Console.WriteLine("What is your guess? Please choose a number between {0} and {1}", lowerRange, upperRange);
                numberFromUserAsString = Console.ReadLine();

                var checkInput = CheckInput(numberFromUserAsString);

                while (checkInput < 1)
                {
                    if (checkInput == 0)
                    {
                        Console.WriteLine("Number out of range! Try again!");
                    }
                    else if (checkInput == -1)
                    {
                        Console.WriteLine("This is not a number! Try again");
                    }

                    numberFromUserAsString = Console.ReadLine();
                    checkInput = CheckInput(numberFromUserAsString);

                }

                numberFromUserAsInt = Convert.ToInt32(numberFromUserAsString);

                numbersFromUser[currentNumberOfTries] = numberFromUserAsInt;
                currentNumberOfTries++;

                if (randomNumber == numberFromUserAsInt)
                {
                    Console.WriteLine("You won!!!");
                    break;
                }

                else
                {
                    if (currentNumberOfTries == MAXnumberOfTries)
                    {
                        Console.WriteLine("No more tries left, sorry.");
                    }
                    else
                    {
                        Console.WriteLine("You lost, try again, {0} tries left.", MAXnumberOfTries - currentNumberOfTries);
                    }

                }


            } while (currentNumberOfTries < MAXnumberOfTries || UserGuessedRight);

            //Printing out the guesses
            Console.WriteLine("Your tries: ");

            foreach (var number in numbersFromUser)
            {
                if (number != 0)
                {
                    Console.Write(number + " ");
                }
            }

            //Waiting for user input just not to finish the program
            Console.ReadLine();
        }

        public static int CheckInput(string inputFromConsole)
        {
            int succeedingOfParse;

            if (int.TryParse(inputFromConsole, out succeedingOfParse))
            {
                int inputNumberConvertedToInt = Convert.ToInt32(inputFromConsole);
                if (inputNumberConvertedToInt >= 1 && inputNumberConvertedToInt <= 10)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            else
            {
                return -1;
            }

        }

        private static void Program5()
        {
            Console.WriteLine("Give me your numbers separated with a comma: ");

            string userInput = Console.ReadLine();

            Console.WriteLine(userInput);
            Console.ReadLine();

            int[] userInputArray = ToIntArray(userInput, ',');

            Console.WriteLine(string.Join(",", userInputArray));
            Console.ReadLine();
            Console.WriteLine("The maximum of the array is: ");
            Console.WriteLine(userInputArray.Max());
            Console.ReadLine();
        }
        private static int[] ToIntArray(this string value, char separator)
        {
            return Array.ConvertAll(value.Split(separator), s => int.Parse(s));
        }
    }
}

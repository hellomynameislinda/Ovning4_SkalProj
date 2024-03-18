using System;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            /*
             * Övning 1 - Frågor
             * 1. Se nedan.
             * 2. Kapaciteten ökar när de platser i listan som finns är fulla.
             * 3. Kapaciteten börjar på fyra och ökar exponentiellt/dubblas när behov av ny plats uppstår. Dvs 4->8->16 osv.
             * 4. 
             * 5. Kapaciteten minskar aldrig.
             * 6. Vet man i förväg exakt hur många objekt man kommer ha så kommer en array vara mer minnessnål, på grund av
             *    ovanstående, då arrayen bara tar upp den minnesplats som behövs. Men känner man inte till storleken när den
             *    initialiseras så kan man ofta behöva ta i rejält i överkant.
             */



            List<string> theList = new List<string>();
            Console.WriteLine($"Before we start the list size is  {theList.Capacity}.");
            Console.WriteLine("Start a string with + to add it to the list. E.g. '+Adam'.\n" +
                "Start a string with - to add it to the list. E.g. '-Adam'.\n" +
                "T to trim the list.\n" +
                "0 to exit.");

            do
            {

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.Write($"Added {value}. ");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.Write($"Removed {value}. ");
                        break;
                    case 'T':
                        theList.TrimExcess();
                        Console.WriteLine("The list was trimmed.");
                        break;
                    case '0':
                        Console.Clear();
                        // Exit
                        return;
                }
                Console.WriteLine($"The list size is now {theList.Capacity}.");

            } while (true);

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new Queue<string>();
            Console.WriteLine("Start a string with + to add someone to the queue. E.g. '+Adam'.\n" +
                "- to remove the first.\n" +
                "T to trim the list.\n" +
                "0 to exit.");

            Console.WriteLine($"ICA öppnar och kön till kassan är tom."); // Hej svengelska! Men det följer uppgiftern;)
            do
            {

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav) // Let's keep the same switch as above, for simplicity.
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.Write($"{value} ställer sig i kön. ");
                        break;
                    case '-':
                        // TODO: Change to TryPeek and TryDequeue respectively
                        Console.Write($"{theQueue.Peek()} blir expidierad och lämnar kön.");
                        theQueue.Dequeue();
                        break;
                    case '0':
                        Console.Clear();
                        // Exit
                        return;
                }
                Console.WriteLine($"Nu är det {theQueue.Count} personer i kön.");

            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Implementera en ReverseText-metod som läser in en sträng från användaren och med 
             * hjälp av en stack vänder ordning på teckenföljden för att sen skriva ut den omvända 
             * strängen till användaren.             
             */
            do
            {

                Stack<string> theStack = new Stack<string>();

                Console.WriteLine("Enter a string to add to the stack (or 0 to exit):");
                string inputString = Console.ReadLine(); // TODO: Check this isn't empty.

                if (inputString == "0") return; // Exit if user enters a 0, as this part does not require a menu

                foreach (char c in inputString)
                {
                    theStack.Push(c.ToString());
                }

                string outputString = string.Empty;
                foreach (string c in theStack)
                {
                    outputString += c;
                }

                Console.WriteLine($"Your string backwards is: {outputString}");

            } while (true);
        }



        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
    }

}



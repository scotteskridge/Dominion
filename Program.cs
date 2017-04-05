using System;
using Microsoft.VisualBasic; 

namespace Dominion_Project{
    public class Program{
        public static void Main(string[] args)
        {
            Console.WriteLine("Lets Start a new game of Dominion!");
            GetUserString();
        }

        public static string GetUserString(){
            while (true){

           Console.WriteLine("Enter input:"); // Prompt
            string user_input = Console.ReadLine(); // Get string from user
            if (user_input == "exit") // Check string
            {
                return user_input;
            }
            Console.Write("You typed "); // Report output
            Console.Write(user_input.Length);
            Console.WriteLine(" character(s)");
             return user_input;
            }
           
        }

    }
}

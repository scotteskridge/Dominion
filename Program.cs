using System;
using Microsoft.VisualBasic; 

namespace Dominion_Project{
    public class Program{
        public static void Main(string[] args)
        {
            Console.WriteLine("Lets Start a new game of Dominion!");
           
            Player player1 = new Player("Scott");
            Console.WriteLine("You made a player");
            System.Console.WriteLine(player1.Name);
            Player player2 = new Player("Andy");
            bool gameOn =  true;
            int switchPlayer = 1;
            while(gameOn == true){
                if(switchPlayer == 1){
                    Console.WriteLine("This is player 1 turn");
                    bool turnOn = true;
                    int switchPhase = 1;
                    while(turnOn){
                        if(switchPhase == 1){
                            Console.WriteLine("This is Action Phase");
                            switchPhase = 2;
                        }else if(switchPhase == 2){
                            Console.WriteLine("This is buy pahse");
                            switchPhase = 3;
                        }else if(switchPhase == 3){
                            Console.WriteLine("This is clean Phase");
                            turnOn = false;
                        }
                    }
                    switchPlayer = 2;
                }else if(switchPlayer == 2){
                    Console.WriteLine("This is player 2 turn");
                    bool turnOn = true;
                    int switchPhase = 1;
                    while(turnOn){
                        if(switchPhase == 1){
                            Console.WriteLine("This is Action Phase");
                            switchPhase = 2;
                        }else if(switchPhase == 2){
                            Console.WriteLine("This is buy pahse");
                            switchPhase = 3;
                        }else if(switchPhase == 3){
                            Console.WriteLine("This is clean Phase");
                            turnOn = false;
                        }
                    }
                    gameOn = false;
                }
            }
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

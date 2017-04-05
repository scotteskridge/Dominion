using System;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Dominion_Project{
    public class Program{
        public static void Main(string[] args)
        {
            Console.WriteLine("Lets Start a new game of Dominion!");
            PlayMat playMat1 = new PlayMat();

            Player player1 = new Player("Scott",playMat1);
            Console.WriteLine("You made a player1");
            System.Console.WriteLine(player1.Name);
            Player player2 = new Player("Andy",playMat1);
            Console.WriteLine("You made a player2");
            System.Console.WriteLine(player2.Name);
            bool gameOn =  true;
            int switchPlayer = 1;
            while(gameOn == true){
                if(switchPlayer == 1){
                    Console.WriteLine("This is player 1 turn");
                    bool turnOn = true;
                    int switchPhase = 1;
                    while(turnOn){
                        if(switchPhase == 1){
                            if(player1.Actions != 0){
                                Console.WriteLine("Action Phase input index of card you wanna play");
                                int userInput = Int32.Parse(GetUserString());
                                player1.Action_Phase(userInput);
                                player1.Actions -= 1;
                            }else{
                                switchPhase = 2;
                            }
                        }else if(switchPhase == 2){
                            bool buyphase = true;
                            while (buyphase){
                                foreach (var card in player1.player_hand){
                                    if(card.Type == "Treasure"){
                                        player1.Play_card(card);
                                    }
                                }
                                if(player1.Buys != 0 && player1.Buying_Power != 0){
                                    player1.DisplayState();
                                    Console.WriteLine("This is buy phase, input name of the card you want to buy, or Pass");
                                    string userInput =  GetUserString();
                                    buyphase = player1.Buy_Phase(userInput);
                                
                                }else{
                                    buyphase = false;
                                }

                            }
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
                            Console.WriteLine("This is buy phase");
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
             return user_input;
            }

        }

    }
}

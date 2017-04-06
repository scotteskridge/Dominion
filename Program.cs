using System;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Dominion_Project{
    public class Program{

        public static Player ActivePlayer;
        public static int NumberOfPlayers;
        public static List<Player> Players = new List<Player>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Lets Start a new game of Dominion!");
            PlayMat playMat1 = new PlayMat();
            NumberOfPlayers= CreatePlayers(playMat1);
            ActivePlayer = Players[0];
            bool gameOn =  true;
            while(gameOn == true){
                int playerindex =0;
                Console.WriteLine($"It is now {ActivePlayer.Name}'s Turn");
                bool turnOn = true;
                int switchPhase = 1;
                while(turnOn){
                    if(switchPhase == 1){
                        if(ActivePlayer.Actions != 0){
                            Console.WriteLine("Action Phase input index of card you wanna play");
                            int userInput = Int32.Parse(GetUserString());
                            ActivePlayer.Action_Phase(userInput);
                            ActivePlayer.Actions -= 1;
                        }else{
                            switchPhase = 2;
                        }
                    }else if(switchPhase == 2){
                        bool buyphase = true;
                        while (buyphase){
                            foreach (var card in ActivePlayer.player_hand.ToList()){
                                if(card.Type == "Treasure"){
                                    ActivePlayer.Play_card(card);
                                }
                            }
                            if(ActivePlayer.Buys != 0 && ActivePlayer.Buying_Power != 0){
                                ActivePlayer.DisplayState();
                                Console.WriteLine("This is buy phase, input name of the card you want to buy, or Pass");
                                string userInput =  GetUserString();
                                buyphase = ActivePlayer.Buy_Phase(userInput);
                            
                            }else{
                                buyphase = false;
                            }

                        }
                        switchPhase = 3;

                    }else if(switchPhase == 3){
                        Console.WriteLine("This is cleanup Phase");
                        gameOn =  ActivePlayer.CleanUp_Phase();
                       
                    }
                }
                if (playerindex < NumberOfPlayers){
                    playerindex++;
                }else {
                    playerindex = 0;
                }
                ActivePlayer = Players[playerindex];

                
            }
        }
        

        public static int CreatePlayers(PlayMat playMat){
            System.Console.WriteLine("Enter the number of players:");
            int numplayers = Int32.Parse(GetUserString());
            for (int i = 0; i < numplayers; i++){
                System.Console.WriteLine("Enter a Player Name: ");
                string playername = GetUserString();
                Player player = new Player(playername ,playMat);
                Console.WriteLine($"{player.Name} is now in the game!");
                Players.Add(player);

            }
            return numplayers;
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

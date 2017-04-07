using System;

using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Dominion_Project{
    public class Program{
       public static Player ActivePlayer;
        public static int NumberOfPlayers;
        public static List<Player> Players = new List<Player>();
        public static void Main()
        {
            Console.WriteLine("Lets Start a new game of Dominion!");
            bool gameOn = true;
            PlayMat playMat1 = new PlayMat();
            NumberOfPlayers= CreatePlayers(playMat1);
            ActivePlayer = Players[0];
            while(gameOn){
                int playerindex =0;
                Console.WriteLine($"It is now {ActivePlayer.Name}'s Turn");
                TallyScore();
                bool turnOn = true;
                int switchPhase = 1;
                while(turnOn){
                    TallyScore();
                    if(switchPhase == 1){
                        if(ActivePlayer.Actions != 0){
                            ActivePlayer.DisplayState();
                            Console.WriteLine("Enter the card number you'd like to play");
                            int userInput = Int32.Parse(GetUserString());
                            ActivePlayer.Action_Phase(userInput-1, ActivePlayer);
                            ActivePlayer.Actions -= 1;
                        }else{
                            switchPhase = 2;
                        }
                    }else if(switchPhase == 2){
                        bool buyphase = true;
                        while (buyphase){
                            foreach (var card in ActivePlayer.player_hand.ToList()){
                                if(card.Type == "Treasure"){
                                    ActivePlayer.Play_card(card, ActivePlayer);
                                } else ActivePlayer.Discard(card);
                                
                            }
                            if(ActivePlayer.Buys != 0 && ActivePlayer.Buying_Power != 0){
                                playMat1.DisplayGameState();
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
                        if (playerindex < NumberOfPlayers){
                            playerindex++;
                        }
                        if(playerindex >= NumberOfPlayers){
                            playerindex = 0;
                        }
                        ActivePlayer = Players[playerindex];
                        switchPhase = 1;                       
                       
                    }
                }
                
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
            Console.WriteLine("Enter input:"); // Prompt
            string user_input = Console.ReadLine(); // Get string from user
            return user_input;
        }
        public static int GetUserInt(){
            Console.WriteLine("Enter input:"); // Prompt
            int user_input = Int32.Parse(Console.ReadLine()); // Get string from user
            return user_input;
        }

        public static int ValidateInt(string input){
            //do some code to validate user input the problem is I want to return the string if
            //it fails the validation maybe return an object or dictionary?

            return Int32.Parse(input);
        }

        public static void TallyScore(){

            foreach (var player in Players){
                foreach (var card in player.player_hand.ToList()){
                    player.Score += card.Victory_Points;
                }
                foreach (var card in player.played_cards.ToList()){
                    player.Score += card.Victory_Points;
                }
                foreach (var card in player.player_draw_deck.cards.ToList()){
                    player.Score += card.Victory_Points;
                }
                foreach (var card in player.player_discard_deck.cards.ToList()){
                    player.Score += card.Victory_Points;
                }
                System.Console.WriteLine($"{player.Name} scored: {player.Score}");
                player.Score = 0;
            }
        }

    }
}

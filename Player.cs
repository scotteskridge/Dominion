using System.Collections.Generic;
using System;

namespace Dominion_Project{

    public class Player{
        public string Name { get; set; }

        public int Score = 0;
        public Deck player_draw_deck;
        public Deck player_discard_deck;
        public List<Card> played_cards;
        public List<Card> player_hand;
        public int Actions { get; set; }
        public int Buys { get; set; }
        public int Buying_Power { get; set; }
        public PlayMat playmat;

        public Player(string name, PlayMat mat){
            Name = name;
            playmat = mat;
            this.Actions = 1;
            this.Buys = 1;
            this.Buying_Power = 0;
            this.player_discard_deck = new Deck(); //set the discard list to empty
            player_discard_deck.cards.Clear();
            this.played_cards = new List<Card>(); //set the discard list to empty
            this.player_draw_deck = new Deck(); //Need to set this to 7 coppers and 3 estates
            this.player_hand = new List<Card>();

            for (int i = 0; i< 5; i++){
                Draw_Card();
            }
            DisplayState();
        }

        public void Action_Phase(int inputIndex, Player player){
            Card card = player_hand[inputIndex];
            Play_card(card, player);
        }
         public Card Play_card(Card card, Player player){
            played_cards.Add(card);
            player_hand.Remove(card);
            Actions += card.More_Actions;
            Buys += card.More_Buys;
            Buying_Power += card.Buying_Power;
            if (card.Draws > 0){
                for (int i = 0; i < card.Draws; i++){
                    Draw_Card();
                }
            }
            card.OnPlay(player);
            return card;
        }
        public Card Trigger_card(Card card, Player player){
            Actions += card.More_Actions;
            Buys += card.More_Buys;
            Buying_Power += card.Buying_Power;
            if (card.Draws > 0){
                for (int i = 0; i < card.Draws; i++){
                    Draw_Card();
                }
            }
            card.OnPlay(player);
            return card;
        }
        public Card ChooseCard(){
            // need validations in case of null card
            System.Console.WriteLine("Choose a card");
            DisplayPlayerHand();
            int input = Int32.Parse(Program.GetUserString());
            Card card = player_hand[input-1];
            return card;
        }
        public Card Discard(Card card){
            player_hand.Remove(card);
            player_discard_deck.cards.Add(card);
            return card;
        }
         public Card DiscardFromDeck(){
            Card card = player_draw_deck.cards[0];
            player_draw_deck.cards.RemoveAt(0);
            player_discard_deck.cards.Add(card);
            return card;
        }
        public Card Gain(Card card){ //gaining cards does not remove from piles but playmat.pickpile does
            player_discard_deck.cards.Add(card);
            return card;
        }
        public Card Trash(Card card){
            player_hand.Remove(card);
            playmat.TrashedCards.Add(card);
            return card;
        }
        public bool Buy_Phase(string userInput){
            if (userInput == "Pass"){
                return false;
            }
            bool hasbought = false;
             foreach(var pile in playmat.ThisGameCards){
                if (userInput == pile.Name){
                    Card chosen_card = playmat.PickPile(userInput);
                    if (chosen_card != null){
                        Buy_Card(chosen_card);
                        Buying_Power -= chosen_card.Cost;
                        Buys--;
                        hasbought = true;
                        return true;

                    } 

                } 
            }
            if(hasbought == false){
                System.Console.WriteLine("Please enter valid card name");
            }
                          
        return true;
        }
        public Card Buy_Card(Card purchased_card){
            Card Purchased_card = purchased_card; //this will need to be the card you bought passed in
            
            played_cards.Add(Purchased_card);
            return Purchased_card;
        }

        public bool CleanUp_Phase(){
            if (playmat.EmptyPile > 2){
                Program.TallyScore();
                return false;
            }
            for (int i = 0; i < played_cards.Count; i++){
                player_discard_deck.cards.Add(played_cards[0]);
                played_cards.RemoveAt(0);
            }
            for (int i = 0; i <5; i++){
                Draw_Card();
            }
            Buying_Power = 0;
            Actions = 1;
            Buys = 1;

            DisplayState();
            return true;
        }

        

        public Card Draw_Card(){
            if (player_draw_deck.cards.Count == 0 && player_discard_deck.cards.Count == 0 ){
            System.Console.WriteLine("You've drawn all of your cards");
            }
            else if(player_draw_deck.cards.Count == 0){
                for(int i =0; i < player_discard_deck.cards.Count; i++){
                    player_discard_deck.Shuffle();
                    player_draw_deck.cards.Add(player_discard_deck.cards[0]);
                    player_discard_deck.cards.RemoveAt(0);
                    player_draw_deck.Shuffle();
                }
            Card Drawn_card = player_draw_deck.Draw();
            player_hand.Add(Drawn_card);

            return Drawn_card;
            }else {
            Card Drawn_card = player_draw_deck.Draw();
            player_hand.Add(Drawn_card);

            return Drawn_card;

            }
            return null;
        }

        public void DisplayState(){
            System.Console.WriteLine($"it is {Name}'s turn:");
            System.Console.WriteLine($"{Name} has:");
            System.Console.WriteLine($"Actions: {Actions}");
            System.Console.WriteLine($"Buys: {Buys}");
            System.Console.WriteLine($"Buying Power: {Buying_Power}");
            System.Console.WriteLine($"Cards in Hand:");
           for(int i =0 ; i < player_hand.Count; i++){
                System.Console.WriteLine($"{i+1} : {player_hand[i].Name}");
            }
        }
        public void DisplayPlayerHand(){
            for(int i = 0; i < player_hand.Count; i++){
                System.Console.WriteLine($"{i+1} : {player_hand[i].Name}");
            }
        }

        public bool CheckForDefence(){
            foreach (var card in player_hand){
                if (card.Type == "Reaction"){
                    // ShowCard(card);
                    return true;
                }
            }
            return false;
        }
        // public Card ShowCard(Card card){
        //     card.OnShow();
        // } Need to have a method for showing your moat

    }
}

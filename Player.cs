using System.Collections.Generic;
using System;

namespace Dominion_Project{

    public class Player{
        public string Name { get; set; }
        public Deck player_draw_deck;
        public Deck player_discard_deck;
        public List<Card> played_cards;
        public List<Card> player_hand;
        public int Actions { get; set; }
        public int Buys { get; set; }
        public int Buying_Power { get; set; }

        public Player(string name){
            Name = name;
            this.Actions = 1;
            this.Buys = 1;
            this.Buying_Power = 0;
            this.player_discard_deck = new Deck(); //set the discard list to empty
            this.played_cards = new List<Card>(); //set the discard list to empty
            this.player_draw_deck = new Deck(); //Need to set this to 7 coppers and 3 estates
           
            for (int i = 0; i< 5; i++){
                Draw_Card();
            }
        }

        public void Action_Phase()
        {

        }
        public void Buy_Phase()
        {

        }
        public void CleanUp_Phase()
        {
            foreach (Card card in played_cards)
            {
                player_discard_deck.cards.Add(card);
            }
        }

        public Card Buy_Card(Card purchased_card)
        {
            Card Purchased_card = purchased_card; //this will need to be the card you bought passed in
            played_cards.Add(Purchased_card);
            return Purchased_card;
        }

        public Card Draw_Card()
        {
            Card Drawn_card = player_draw_deck.Draw();
            player_hand.Add(Drawn_card);

            return Drawn_card;

        }

        public void DisplayState(){
            System.Console.WriteLine($"it is {Name}'s turn:");
            System.Console.WriteLine($"{Name} has:");
            System.Console.WriteLine($"Actions: {Actions}");
            System.Console.WriteLine($"Buys: {Buys}");
            System.Console.WriteLine($"Buying Power: {Buying_Power}");
            System.Console.WriteLine($"Cards in Hand:");
            foreach (Card card in player_hand){
                System.Console.WriteLine(card.Name);
            }
        }

        public Card Play_card(Card card){
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
            card.OnPlay();
            DisplayState();

            return card;
        }


    }
}
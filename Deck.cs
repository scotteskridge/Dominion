using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominion_Project
{
    public class Deck{
        public List<Card> cards = new List<Card>();

        public Deck(){
            for(int i = 0; i <3; i++){
                cards.Add(new Estate());
            }
            for (int i = 0; i < 7; i ++){
                cards.Add(new Copper());
            }
            Shuffle();

        }

        public Card Draw(){
            Card drawn_card = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return drawn_card;
        }
        public void Shuffle(){
            Random rand = new Random();
           
            for (int i = cards.Count-1; i >= 0; i--){
                int j =rand.Next(0,i);
                Card tempCard = cards[i]; 
                cards[i]= cards[j];
                cards[j]= tempCard;
            }
        }
        
    }
}
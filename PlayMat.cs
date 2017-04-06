using System;
using System.Collections.Generic;
using System.Linq;
using Dominion_Project;

namespace Dominion_Project{
    public class Pile{
        public List<Card> cards = new List<Card>();
        public int Count = 0;
        public string Name;

        public Pile(Card card, int count){
            Count = count;
            Name = card.Name;
            for (int i = 0; i < count; i++){
                cards.Add(card);
            }

        }
    }
    public class PlayMat
    {
        //ok what I think i need to do is make a List of <pile> and then fill that list with new
        //piles in my constructor funtion but its after 3 and time for bed
        public int EmptyPile =0;
        public List<Card> TrashedCards = new List<Card>();
        public List<Card> ActionCards = new List<Card>();
        
        // public static Estate estate = new Estate();
        // public static Pile estates = new Pile(estate, 24);
        //make 3 piles of Victory cards
            
        
        public static Duchy duchy = new Duchy();
            public static Pile duchies = new Pile(duchy, 12);
        public static Province province = new Province();
        public static Pile provinces = new Pile(province, 12);

        public static Curse curse = new Curse();
        public static Pile curses = new Pile(curse, 30);

        //make 3 piles of Treasure cards
        public static Copper copper = new Copper();
        public static Pile coppers = new Pile(copper, 60);
        public static Silver silver = new Silver();
        public static Pile silvers = new Pile(silver, 40);
        public static Gold gold = new Gold();
        public static Pile golds = new Pile(gold, 30);

        //make 10 piles of action cards
        //in the future make a for loop to grab 10 random 
        //cards from a dictionary of all possible action cards

        //1
        public static Village village = new Village();
        public static Pile villages1 = new Pile(village, 10);
        //2
        // Village village = new Village();
        public static Pile villages2 = new Pile(village, 10);
        //3
        // Village village = new Village();
        public static Pile villages3 = new Pile(village, 10);
        //4
        // Village village = new Village();
        Pile villages4 = new Pile(village, 10);
        //5
        // Village village = new Village();
        public static Pile villages5 = new Pile(village, 10);
        //6
        // Village village = new Village();
        public static Pile villages6 = new Pile(village, 10);
        //7
        // Village village = new Village();
        public static Pile villages7 = new Pile(village, 10);
        //8
        // Village village = new Village();
        public static Pile villages8 = new Pile(village, 10);
        //9
        // Village village = new Village();
        public static Pile villages9 = new Pile(village, 10);
        //10
        // Village village = new Village();
        public static Pile villages10 = new Pile(village, 10);

        // Dictionary<string,Pile> AllCards = new Dictionary<string,Pile>();
        public List<Pile> AllCards = new List<Pile>();
        public PlayMat(){  
            Card estate = new Estate();
            Pile estates = new Pile(estate, 24);
            AllCards.Add(estates ); 
            AllCards.Add(duchies );
            AllCards.Add(provinces );
            AllCards.Add(coppers );
            AllCards.Add(silvers );
            AllCards.Add(golds );
            AllCards.Add(villages1 );
            AllCards.Add(villages2 );
            AllCards.Add(villages3 );
            AllCards.Add(villages4 );
            AllCards.Add(villages5 );
            AllCards.Add(villages6 );
            AllCards.Add(villages7 );
            AllCards.Add(villages8 );
            AllCards.Add(villages9 );
            AllCards.Add(villages10 );
            AllCards.Add(curses );
            DisplayGameState();    

            ActionCards.Add(new Village());     

        }

        public void DisplayGameState(){
            System.Console.WriteLine($"there are {estates.Count} Estates left");
            System.Console.WriteLine($"there are {duchies.Count} duchies left");
            System.Console.WriteLine($"there are {provinces.Count} provinces left");
            System.Console.WriteLine($"there are {curses.Count} curses left");
            System.Console.WriteLine($"there are {coppers.Count} coppers left");
            System.Console.WriteLine($"there are {silvers.Count} silvers left");
            System.Console.WriteLine($"there are {golds.Count} golds left");
            System.Console.WriteLine($"there are {villages1.Count} villages1 left");
            System.Console.WriteLine($"there are {villages2.Count} villages2 left");
            System.Console.WriteLine($"there are {villages3.Count} villages3 left");
            System.Console.WriteLine($"there are {villages4.Count} villages4 left");
            System.Console.WriteLine($"there are {villages5.Count} villages5 left");
            System.Console.WriteLine($"there are {villages6.Count} villages6 left");
            System.Console.WriteLine($"there are {villages7.Count} villages7 left");
            System.Console.WriteLine($"there are {villages8.Count} villages8 left");
            System.Console.WriteLine($"there are {villages9.Count} villages9 left");
            System.Console.WriteLine($"there are {villages10.Count} villages10 left");
        }

        public Card PickPile(string name){
            foreach(var pile in AllCards){
                if( pile.Name == name){
                    if( pile.Count > 0){
                        Card bought_card = pile.cards[0];
                        pile.cards.RemoveAt(0);
                        pile.Count--;
                        if (pile.Count == 0){
                            EmptyPile++;
                        }
                        return bought_card;

                    }else{
                        System.Console.WriteLine("Pile is empty choose another card");
                        return null;
                    }

                }
            }

            return null;

        }

    }
}


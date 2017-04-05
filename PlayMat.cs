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
        public static Estate estate = new Estate();
        public static Pile estates = new Pile(estate, 24);
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
        public PlayMat(){   
            DisplayGameState();         

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

    }
}

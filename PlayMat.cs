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
        public static List<Card> ActionCards = new List<Card>();
        public static List<Card> PossibleCards = new List<Card>();
      
        public static Village village = new Village();
        public static Cellar cellar = new Cellar();
        public static Chapel chapel = new Chapel();
        public static Moat moat = new Moat();
        
        public static Chancellor chancellor = new Chancellor();
        
        public static Woodcutter woodcutter = new Woodcutter();
        
        public static Workshop workshop = new Workshop();
        
        public static Feast feast = new Feast();
       
        public static Militia militia = new Militia();
        
        public static Witch witch = new Witch();
        
        public static Moneylender moneylender = new Moneylender();
        
        public static Smithy smithy = new Smithy();
        
        public static Throneroom throneroom = new Throneroom();
        
        public static Festival festival = new Festival();
        
        public static Laboratory laboratory = new Laboratory();
        
        
        //{"Village", "Cellar", "Chapel","Moat", "Chancellor", 
        // "Woodcutter", "Workshop", "Feast", "Militia","Witch",
        // "Moneylender", "Smithy", "Throneroom", "Festival", "Laboratory" };
        // public static Estate estate = new Estate();
        // public static Pile estates = new Pile(estate, 24);
        //make 3 piles of Victory cards
            
        // public static Card estate = new Estate();
        // public static Pile estates = new Pile(estate, 24);
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
        public Pile ActionPiles;

        //make 10 piles of action cards
        //in the future make a for loop to grab 10 random 
        //cards from a dictionary of all possible action cards

        

        // Dictionary<string,Pile> AllCards = new Dictionary<string,Pile>();
        public List<Pile> ThisGameCards = new List<Pile>();
        public PlayMat(){  
            // List<System.Type> silly = new List<System.Type>();
            // silly.Add(typeof(Estate));
            TrashedCards = new List<Card>();
            
            PossibleCards.Add(village);
            PossibleCards.Add(cellar);
            PossibleCards.Add(chapel);
            PossibleCards.Add(moat);
            PossibleCards.Add(chancellor);
            PossibleCards.Add(woodcutter);
            PossibleCards.Add(workshop);
            PossibleCards.Add(feast);
            PossibleCards.Add(militia);
            PossibleCards.Add(witch);
            PossibleCards.Add(moneylender);
            PossibleCards.Add(smithy);
            PossibleCards.Add(throneroom);
            PossibleCards.Add(festival);
            PossibleCards.Add(laboratory);
            ActionCards = SetupActionsCards(PossibleCards);
            ThisGameCards.Add(new Estate().CreatePile() ); 
            ThisGameCards.Add(duchies );
            ThisGameCards.Add(provinces );
            ThisGameCards.Add(curses );
            ThisGameCards.Add(coppers );
            ThisGameCards.Add(silvers );
            ThisGameCards.Add(golds );
            foreach (var card in ActionCards){
                ActionPiles = new Pile(card, 10);
                ThisGameCards.Add(ActionPiles);
            }
        
            DisplayGameState();    
        }

        public void DisplayGameState(){
            foreach (var pile in ThisGameCards){
                System.Console.WriteLine($"there are {pile.Count} {pile.Name}'s left");
            }
            
        }

        public Card PickPile(string name){
            foreach(var pile in ThisGameCards){
                if( pile.Name == name){
                    if( pile.Count > 0){
                        Card picked_card = pile.cards[0];
                        pile.cards.RemoveAt(0);
                        pile.Count--;
                        if (pile.Count == 0){
                            EmptyPile++;
                        }
                        return picked_card;

                    }else{
                        System.Console.WriteLine("Pile is empty choose another card");
                        return null;
                    }

                }
            }
            return null;
        }

        public List<Card> SetupActionsCards(List<Card> cardlist){
            Random rand = new Random();
            List<Card> shuffledlist = ShuffleList(cardlist);
            List<Card> ChosenActions = new List<Card>();
            for (int i = 0; i <10; i++){
                ChosenActions.Add(shuffledlist[i]);
            }
        return ChosenActions;
        }
        public List<Card> ShuffleList(List<Card> cardlist){
            Random rand = new Random();
            List<Card> responcelist = cardlist;
            for (int i = responcelist.Count-1; i >= 0; i--){
                int j =rand.Next(0,i);
                Card tempcard = responcelist[i]; 
                responcelist[i]= responcelist[j];
                responcelist[j]= tempcard;
            }
        return responcelist;
        }

    }
}


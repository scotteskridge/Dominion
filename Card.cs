using System;
using System.Linq;
using System.Collections.Generic;
using Dominion_Project;

namespace Dominion_Project{
    //Not sure if I want to implement each kingdom card as an instance of cards or if each kingdom card needs to be a child of card and its own class
    public class Card{

        public int Cost;
        public int Victory_Points {get; set;}
        public string Type {get; set;} // Action, Victory, Action - Attack, Action - Reaction, Treasure
        public string Name {get; set;}
        // public string Ability {get; set;} //This might need to be an object with methods?
        public int More_Actions {get; set;}
        public int More_Buys {get; set;}
        public int Buying_Power {get; set;}
        public int Draws {get; set;}
        public string Description {get; set;}

        public Card(){

        }

        public virtual void OnPlay(Player player){
        System.Console.WriteLine($"{player.Name} played a {Name}");
    }

        public Card ViewCard(){
            System.Console.WriteLine($"Name is:{this.Name}");
            System.Console.WriteLine($"Cost is:{this.Cost}");
            System.Console.WriteLine($"Victory_Points are:{this.Victory_Points}");
            System.Console.WriteLine($"Type is:{this.Type}");
            System.Console.WriteLine($"More_Actions is:{this.More_Actions}");
            System.Console.WriteLine($"More_Buys is:{this.More_Buys}");
            System.Console.WriteLine($"Buying_Power is:{this.Buying_Power}");
            System.Console.WriteLine($"Draws is:{this.Draws}");
            System.Console.WriteLine($"Description is:{this.Description}");
            
            return this;
        }
}


public class Copper : Card{

    public Copper(){
        Cost = 1;
        Victory_Points = 0;
        Type = "Treasure";
        Name = "Copper";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 1;
        Draws = 0;
        Description = "A copper has a buying value of 1";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Silver : Card{

    public Silver(){
        Cost = 3;
        Victory_Points = 0;
        Type = "Treasure";
        Name = "Silver";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 2;
        Draws = 0;
        Description = $"A {Name} has a buying value of 2";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Gold : Card{

    public Gold(){
        Cost = 6;
        Victory_Points = 0;
        Type = "Treasure";
        Name = "Gold";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 3;
        Draws = 0;
        Description = $"A {Name} has a buying value of 3";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}

public class Estate : Card{

    public Estate(){
        Cost = 2;
        Victory_Points = 1;
        Type = "Victory";
        Name = "Estate";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"An {Name} is worth 1 Victory Point";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Duchy : Card{

    public Duchy(){
        Cost = 5;
        Victory_Points = 3;
        Type = "Victory";
        Name = "Duchy";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"A {Name} is worth 3 Victory Points";
    }
   public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Province : Card{

    public Province(){
        Cost = 8;
        Victory_Points = 6;
        Type = "Victory";
        Name = "Province";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"A {Name} is worth 6 Victory Points";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Curse : Card{

    public Curse(){
        Cost = 0;
        Victory_Points = -1;
        Type = "Victory";
        Name = "Curse";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"A {Name} subtracts 1 from your final score";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}

public class Village : Card{
    public Village(){
        Cost = 3;
        Victory_Points = 0;
        Type = "Action";
        Name = "Village";
        More_Actions = 2;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 1;
        Description = $"A {Name} gives you 2 more actions and a draw";
        
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}

// list of first 10 action cards to implement
public class Cellar : Card{
    public Cellar(){
        Cost = 2;
        Victory_Points = 0;
        Type = "Action";
        Name = "Cellar";
        More_Actions = 1;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"A {Name} let's you discard cards to redraw";
    }
     public override void OnPlay(Player player){
        base.OnPlay(player);
        bool discarding = true;
        while(discarding){
            int newdraws = 0;
            System.Console.WriteLine("Choose a card to discard or 'Pass':");
            player.DisplayPlayerHand();
            string userInput = Program.GetUserString();
                if(userInput != "Pass" && Int32.Parse(userInput)-1 < player.player_hand.Count ){
                    // int userInput = Int32.Parse(Program.GetUserString());
                    Card card = player.player_hand[Int32.Parse(userInput)-1];
                    player.Discard(card);
                    newdraws++;

                } else {
                    for(int i = 0; i < newdraws; i++){
                        player.Draw_Card();
                    }
                    discarding = false; 
                }
        }
     }
}
public class Chapel : Card{
    public Chapel(){
        Cost = 2;
        Victory_Points = 0;
        Type = "Action";
        Name = "Chapel";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"A {Name} let's you trash upto 4 cards from your hand";
    }
     public override void OnPlay(Player player){
        base.OnPlay(player);
        int trashing = 4;
        while(trashing > 0){
            System.Console.WriteLine("Choose a card to trash or 'pass':");
            player.DisplayPlayerHand();
            string userInput = Program.GetUserString();
                if(userInput != "Pass" && Int32.Parse(userInput)-1 < player.player_hand.Count ){
                    // int userInput = Int32.Parse(Program.GetUserString());
                    Card card = player.player_hand[Int32.Parse(userInput)-1];
                    player.Trash(card);
                    trashing--;

                } else trashing = 0; 

        }
    }  
}
public class Moat : Card{
    public Moat(){
        Cost = 2;
        Victory_Points = 0;
        Type = "Reaction";
        Name = "Moat";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 2;
        Description = $"A {Name} protects you from attacks";
    }
     public override void OnPlay(Player player){
        base.OnPlay(player);
    }
    public void OnShow(){

    }
  
}
public class Chancellor : Card{
    public Chancellor(){
        Cost = 3;
        Victory_Points = 0;
        Type = "Reaction";
        Name = "Chancellor";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 2;
        Draws = 2;
        Description = $"The {Name} puts your Deck into your discard pile";
    }
     public override void OnPlay(Player player){
        base.OnPlay(player);
        System.Console.WriteLine("The Chancellor Shuffels your deck into your discard pile");
        for (int i=0; i < player.player_draw_deck.cards.Count; i++){
            player.DiscardFromDeck();
        }
    }
  
}
public class Woodcutter : Card{
    public Woodcutter(){
        Cost = 3;
        Victory_Points = 0;
        Type = "Action";
        Name = "Woodcutter";
        More_Actions = 0;
        More_Buys = 1;
        Buying_Power = 2;
        Draws = 0;
        Description = $"The {Name} gives you another buy";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
   }
}
public class Workshop : Card{
    public Workshop(){
        Cost = 5;
        Victory_Points = 0;
        Type = "Attack";
        Name = "Workshop";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 2;
        Draws = 0;
        Description = $"The {Name} let's you gain a card upto cost 4";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        System.Console.WriteLine("Name a card to gain that costs less than 4");
        Card card = player.playmat.PickPile(Program.GetUserString());
        player.Gain(card);
    }
}
public class Feast : Card{
    public Feast(){
        Cost = 5;
        Victory_Points = 0;
        Type = "Attack";
        Name = "Feast";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 2;
        Draws = 0;
        Description = $"The {Name} trashes it's self to gain a card upto 5 cost";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        System.Console.WriteLine("Name a card to gain that costs less than 5");
        Card card = player.playmat.PickPile(Program.GetUserString());
        player.Gain(card);
        player.Trash(this);
    }
}

public class Militia : Card{
    public Militia(){
        Cost = 4;
        Victory_Points = 0;
        Type = "Attack";
        Name = "Militia";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 2;
        Draws = 0;
        Description = $"The {Name} gives you makes other players discard down to 3 cards";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        foreach(var otherplayer in Program.Players){
            if (otherplayer!= player){
                for (int i =3; i <otherplayer.player_hand.Count; i++){
                Card card = otherplayer.ChooseCard();
                otherplayer.Discard(card);

                }
            }
        }
   }
}
   public class Witch : Card{
    public Witch(){
        Cost = 5;
        Victory_Points = 0;
        Type = "Attack";
        Name = "Witch";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 2;
        Description = $"The {Name} gives  other players curses";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        foreach(var otherplayer in Program.Players){
            if (otherplayer!= player){
                Card curse = otherplayer.playmat.PickPile("Curse");
                otherplayer.Gain(curse);

                }
            }
        }
   }
   public class Moneylender : Card{
    public Moneylender(){
        Cost = 4;
        Victory_Points = 0;
        Type = "Action";
        Name = "Moneylender";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 0;
        Description = $"The {Name} let's you trash a copper to gain +3 coins";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        System.Console.WriteLine("Choose a copper from your hand");
        // need validations in case of null card
        // need validations for only coppers
        // need validation to allow for passing
        Card card = Program.ActivePlayer.ChooseCard();
        player.Trash(card);
        Program.ActivePlayer.Buying_Power += 3;
    }
}
public class Smithy : Card{
    public Smithy(){
        Cost = 4;
        Victory_Points = 0;
        Type = "Action";
        Name = "Smithy";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 3;
        Description = $"The {Name} draws 3 more cards";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        
    }
}
public class Throneroom : Card{
    public Throneroom(){
        Cost = 4;
        Victory_Points = 0;
        Type = "Action";
        Name = "Throneroom";
        More_Actions = 0;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 3;
        Description = $"The {Name} let's you play an action twice";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
        System.Console.WriteLine("Choose an action to play twice");
        Card card = Program.ActivePlayer.ChooseCard();
        Program.ActivePlayer.Play_card(card, player);
        Program.ActivePlayer.Trigger_card(card, player);
    }
}
public class Festival : Card{
    public Festival(){
        Cost = 5;
        Victory_Points = 0;
        Type = "Action";
        Name = "Festival";
        More_Actions = 2;
        More_Buys = 1;
        Buying_Power = 2;
        Draws = 0;
        Description = $"The {Name} gives you more actions buys and coins";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
    }
}
public class Laboratory : Card{
    public Laboratory(){
        Cost = 5;
        Victory_Points = 0;
        Type = "Action";
        Name = "Laboratory";
        More_Actions = 1;
        More_Buys = 0;
        Buying_Power = 0;
        Draws = 2;
        Description = $"The {Name} gives you one more actions buys and coins";
    }
    public override void OnPlay(Player player){
        base.OnPlay(player);
    }
}
   


} // end of namespace
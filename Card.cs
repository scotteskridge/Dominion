using Dominion_Project;

namespace Dominion_Project{
    //Not sure if I want to implement each kingdom card as an instance of cards or if each kingdom card needs to be a child of card and its own class
    public class Card{
        public int Cost {get; set;}
        public int Victory_Points {get; set;}
        public string Type {get; set;} // Action, Victory, Action - Attack, Action - Reaction, Treasure
        public string Name {get; set;}
        // public string Ability {get; set;} //This might need to be an object with methods?
        public int More_Actions {get; set;}
        public int More_Buys {get; set;}
        public int Buying_Power {get; set;}
        public int Draws {get; set;}

        public Card(){

        }

        public void OnPlay(){
        
    }
        
    }
}

// list of first 10 action cards to implement
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
    }
    new public void OnPlay(){
        System.Console.WriteLine("You you played a village");

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
    }
    new public void OnPlay(){
        System.Console.WriteLine("You you played a Copper");

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
    }
    new public void OnPlay(){
        System.Console.WriteLine("You you played a Estate");

    }



}
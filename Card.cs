namespace Dominion_Project{
    //Not sure if I want to implement each kingdom card as an instance of cards or if each kingdom card needs to be a child of card and its own class
    public class Card{
        public int Cost {get; set;}
        public string Type {get; set;} // Action, Victory, Action - Attack, Action - Reaction, Treasure
        public string Name {get; set;}
        public string Ability {get; set;} //This might need to be an object with methods?
        public int More_Actions {get; set;}
        public int More_Buys {get; set;}
        public int Buying_Power {get; set;}
        public int Draws {get; set;}
        
    }
}
namespace KOT.Services.Processors;
using KOT.Models;
using KOT.Models.Abstracts;
public class PowerCardDeck
{
    List<PowerCard> Deck = new List<PowerCard>(){
        new PowerCard("Acid Attack", 6, 0),
        new PowerCard("Alien Metabolism", 3, 0),
        new PowerCard("Alpha Monster", 5, 0),
        new PowerCard("Apartament Building", 5, 1),
        new PowerCard("Armor Plating", 4, 0),
        new PowerCard("Background Dweller", 4, 0),
        new PowerCard("Burrowing", 5, 0),
        new PowerCard("Camouflage", 3, 0),
        new PowerCard("Commuter Train", 4, 1),
        new PowerCard("Complete Destruction", 3, 0),
        new PowerCard("Corner Store", 3, 1)

    };
}

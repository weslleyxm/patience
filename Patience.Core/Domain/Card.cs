
namespace Patience.Core.Domain;

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public bool IsFaceUp { get; set; } = false;

    public int PileIndex { get; set; } = 0;

    public int CardIndex { get; set; } = 0;

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public void FlipUp()
    {
        IsFaceUp = true;
    }

    public void FlipDown() 
    {
        IsFaceUp = false;
    }
}
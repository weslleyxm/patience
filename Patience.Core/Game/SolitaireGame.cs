using Patience.Core.Domain;
using Patience.Core.Utilities;

namespace Patience.Core.Game;

public class SolitaireGame
{
    private List<Card> deck = new();
    private List<List<Card>> tableau = new();

    public IReadOnlyList<Card> Deck => deck.AsReadOnly();
    public IReadOnlyList<List<Card>> Tableau => tableau.AsReadOnly();

    public SolitaireGame()
    {
        InitializeDeck();
        InitializeTableau();
    }

    private void InitializeDeck()
    {
        var cards = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }

        deck = Shuffler<Card>.Shuffle(cards);
    }

    public Card Draw()
    {
        if (deck.Count == 0)
        {
            throw new InvalidOperationException("Deck is empty");
        }

        var card = deck[0];
        deck.RemoveAt(0);
        return card;
    }

    private void InitializeTableau()
    {
        for (int column = 0; column < 7; column++)
        {
            var stack = new List<Card>();

            for (int row = 0; row <= column; row++)
            {
                Card card = Draw();

                if (row == column) 
                    card.FlipUp(); 
                else
                    card.FlipDown();

                card.PileIndex = column;
                card.CardIndex = row;

                stack.Add(card);
            }

            tableau.AddRange(stack);
        }

        Console.WriteLine(Tableau.Count);
    }
}

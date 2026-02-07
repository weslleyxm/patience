using Patience.Core.Domain;
using Patience.Core.Game;
using Raylib_cs;

namespace Patience.App.Rendering;

public class BoardRenderer
{
    private readonly CardTextureCache cardTextureCache;
    private readonly SolitaireGame solitaireGame;

    public BoardRenderer(CardTextureCache cardTextureCache, SolitaireGame solitaireGame)
    {
        this.cardTextureCache = cardTextureCache;
        this.solitaireGame = solitaireGame;
    }

    public void Draw()
    {
        DrawTableau();
    }

    public void DrawTableau()
    {
        for (int column = 0; column < solitaireGame.Tableau.Count; column++)
        {
            for (int row = 0; row < solitaireGame.Tableau[column].Count; row++)
            {
                var pos = BoardLayout.TableauCardPos(column, row);
                var card = solitaireGame.Tableau[column].ElementAtOrDefault(row);

                if (card != null)
                {
                    DrawCard(card, (int)pos.X, (int)pos.Y);
                }
            }
        }
    }

    public void DrawCard(Card card, int x, int y)
    {
        string cardName = string.Empty;

        if (card.IsFaceUp) 
            cardName = $"card_faces.{card.Rank}_of_{card.Suit}".ToLower();
        else
            cardName = "card_backs.card_back_1";  

        var texture = cardTextureCache.GetTexture(cardName);
        Raylib.DrawTexture(texture, x, y, Color.White);
    }
}

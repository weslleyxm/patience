using Patience.App.Rendering;
using Patience.Core.Game;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Patience.App;

public class GameApp
{
    private readonly BoardRenderer boardRenderer;
    private readonly CardTextureCache cardTextureCache; 
    private readonly SolitaireGame solitaireGame;

    public GameApp()
    {
        cardTextureCache = new CardTextureCache();
        solitaireGame = new SolitaireGame();
        boardRenderer = new BoardRenderer(cardTextureCache, solitaireGame); 
        solitaireGame = new SolitaireGame();
    }  

    public void Run()
    {
        const int screenWidth = 1000;
        const int screenHeight = 650;

        InitWindow(screenWidth, screenHeight, "Patience"); 

        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(new Color(26, 118, 45));

            boardRenderer.Draw(); 

            EndDrawing();
        }

        CloseWindow();
    }
}

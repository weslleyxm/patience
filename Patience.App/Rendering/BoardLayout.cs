using System;
namespace Patience.App.Rendering;

public static class BoardLayout
{
    public static Vector2 TableauBasePos(int column) => new(40 + column * 120, 220); 

    public static int TableauCardOffsetY => 28;   
     
    public static Vector2 TableauCardPos(int column, int cardIndex)
        => TableauBasePos(column) + new Vector2(0, cardIndex * TableauCardOffsetY);
}

using Patience.App.Utilities;
using Raylib_cs;

namespace Patience.App.Rendering;

public class CardTextureCache : IDisposable
{
    public Dictionary<string, Texture2D> Cache { get; } = new Dictionary<string, Texture2D>();

    public Texture2D GetTexture(string name)
    {
        if (Cache.TryGetValue(name, out Texture2D texture))
        {
            return texture;
        }

        texture = Resources.GetTexture(name);
        Cache[name] = texture;
        return texture;
    }
     
    public void Dispose()
    {
        foreach (var texture in Cache.Values)
        {
            Raylib.UnloadTexture(texture);
        }
    }
}

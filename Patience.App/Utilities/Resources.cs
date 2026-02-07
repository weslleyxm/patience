using System.Collections.Concurrent;
using Image = Raylib_cs.Image;
using System.Reflection;
using Raylib_cs;

namespace Patience.App.Utilities;

public static class Resources
{
    public static ConcurrentDictionary<string, byte[]> ManifestResources = new();

    public static Texture2D GetTexture(string name)
    {
        if (ManifestResources.TryGetValue(name, out byte[]? bytes) && bytes != null)
        {
            return LoadTexture(name, bytes);
        }

        var assembly = Assembly.GetExecutingAssembly();
  
        using (var stream = assembly.GetManifestResourceStream($"Patience.App.Resources.{name}.png"))
        {
            if(stream == null)
            {
                throw new Exception($"Resource {name} not found in assembly manifest");
            } 

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var streamBytes = memoryStream.ToArray();

                if (!ManifestResources.TryAdd(name, streamBytes))
                {
                    throw new Exception($"Failed to add resource {name} to ManifestResources");
                } 

                return LoadTexture(name, streamBytes);
            } 
        }
    }

    private static Texture2D LoadTexture(string name, byte[] bytes)
    {
        Image image = Raylib.LoadImageFromMemory(".png", bytes);
        Texture2D loadedTexture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
        return loadedTexture;
    } 
}

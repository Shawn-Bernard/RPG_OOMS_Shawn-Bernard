using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
public class Map
{
    private Texture2D Ground;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private StringReader Map1;
    private string path = $"{Environment.CurrentDirectory}";
    public void Draw()
    {
        ConvertMapToTilemap(Map1.ReadLine());
    }
    public void LoadPremadeMap(string Path)
    {

        if (File.Exists(Path))
        {
            string mapData = File.ReadAllText(Path);
            ConvertMapToTilemap(mapData);
        }
    }
    public void ConvertMapToTilemap(string mapData)
    {
        //Split the map when no text is there
        string[] Map = mapData.Split("\n");
        char tile;

        for (int y = 0; y < Map.Length; y++)
        {
            for (int x = 0; x < Map[y].Length; x++)
            {
                tile = Map[y][x];

                
            }
        }

    }
}

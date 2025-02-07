using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Numerics;
public class Map
{
    public Texture2D Ground;
    public Rectangle MapPosition;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public char tile;
    private Game game;
    //private StringReader Map1;
    private string path = $"{Environment.CurrentDirectory}/Maps";
    private string Level_1 = "Level1";
    private string Level_2 = "Level2";
    private string Level_3 = "Level3";

    public Map(Game GameManager)
    {
        game = GameManager;
    }
    public void Draw()
    {
       ConvertMapToTilemap(path+Level_1);
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
                switch (tile)
                {
                    case '-':
                        Ground = game.Content.Load<Texture2D>("Ground");
                        Rectangle MapPosition = new Rectangle(0, 0, Ground.Width, Ground.Height);
                        //_spriteBatch.Draw(Ground, MapPosition,Color.Beige);
                        break;
                }
            }
        }

    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG_OOMS_Shawn_Bernard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Map
{
    private Texture2D Ground;
    private Texture2D Wall;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Dictionary<Vector2, int> tileMap;
    // Getting the current directory which is "Game file" > bin > Debug > net6.0
    // But the game hates that so were going back 3 folders out with /../ and going into my maps folder
    string path = $"{Environment.CurrentDirectory}/../../../Maps/Map1.txt";

    Game1 game;
    /// <summary>
    /// This will convert my map
    /// </summary>
    public Map(Game1 gameManager)
    {
        game = gameManager;

        _spriteBatch = gameManager._spriteBatch;
        _graphics = gameManager._graphics;

        
        tileMap = LoadMap(path);

        LoadContent(Ground, "Ground");
        LoadContent(Wall, "Wall");
    }
    private void LoadContent(Texture2D texture2D ,string textureName)
    {
        texture2D = game.Content.Load<Texture2D>(textureName);
    }

    private Dictionary<Vector2, int> LoadMap(string filepath)
    {
        Dictionary<Vector2, int> result = new();
        //Reading in my file path
        StreamReader reader = new(path);
        int y = 0;
        string line;
        // reading my line untill it untill I can
        while ((line = reader.ReadLine()) != null)
        {
            for (int x = 0; x < line.Length; x++)
            {
                char tile = line[x];

                if (tile == '#')
                {
                    result[new Vector2(x, y)] = 0;
                }
                else if (tile == '-')
                {
                    result[new Vector2(x, y)] = 1;
                }
            }
            y++;
        }
        return result;
    }
    public void drawMap()
    {
        foreach (var item in tileMap)
        {
            Vector2 position = new Vector2(item.Key.X * 16, item.Key.Y * 16);

            if (item.Value == 0)
            {
                //_spriteBatch.Draw(Wall, position, Color.White);
                game._spriteBatch.Draw(Wall, position, Color.White);
                Debug.WriteLine(item.Value);
            }
            else if (item.Value == 1)
            {
                game._spriteBatch.Draw(Ground, position, Color.White);
                Debug.WriteLine(item.Value);
            }

        }
    }
}

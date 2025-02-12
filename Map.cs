using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG_OOMS_Shawn_Bernard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using RPG_OOMS_ShawnBernard;

public class Map
{
    public Texture2D Ground;
    public Texture2D Wall;
    public Vector2 Position;

    private Dictionary<Vector2, int> tileMap;
    // Getting the current directory which is "Game file" > bin > Debug > net6.0
    // But the game hates that so were going back 3 folders out with /../ and going into my maps folder
    string path = $"{Environment.CurrentDirectory}/../../../Maps/Map1.txt";
    Game1 gameManger;
    /// <summary>
    /// This will convert my map
    /// </summary>
    public Map(Texture2D Ground,Texture2D Wall)
    {
        Game1 gameManager = new Game1();
        this.Ground = Ground;
        this.Wall = Wall;
        tileMap = LoadMap(path);

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
        gameManger._spriteBatch.Begin();
        foreach (var item in tileMap)
        {
            Position = new Vector2(item.Key.X * 16, item.Key.Y * 16);

            if (item.Value == 0)
            {
                //gameManger._spriteBatch.Draw(Wall, position, Color.White);
                Debug.WriteLine(item.Value);
            }
            else if (item.Value == 1)
            {
                //gameManger._spriteBatch.Draw(Ground, position, Color.White);
                Debug.WriteLine(item.Value);
            }

        }
        gameManger._spriteBatch.End();
    }
}

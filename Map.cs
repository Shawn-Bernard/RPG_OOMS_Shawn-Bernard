using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG_OOMS_Shawn_Bernard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Map : GameObject
{
    /// <summary>
    /// Setting the sprites when a new map is made
    /// </summary>
    /// <param name="Sprite_1"></param>
    /// <param name="Sprite_2"></param>
    public Map()
    {
        Debug.Write($"map is here ");
        LoadMap loadMap = new LoadMap();
        loadMap.SetGameObject(this);
        AddComponent(loadMap);
    }
}
public class LoadMap : Component
{
    private string path = $"{Environment.CurrentDirectory}/../../../Maps/";

    public static LoadMap instance;

    private Dictionary<Vector2, int> tileMap;

    private List<string> Maps = new List<string>();

    public LoadMap()
    {
        instance = this;
        AddPreMadeMaps();
        MapStyle();
    }
    public override void Awake()
    {
        
    }
    public override void Start()
    {
    }

    public void MapStyle()
    {
        tileMap = new Dictionary<Vector2, int>();
        tileMap = TextMap(path + PickRandomMap());
    }
    // Adding my list of strings for my map
    private void AddPreMadeMaps()
    {
        Maps.Add("Level_1.txt");
        Maps.Add("Level_2.txt");
        Maps.Add("Level_3.txt");
    }

    public int checkTile(Vector2 checkedPosition)
    {
        // Returning an int based on the checked position
        return tileMap[checkedPosition];
    }

    //Picks a random map from the list of maps 
    private string PickRandomMap()
    {
        Random random = new Random();
        int index = random.Next(Maps.Count);
        return Maps[index];
    }
    private Dictionary<Vector2, int> TextMap(string filepath)
    {
        Dictionary<Vector2, int> result = new Dictionary<Vector2, int>();
        //This will read my map text file
        StreamReader reader = new StreamReader(filepath);
        int y = 0;
        string line;
        //This will give line the value untill the reader is done reading the text file
        while ((line = reader.ReadLine()) != null)
        {
            for (int x = 0; x < line.Length; x++)
            {
                char tile = line[x];
                switch (tile)
                {
                    case '#':
                        //Results will store a Vector2 with a value (Example vector2(0,0) with the value of 0
                        result[new Vector2(x, y)] = 0;
                        break;
                    case '-':
                        result[new Vector2(x, y)] = 1;
                        break;
                    case '*':
                        //This would be the player if I got it working
                        result[new Vector2(x, y)] = 2;
                        break;
                }
            }
            y++;
        }
        return result;
    }
    /// <summary>
    /// Overriding my OnDraw because I need the position from the results in text map
    /// </summary>
    /// <param name="spriteBatch"></param>
    public override void OnDraw(SpriteBatch spriteBatch)
    {
        //The result is the return from Text Map
        foreach (var Result in tileMap)
        {
            Vector2 Position = new Vector2(Result.Key.X * 16, Result.Key.Y * 16);

            switch (Result.Value)
            {
                case 0:
                    spriteBatch.Draw(GameObject.Texture_1, Position, GameObject.color);
                    break;
                case 1:
                    spriteBatch.Draw(GameObject.Texture_2, Position, GameObject.color);
                    break;
                case 2:
                    spriteBatch.Draw(GameObject.Texture_1, Position, GameObject.color);
                    break;
            }
        }
    }
}

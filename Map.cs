using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Map : GameObject
{
    public Map(Texture2D Sprite_1,Texture2D Sprite_2 ) : base(Sprite_1, Sprite_2)
    {
        this.texture_1 = Sprite_1;
        this.texture_2 = Sprite_2;
        Debug.Write($"map is here ");
        LoadMap loadMap = new LoadMap();
        loadMap.SetGameObject(this);
        AddComponent(loadMap);
    }
}
public class LoadMap : Component
{
    private string path = $"{Environment.CurrentDirectory}/../../../Maps/";
    public Dictionary<Vector2, int> tileMap;
    private List<string> Maps = new List<string>();

    GameObject player;
    public override void Start()
    {
        AddPreMadeMaps();
        //Debug.Write(path + PickRandomMap());
        tileMap = TextMap(path+PickRandomMap());
        //Debug.Write($"im here");
        
        
    }
    private void AddPreMadeMaps()
    {
        Maps.Add("Level_1.txt");
        Maps.Add("Level_2.txt");
        Maps.Add("Level_3.txt");
    }

    private string PickRandomMap()
    {
        Random random = new Random();
        int index = random.Next(Maps.Count);
        return Maps[index];
    }
    private Dictionary<Vector2, int> TextMap(string filepath)
    {
        Dictionary<Vector2, int> result = new Dictionary<Vector2, int>();
        StreamReader reader = new StreamReader(filepath);
        int y = 0;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            for (int x = 0; x < line.Length; x++)
            {
                char tile = line[x];
                switch (tile)
                {
                    case '#':
                        result[new Vector2(x, y)] = 0;
                        break;
                    case '-':
                        result[new Vector2(x, y)] = 1;
                        break;
                    case '*':
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
        foreach (var item in tileMap)
        {
            Vector2 Position = new Vector2(item.Key.X * 16, item.Key.Y * 16);

            switch (item.Value)
            {
                case 0:
                    spriteBatch.Draw(gameObject.texture_1, Position, gameObject.color);
                    break;
                case 1:
                    spriteBatch.Draw(gameObject.texture_2, Position, gameObject.color);
                    break;
                case 2:
                    spriteBatch.Draw(gameObject.texture_1, Position, gameObject.color);
                    break;
            }
        }
    }

    public override void Update()
    {
    }
}

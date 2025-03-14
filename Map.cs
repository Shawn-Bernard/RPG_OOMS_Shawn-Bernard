using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG_OOMS_Shawn_Bernard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
    Random rng = new ();

    private string path = $"{Environment.CurrentDirectory}/../../../Maps/";

    public static LoadMap instance;

    private Dictionary<Vector2, int> tileMap;

    int rngX;

    int rngY;

    private List<string> Maps = new List<string>();

    
    public LoadMap()
    {
        instance = this;
        AddPreMadeMaps();
        MapStyle();
    }

    public void MapStyle()
    {
        tileMap = InitializeMap();
        //tileMap = TextMap(path + PickRandomMap());
    }

    private Dictionary<Vector2, int> InitializeMap()
    {
        Dictionary<Vector2, int> MapGen = new Dictionary<Vector2, int>();
        rngX = rng.Next(15, 30);
        rngY = rng.Next(15, 20);
        //Step 1 initializing map
        for (int x = 0; x < rngX; x++)
        {
            for (int y = 0; y < rngY; y++)
            {
                //Adding my base map with only floors
                MapGen.Add(new Vector2(x, y),1);
            }
        }

        //Step 2 placing walls
        for (int x = 0; x < rngX; x++)
        {
            for (int y = 0; y < rngY; y++)
            {
                //If statement that checks arounf the borders
                if (x == 0 || y == 0 || x == rngX -1 || y == rngY -1)
                {
                    MapGen[new Vector2(x, y)] = 0;
                }
            }
        }

        //Step 3: Place clusters
        //Making a amount of clusters equal to the max map count
        int numClusters = MapGen.Count;
        for (int i = 0; i < numClusters; i++)
        {
            //Picking my start x & y for the to start clusters
            int clusterX = rng.Next(1, rngX);
            int clusterY = rng.Next(1, rngY);

            //Picking a random width & height for my clusters
            int clusterWidth = rng.Next(2, 4);
            int clusterHeight = rng.Next(2, 4);

            //Making a bool to check if i can place
            bool canPlace = true;

            //Checking a negative space so we can look around the cluster to see if we can place 
            //The reason being check back 1 space (-1) then forward space (width + 1)
            for (int x = -1; x < clusterWidth + 1; x++)
            {
                for (int y = -1; y < clusterHeight + 1; y++)
                {
                    Vector2 checkPosition = new Vector2(clusterX + x, clusterY + y);
                    //If my map has the key position & the value of 0 can place is false
                    if (MapGen.ContainsKey(checkPosition) && MapGen[checkPosition] == 0)
                    {
                        canPlace = false;
                    }
                }
            }
            //If we can place doing a for loop with the cluster width / height
            if (canPlace)
            {
                for (int x = 0; x < clusterWidth; x++)
                {
                    for (int y = 0; y < clusterHeight; y++)
                    {
                        Vector2 ClusterPosition = new Vector2(clusterX + x, clusterY + y);

                        MapGen[ClusterPosition] = 0;
                    }
                }
            }
        }

        return MapGen;
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

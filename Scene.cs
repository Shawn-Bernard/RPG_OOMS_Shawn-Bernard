﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class Scene
{
    public List<GameObject> gameObject;

    /// <summary>
    /// Making a new list of game objects when scene is created 
    /// </summary>
    public Scene()
    {
        gameObject = new List<GameObject>();
    }
    /*
     * I'm trying to add soon not now 
    public T FindGameObject<T>() where T : GameObject
    {
        for (int i = 0; i < gameObjectsInScene.Count; i++)
        {
            if (gameObjectsInScene[i] is T foundObject)
            {

                Debug.Write($"[ This has been returned { foundObject } ]");
                return foundObject;
            }
        }
        return null;
    }
    */

    /// <summary>
    /// Adding my game object to my list so I can do a foreach loop
    /// </summary>
    /// <param name="GameObject"></param>
    public void AddGameObject(GameObject GameObject)
    {
        //Debug.Write("[ New added object ]");
        gameObject.Add(GameObject);
        GameObject.AddObjectFromScene(this);

    }

    /// <summary>
    /// Foreach object in our list of gameObjects we draw then each 
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        //samplerState: SamplerState.PointClamp will make my sprites more clear
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        
        foreach (GameObject Object in gameObject)
        {
            //Throwing in my sprite batch into my game for my components
            Object.DrawObject(spriteBatch);
        }

        spriteBatch.End();
    }
    public void Awake()
    {
        //Debug.Write(" Wake ");
        foreach (GameObject Object in gameObject)
        {
            Object.Awake();
        }
    }

    public void Start()
    {
        //Debug.Write(" Started ");
        foreach (GameObject Object in gameObject)
        {
            Object.Start();
        }
    }
    /// <summary>
    /// This is to update our scene and running through our list of game object and calling the update method for each of them 
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        foreach (GameObject Object in gameObject)
        {
            Object.Update();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
/// <summary>
/// This will hold any components logic for methods
/// </summary>
public abstract class Component
{
    private GameObject gameObject;

    public List<GameObject> gameObjectsInScene = new List<GameObject>();


    public GameObject GameObject { get => gameObject; private set => gameObject = value; }
    /// <summary>
    /// So I can set my object for reference and also start my method 
    /// </summary>
    /// <param name="gameObject"></param>
    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
        Awake();
    }
    /// <summary>
    /// This will find the object listed in the current scene and returns the object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T FindGameObject<T>() where T : GameObject
    {
        for (int i = 0; i < gameObjectsInScene.Count; i++)
        {
            if (gameObjectsInScene[i] is T foundObject)
            {

                //Debug.Write($"[ This has been returned { foundObject } ]");
                return foundObject;
            }
        }
        return null;
    }
    /// <summary>
    /// Gets scene objects list
    /// </summary>
    /// <param name="gameObjects"></param>
    public void SceneObjectList(List<GameObject> gameObjects)
    {
        gameObjectsInScene = gameObjects;
    }

    public virtual void Awake() { }
    /// <summary>
    /// Making these virtaul because abstract will force me to add these, but will need them for some method
    /// </summary>
    public virtual void Start() { }

    /// <summary>
    /// Making these virtaul because abstract will force me to add these, but will need them for some method
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// Making a virtual OnDraw base and overriding for my map
    /// </summary>
    /// <param name="spriteBatch"></param>
    public virtual void OnDraw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(gameObject.Texture_1, gameObject.Position, gameObject.color);
    }
}


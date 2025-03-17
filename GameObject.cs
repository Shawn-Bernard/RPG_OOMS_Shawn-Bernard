using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
public class GameObject
{
    public List<Component> components;

    public List<GameObject> gameObjectsInScene = new List<GameObject>();

    public Scene Currentscene;

    private Texture2D texture_1;
    /// <summary>
    /// Will Get the texture_1 and set value to texture_1
    /// </summary>
    public Texture2D Texture_1 { get => texture_1; set => texture_1 = value; }

    private Texture2D texture_2;
    /// <summary>
    /// Will Get the texture_2 and set value to texture_2
    /// </summary>
    public Texture2D Texture_2 { get => texture_2; set => texture_2 = value; }


    private Texture2D texture_3;
    /// <summary>
    /// Will Get the texture_2 and set value to texture_2
    /// </summary>
    public Texture2D Texture_3 { get => texture_3; set => texture_3 = value; }
    private Vector2 position;
    /// <summary>
    /// Will Get the position and set value to position
    /// </summary>
    public Vector2 Position { get => position; set => position = value; }

    


    public Color color = Color.White;
    /// <summary>
    /// Using polymorphism checking for one sprite injected in
    /// </summary>
    /// <param name="Sprite_1"></param>
    public GameObject()
    {
        components = new List<Component>();
        gameObjectsInScene.Add(this);
    }

    public void AddTexture(Texture2D Sprite_1)
    {
        Texture_1 = Sprite_1;
    }
    public void AddTexture(Texture2D Sprite_1, Texture2D Sprite_2, Texture2D Sprite_3)
    {
        Texture_1 = Sprite_1;
        Texture_2 = Sprite_2;
        Texture_3 = Sprite_3;
    }

    /// <summary>
    /// Takes in a new component and setting the objects to the current game object & adds to list
    /// </summary>
    /// <param name="component"></param>
    public void AddComponent(Component component)
    {
        component.SetGameObject(this);
        components.Add(component);
        
        Awake();
    }/// <summary>
    /// Runs a loop to find the component in the list of components  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetComponent<T>() where T : Component
    {
        foreach (Component component in components)
        {
            if (component is T foundComponent)
            {
                //Debug.Write($"[ {foundComponent} has been found ]");
                return foundComponent;
            }
        }
        return null;
    }
    /// <summary>
    /// Gives the list of game objects to components and gameobjects, this should give game objects to have another game object    
    /// </summary>
    /// <param name="scene"></param>
    public void AddObjectFromScene(Scene scene)
    {
        gameObjectsInScene = scene.gameObject;
        foreach (Component component in components)
        {
            component.SceneObjectList(gameObjectsInScene);
            component.GameObject.components = components;
        }

    }
    /// <summary>
    /// Takes in a sprite batch so it can be used in components
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void DrawObject(SpriteBatch spriteBatch)
    {
        foreach (Component component in components)
        {
            //I don't think I need to do this but I'm so scared to try it
            component.OnDraw(spriteBatch);
        }
    }
    public void Awake()
    {
        foreach (Component component in components)
        {
            component.Awake();
        }
    }

    public void Start()
    {
        foreach (Component component in components)
        {
            component.Start();
        }
    }
    /// <summary>
    /// Updating my components with update in them 
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update()
    {
        
        foreach (Component component in components)
        {
            component.Update();
        }
    }
}

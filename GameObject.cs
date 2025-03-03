using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class GameObject
{
    private List<Component> components;

    public Texture2D texture_1;
    /// <summary>
    /// Will Get the texture_1 and set value to texture_1
    /// </summary>
    public Texture2D Texture_1 { get => texture_1; set => texture_1 = value; }

    public Texture2D texture_2;
    /// <summary>
    /// Will Get the texture_2 and set value to texture_2
    /// </summary>
    public Texture2D Texture_2 { get => texture_2; set => texture_2 = value; }

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
    public GameObject(Texture2D Sprite_1)
    {
        components = new List<Component>();
    }
    /// <summary>
    /// Using polymorphism checking for two sprite injected in
    /// </summary>
    /// <param name="Sprite_1"></param>
    /// <param name="Sptite_2"></param>
    public GameObject(Texture2D Sprite_1, Texture2D Sptite_2)
    {
        components = new List<Component>();
    }
    /// <summary>
    /// Giving my objects to add components while 
    /// </summary>
    /// <param name="component"></param>
    public void AddComponent(Component component)
    {
        components.Add(component);
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

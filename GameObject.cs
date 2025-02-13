using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class GameObject
{
    private List<Component> components;
    public Dictionary<Vector2, int> tileMap;

    public Texture2D texture_1;
    public Texture2D texture_2;
    public Vector2 position;



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

    public void RemoveComponent(Component component)
    {
        components.Remove(component);
    }

    public void DrawObject(SpriteBatch spriteBatch)
    {
        foreach (Component component in components)
        {
            component.OnDraw(spriteBatch);
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (var component in components)
        {
            component.Update();
        }
    }
}

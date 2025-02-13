using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Player Class where we add our components and make an object reference for the component 
/// </summary>
public class Player : GameObject
{
    public Player(Texture2D texture) : base(texture)
    {
        this.texture_1 = texture;

        PlayerMovement movement = new PlayerMovement();

        movement.SetGameObject(this);

        AddComponent(movement);

        //tileMap = map.tileMap;
    }

}
/// <summary>
/// Player movement class where we use our player game object reference for movement
/// </summary>
public class PlayerMovement : Component
{
    /// <summary>
    /// 
    /// </summary>
    public void Controller()
    {
        KeyboardState keyState = Keyboard.GetState();
        if (keyState.IsKeyDown(Keys.W))
        {
            gameObject.position.Y -= 1;
        }
        if (keyState.IsKeyDown(Keys.A))
        {
            gameObject.position.X -= 1;
        }
        if (keyState.IsKeyDown(Keys.S))
        {
            gameObject.position.Y += 1;
        }
        if (keyState.IsKeyDown(Keys.D))
        {
            gameObject.position.X += 1;
        }
    }
    /// <summary>
    /// Anything I need for player movement would go here
    /// </summary>
    public override void Start()
    {
        
    }

    /// <summary>
    /// Updating my player position by updating controller
    /// </summary>
    public override void Update()
    {
        Controller();
    }
}

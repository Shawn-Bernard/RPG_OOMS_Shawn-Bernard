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

    /// <summary>
    /// Setting the sprite when a new player is made
    /// </summary>
    /// <param name="texture"></param>
    public Player(Texture2D texture) : base(texture)
    {
        this.Texture_1 = texture;

        PlayerMovement movement = new PlayerMovement();

        movement.SetGameObject(this);

        AddComponent(movement);
    }

}
/// <summary>
/// Player movement class where we use our player game object reference for movement
/// </summary>
public class PlayerMovement : Component
{
    private void Controller()
    {
        KeyboardState keyState = Keyboard.GetState();
        //Giving my direction the same vector2 as my player
        Vector2 Direction = GameObject.Position;
        if (keyState.IsKeyDown(Keys.W))
        {
            Direction.Y -= 1;
        }
        if (keyState.IsKeyDown(Keys.A))
        {
            Direction.X -= 1;
        }
        if (keyState.IsKeyDown(Keys.S))
        {
            Direction.Y += 1;
        }
        if (keyState.IsKeyDown(Keys.D))
        {
            Direction.X += 1;
        }
        // After that we give the value direction to player position
        GameObject.Position = Direction;
    }

    /// <summary>
    /// Overrideing updating my player position by updating controller
    /// </summary>
    public override void Update()
    {
        Controller();
    }
}

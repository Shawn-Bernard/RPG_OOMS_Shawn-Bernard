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
    float Speed = 3;
    private void Controller()
    {
        KeyboardState keyState = Keyboard.GetState();
        //Giving my direction the same vector2 as my player
        Vector2 Direction = GameObject.Position;
        //Make this not read all the time so the movement would be 16 instead of 
        if (keyState.IsKeyUp(Keys.W))
        {
            Direction.Y += Speed;
        }
        if (keyState.IsKeyUp(Keys.A))
        {
            Direction.X += Speed;
        }
        if (keyState.IsKeyUp(Keys.S))
        {
            Direction.Y -= Speed;
        }
        if (keyState.IsKeyUp(Keys.D))
        {
            Direction.X -= Speed;
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

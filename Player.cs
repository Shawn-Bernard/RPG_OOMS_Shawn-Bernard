using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        Position = new Vector2(20, 20);
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
    LoadMap loadMap;
    //int[,]
    public PlayerMovement()
    {
        loadMap = new LoadMap();
        //loadMap.Start();
        
    }
    bool isKeyPressed;
    float Speed = 3;
    private void Controller()
    {
        KeyboardState keyState = Keyboard.GetState();
        //Giving my direction the same vector2 as my player
        Vector2 Direction = GameObject.Position;
        //Make this not read all the time so the movement would be 16 instead of 
        //if (keyState.IsKeyUp(Keys.W))
        if (keyState.IsKeyDown(Keys.W))
        {
            if (!isKeyPressed)
                Checktile(new Vector2(GameObject.Position.X,GameObject.Position.Y -1));

            //Direction.Y += Speed;
        }
        //if (keyState.IsKeyUp(Keys.A))
        if (keyState.IsKeyDown(Keys.A))
        {
            if (!isKeyPressed)
                Checktile(new Vector2(GameObject.Position.X - 1, GameObject.Position.Y));
            //Direction.X += Speed;
        }
        //if (keyState.IsKeyUp(Keys.S))
        if (keyState.IsKeyDown(Keys.S))
        {
            if (!isKeyPressed)
                Checktile(new Vector2(GameObject.Position.X, GameObject.Position.Y + 1));
            //Direction.Y -= Speed;
        }
        //if (keyState.IsKeyUp(Keys.D))
        if (keyState.IsKeyDown(Keys.D))
        {
            if (!isKeyPressed)
                Checktile(new Vector2(GameObject.Position.X +1,GameObject.Position.Y));
            //Direction.X -= Speed;
        }
        else
        {
            isKeyPressed = false;
        }
        // After that we give the value direction to player position
        //GameObject.Position = Direction;
    }
    /*
    void InteractOrMove(Vector2 Direction)
    {
        //If this returns false do these
        if (!MovePlayer(Direction, out LoadMap checkTile))
        {
            //If my check tile is the enemy deal damage to the enemy
            if (checkTile == Enemy.enemy.enemyTile)
            {
            }
            //If my check tile is the weapon tile add 5 to my damage amount
            else if (checkTile == MapGeneration.Map.weaponTile)
            {
            }
            //If my check tile is the heal tile use health system method to heal 
            else if (checkTile == MapGeneration.Map.healTile)
            {// checking the position plus direction and setting that tile to nothing
            }
            //if my check tile is catus tile take damage using health system method
            else if (checkTile == MapGeneration.Map.catusTile)
            {

            }
        }
    }*/

    private void Checktile(Vector2 Direction)
    {
        Debug.WriteLine("Value "+ loadMap.tileMap.ContainsValue(2));
        //Debug.WriteLine($"Value {loadMap.tileMap.ToArray<>} ";
        Debug.WriteLine("Vector " + loadMap.tileMap.ContainsKey(Direction));
        if (loadMap.tileMap.ContainsValue(0))
        {
            GameObject.Position = Direction;
            
        }
        else return;
    }

    /// <summary>
    /// Overrideing updating my player position by updating controller
    /// </summary>
    public override void Update()
    {
        Controller();
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG_OOMS_Shawn_Bernard;
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
        Position = new Vector2(16, 16);
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
    KeyInput WKeyInput;
    KeyInput AKeyInput;
    KeyInput SKeyInput;
    KeyInput DKeyInput;
    public PlayerMovement()
    {
        loadMap = new LoadMap();
        WKeyInput = new KeyInput(Keys.W);
        AKeyInput = new KeyInput(Keys.A);
        SKeyInput = new KeyInput(Keys.S);
        DKeyInput = new KeyInput(Keys.D);
        //loadMap.Start();

    }
    private void Controller()
    {
        //Giving my direction the same vector2 as my player
        Vector2 TargetPosition = GameObject.Position;
        // If my return key state is the key state "pressed" then move
        if (WKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            TargetPosition.Y -= 16;

        }
        if (AKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            TargetPosition.X -= 16;
            //Direction.X += Speed;
        }
        if (SKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            TargetPosition.Y += 16;
        }
        if (DKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            TargetPosition.X += 16;
        }
        

        // After that we give the value direction to player position
        GameObject.Position = TargetPosition;
    }
    
    void InteractOrMove(Vector2 Direction)
    {
        /*
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
        }*/
    }

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
        KeyboardState keyState = Keyboard.GetState();
        Controller();
        WKeyInput.UpdateKey(keyState);
        AKeyInput.UpdateKey(keyState);
        SKeyInput.UpdateKey(keyState);
        DKeyInput.UpdateKey(keyState);

    }
}

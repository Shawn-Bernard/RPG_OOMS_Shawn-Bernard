using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

    Vector2 tilePosition;
    public PlayerMovement()
    {
        
        WKeyInput = new KeyInput(Keys.W);
        AKeyInput = new KeyInput(Keys.A);
        SKeyInput = new KeyInput(Keys.S);
        DKeyInput = new KeyInput(Keys.D);
        //loadMap.Start();
        tilePosition = new Vector2(1, 1);


        //GameObject.Position = tilePosition * 16;
    }
    public override void Start()
    {
        loadMap = new LoadMap();
        //This would be my tile position for checking
        //tilePosition = new Vector2(1, 1);

        //Giving my player position equal to "local tile position" and then * 16 for world space
        GameObject.Position = tilePosition * 16;
    }
    private void Controller()
    {
        //Giving my direction the same vector2 as my player
        Vector2 targetPosition = tilePosition;
        // If my return key state is the key state "pressed" then move
        if (WKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            targetPosition.Y -= 1;
        }
        if (AKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            targetPosition.X -= 1;
        }
        if (SKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            targetPosition.Y += 1;
        }
        if (DKeyInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            targetPosition.X += 1;
        }

        InteractOrMove(targetPosition);
    }
    
    void InteractOrMove(Vector2 targetPosition)
    {
        //Returns a number from check tile method connected to 
        int tile = loadMap.checkTile(targetPosition);
        switch (tile)
        {
            case 0:
                //Wall
                break;
            case 1:
                //Assigning my new target position to tile position
                // example tilePosition (1,1) = targetPosition (2,1)
                tilePosition = targetPosition;
                break;
            case 2:
                //Spawn Point
                tilePosition = targetPosition;
                break;
        }
        // Giving my player position my tile position and * it by pixel position
        GameObject.Position = tilePosition * 16;
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG_OOMS_Shawn_Bernard;
using System;


public class Enemy : Actor//Instead of GameObject this would be maybe public entity : GameObject then enemy : entity
{
    /// <summary>
    /// Setting the up compoenets with each new enemy
    /// </summary>
    /// <param name="texture"></param>
    public Enemy()
    {
        AddComponent(new EnemyMovement());
        AddComponent(new HealthSystem());
        AddComponent(new CombatSystem());
        AddComponent(new HealthSystem());
    }

    public override void TakeTurn()
    {
        GetComponent<EnemyMovement>().Controller();
    }
}

public class EnemyMovement : Component
{
    /// <summary>
    /// This is my grind map vector gonna try and add this into map instead next time
    /// </summary>
    public Vector2 tilePosition; //This needs to be updated to map grind 

    Random rng = new Random();

    private LoadMap map;
    private GameObject mapObject;
    CombatSystem CombatSystem;

    private const int pixelSize = 16; 

    public EnemyMovement()
    {

    }


    public override void Start()
    {
        mapObject = FindGameObject<Map>();
        map = mapObject.GetComponent<LoadMap>();
        CombatSystem = GameObject.GetComponent<CombatSystem>();
        // Position the enemy in the world space
        GameObject.Position = tilePosition * pixelSize;
    }

    public void Controller()
    {
        //Giving my direction the same vector2 as my player
        Vector2 targetPosition = tilePosition;
        //Picking a random int for switch case
        int direction = rng.Next(0, 4);

        switch (direction)
        {
            case 0:// Move up
                targetPosition.Y -= 1;
                break;
            case 1:// Move down
                targetPosition.Y += 1;
                break;
            case 2:// Move left
                targetPosition.X -= 1;
                break;
            case 3:// Move right
                targetPosition.X += 1;
                break;
        }

        // Check if the move is valid, and then move the enemy
        InteractOrMove(targetPosition);
    }

    // Check the target position and move or interact
    void InteractOrMove(Vector2 targetPosition)
    {
        // Gets a int return from the target position
        int tile = map.checkTile(targetPosition);
        switch (tile)
        {
            case 0:// Wall
                break;
            case 1:// Ground 
                tilePosition = targetPosition;
                break;
            case 2:// Spawn
                break;
            case 3:// Player
                tilePosition = targetPosition;
                break;
            case 4:// Enemy
                // Need to move the game object with the int to make this work
                // int not moving with game object
                break;
        }

        // Giving my enemy position my tile position and * it by pixel position
        GameObject.Position = tilePosition * pixelSize;
    }


    public override void Update()
    {
    }
}

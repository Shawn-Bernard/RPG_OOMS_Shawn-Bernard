using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG_OOMS_Shawn_Bernard;

/// <summary>
/// Player Class where we add our components and make an object reference for the component 
/// </summary>
public class Player : Actor//Instead of GameObject this would be maybe public entity : GameObject then Player : entity
{
    /// <summary>
    /// Setting the up compoenets with each new player
    /// </summary>
    /// <param name="texture"></param>
    public Player()
    {
        AddComponent(new PlayerMovement());
        AddComponent(new HealthSystem());


    }

    public override void TakeTurn()
    {

    }


}


/// <summary>
/// Player movement class where we use our player game object reference for movement
/// </summary>
public class PlayerMovement : Component
{
    KeyInput WKeyInput;
    KeyInput AKeyInput;
    KeyInput SKeyInput;
    KeyInput DKeyInput;
    KeyInput SpaceInput;
    /// <summary>
    /// This is my grind map vector gonna try and add this into map instead next time
    /// </summary>
    public Vector2 tilePosition; //This needs to be updated to map grind 

    LoadMap map;
    GameObject MapObject;
    
    CombatSystem CombatSystem;

    int pixelSize = 16;
    public PlayerMovement()
    {
        
        WKeyInput = new KeyInput(Keys.W);
        AKeyInput = new KeyInput(Keys.A);
        SKeyInput = new KeyInput(Keys.S);
        DKeyInput = new KeyInput(Keys.D);
        SpaceInput = new KeyInput(Keys.Space);
    }
    public override void Awake()
    {
        
    }
    public override void Start()
    {
        CombatSystem = GameObject.GetComponent<CombatSystem>();
        MapObject = FindGameObject<Map>();
        map = MapObject.GetComponent<LoadMap>();
        map.MapStyle();
        // Setting the player starts at the correct position
        GameObject.Position = tilePosition * pixelSize;
    }
    public void Controller()
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
        if (SpaceInput.GetKeyState() == KeyInput.keyState.Pressed)
        {
            map.MapStyle();
        }

        InteractOrMove(targetPosition);
    }
    
    void InteractOrMove(Vector2 targetPosition)
    {

        // Gets a int return from the target position
        int tile = map.checkTile(targetPosition);
        switch (tile)
        {
            case 0:// Wall
                break;
            case 1:// Ground
                //Assigning my new target position to tile position
                // example tilePosition (1,1) = targetPosition (2,1)
                tilePosition = targetPosition;
                break;
            case 2:// Exit 
                map.MapStyle();
                //tilePosition = targetPosition;
                break;
            case 3:// Player
                tilePosition = targetPosition;
                break;
            case 4:// Enemy 
                //tilePosition = targetPosition;
                break;
        }
        // Giving my player position my tile position and * it by pixel position
        GameObject.Position = tilePosition * pixelSize;
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
        SpaceInput.UpdateKey(keyState);

    }
}

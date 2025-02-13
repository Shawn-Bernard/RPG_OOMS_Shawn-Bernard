using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Component
{
    public GameObject gameObject;
    /// <summary>
    /// So I can set my object for reference and also start my method 
    /// </summary>
    /// <param name="gameObject"></param>
    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
        Start();
    }

    /// <summary>
    /// So I can throw in anything i need for my methods within in the start
    /// </summary>
    public virtual void Start()
    {

    }

    /// <summary>
    /// So I can threw in any method that needs to be updated within the class
    /// </summary>
    public virtual void Update()
    {

    }

    /// <summary>
    /// Making OnDraw method virtual so I can override to make my map
    /// </summary>
    /// <param name="spriteBatch"></param>
    public virtual void OnDraw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(gameObject.texture_1, gameObject.position, gameObject.color);
    }
}


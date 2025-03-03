using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
/// <summary>
/// This will hold any components logic for methods
/// </summary>
public abstract class Component
{
    private GameObject gameObject;

    public GameObject GameObject { get => gameObject; private set => gameObject = value; }
    /// <summary>
    /// So I can set my object for reference and also start my method 
    /// </summary>
    /// <param name="gameObject"></param>
    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
        //Start();
    }

    /// <summary>
    /// Making these virtaul because abstract will force me to add these, but will need them for some method
    /// </summary>
    public virtual void Start() { }

    /// <summary>
    /// Making these virtaul because abstract will force me to add these, but will need them for some method
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// Making a virtual OnDraw base and overriding for my map
    /// </summary>
    /// <param name="spriteBatch"></param>
    public virtual void OnDraw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(gameObject.Texture_1, gameObject.Position, gameObject.color);
    }
}


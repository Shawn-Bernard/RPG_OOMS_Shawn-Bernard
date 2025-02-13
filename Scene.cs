using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scene
{
    private List<GameObject> gameObject;

    public Scene()
    {
        gameObject = new List<GameObject>();
    }

    public void AddGameObject(GameObject GameObject)
    {
        gameObject.Add(GameObject);
    }

    /// <summary>
    /// Foreach object in our list of gameObjects we draw then each 
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var Object in gameObject)
        {
            Object.DrawObject(spriteBatch);
        }

        spriteBatch.End();
    }
    /// <summary>
    /// This is to update our scene and running through our list of game object and calling the update method for each of them 
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        foreach (var Object in gameObject)
        {
            Object.Update(gameTime);
        }
        return;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOMS_Shawn_Bernard;

public class Enemy : GameObject
{
    /// <summary>
    /// Setting the sprite when a new player is made
    /// </summary>
    /// <param name="texture"></param>
    public Enemy()
    {
        EnemyMovement movement = new EnemyMovement();
        movement.SetGameObject(this);

        AddComponent(movement);
    }
}

public class EnemyMovement: Component
{

}

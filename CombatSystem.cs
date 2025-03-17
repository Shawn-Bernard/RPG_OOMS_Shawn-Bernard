using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOMS_Shawn_Bernard;

public class CombatSystem: Component
{


    GameObject turn;

    public CombatSystem()
    {
    }
    public override void Start()
    {
    }
    /// <summary>
    /// Doesn't work but gonna try add new gameobject that holds this and returns true or false based on player or not
    /// </summary>
    /// <param name="turn"></param>
    public void Turn(GameObject turn)
    {
        //If (turn is player) returns true

        //else would return false
    }

}

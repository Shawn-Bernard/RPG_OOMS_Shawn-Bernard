using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_OOMS_Shawn_Bernard
{
    public abstract class Actor: GameObject
    {
        public ActorManager actorManager;
        public Actor()
        {
            AddComponent(new ActorManager());
            actorManager = GetComponent<ActorManager>();
        }

        public abstract void TakeTurn();


    }

}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RPG_OOMS_Shawn_Bernard
{
    public class TileChecker
    {
        public Dictionary<Vector2, int> tileMap;

        public TileChecker(LoadMap loadMap)
        {
            tileMap = loadMap.tileMap;
        }
        
        public int checkTile(Vector2 checkedPosition)
        {
            // Returning an int based on the checked position
            return tileMap[checkedPosition];
        }
    }
}

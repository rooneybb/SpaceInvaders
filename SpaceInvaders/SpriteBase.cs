using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class SpriteBase : DLink
    {

        

       // public SpriteBase.Name name;
        public float sx;
        public float sy;
        public float angle;
        public SpriteBatchNode sBatNode;

        public abstract void update();

        public abstract void render();



    }
}

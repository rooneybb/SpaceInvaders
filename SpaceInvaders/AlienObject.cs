using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class AlienObject : GameObject
    {
        public enum AlienType
        {
            crab,
            octopus,
            squid,
            grid,
            column,
            uninitialized
        }

        public AlienObject.AlienType aType;

        

        public AlienObject(GameObject.Name name, Sprite.Name spriteName, int index, AlienObject.AlienType aTypeParam)
            : base(name, spriteName, index)
        {
            this.aType = aTypeParam;
           // this.pS = new ProxySprite(sprite);
        }

             
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Ship : GameObject
    {
        public Ship(GameObject.Name nameParam, Sprite.Name spriteName, int index) 
            : base(nameParam, spriteName, index)
        {

        }
    }
}

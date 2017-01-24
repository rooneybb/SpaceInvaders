using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class ShipMissile : GameObject
    {

        public bool shoot;
        
        public ShipMissile(GameObject.Name nameParam, Sprite.Name spriteName, int index, float x, float y)
            : base(nameParam, spriteName, index)
        {
            this.locX = x;
            this.locY = y;
            this.shoot = false;
        }

        public override void update()
        {
            base.update();

            if (this.shoot == true)
            {
                this.sprite.y += 15.0f;                
            }

            
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitShipMissile(this);
        }


        public override void VisitSquid(Squid v)
        {
            CollisionPair.Collide(v, this.pSibling as GameObject);
        }

        public override void VisitOctopus(Octopus v)
        {
            CollisionPair.Collide(v, this.pSibling as GameObject);
        }

    }
}

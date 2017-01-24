using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Octopus : AlienObject
    {
        public Octopus(GameObject.Name name, Sprite.Name sprite, int index, float xParam, float yParam)
            : base(name, sprite, index, AlienObject.AlienType.octopus)
        {
            this.proxyX = xParam;
            this.proxyY = yParam;
        }

        public Octopus(GameObject.Name name, Sprite.Name sprite, int index, float xParam, float yParam, float xParamLoc, float yParamLoc)
            : base(name, sprite, index, AlienObject.AlienType.octopus)
        {
            this.proxyX = xParam;
            this.proxyY = yParam;
            this.locX = xParamLoc;
            this.locY = yParamLoc;
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitOctopus(this);
        }

        public override void VisitShipMissile(ShipMissile v)
        {
            CollisionPair.Collide(v, this.pSibling as GameObject);
        }
    }
}

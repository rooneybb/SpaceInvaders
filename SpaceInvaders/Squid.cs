using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Squid : AlienObject
    {
        public Squid(GameObject.Name name, Sprite.Name sprite, int index, float xParam, float yParam)
            : base(name, sprite, index, AlienObject.AlienType.squid)
        {
            this.proxyX = xParam;
            this.proxyY = yParam;
        }

        public Squid(GameObject.Name name, Sprite.Name sprite, int index, float xParam, float yParam, float xParamLoc, float yParamLoc)
            : base(name, sprite, index, AlienObject.AlienType.squid)
        {
            this.proxyX = xParam;
            this.proxyY = yParam;
            this.locX = xParamLoc;
            this.locY = yParamLoc;
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitSquid(this);
        }

        public override void VisitShipMissile(ShipMissile v)
        {
            CollisionPair.Collide(v, this.pSibling as GameObject);
        }
    }
}

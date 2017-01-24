using System;
using System.Diagnostics;

namespace SpaceInvaders 
{
    public class Column : AlienObject
    {
        public Crab crab;
        public Crab crab2;
        public Squid squid;
        public Octopus octopus;
        public Octopus octopus2;
        public int count;
        
        public Column(GameObject.Name nameParam, Sprite.Name sprName, int indexParam, float x, float y) 
            : base(nameParam, sprName, indexParam, AlienObject.AlienType.column)
        {
            this.locX = x;
            this.locY = y;
            this.index = indexParam;
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitColumn(this);
        }

        public override void VisitMissileRoot(MissileRoot v)
        {
            CollisionPair.Collide(v, this.pChild as GameObject);
        }

       /* public override void VisitShipMissile(ShipMissile v)
        {
            CollisionPair.Collide(v, this.pChild as GameObject);
        } */

        public override void update()
        {
            //update bounding box
            base.update();
        }
    }
}

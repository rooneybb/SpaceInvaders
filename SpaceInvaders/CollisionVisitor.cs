using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionVisitor : PCSNode
    {
        abstract public void accept(CollisionVisitor cVisitor);

        public virtual void VisitCrab(Crab v)
        {
            Debug.WriteLine("Visit by Crab");
        }

        public virtual void VisitOctopus(Octopus v)
        {
            Debug.WriteLine("Visit by Octopus");
        }

        public virtual void VisitSquid(Squid v)
        {
            Debug.WriteLine("Visit by Squid");
        }

        public virtual void VisitGrid(Grid v)
        {
            Debug.WriteLine("Visit by Grid");
        }

        public virtual void VisitShipMissile(ShipMissile v)
        {
            Debug.WriteLine("Visit by ShipMissile");
        }

        public virtual void VisitShipRoot(ShipRoot v)
        {
            Debug.WriteLine("Visit by ShipRoot");
        }

        public virtual void VisitWallLeft(WallLeft v)
        {
            Debug.WriteLine("Visit by VisitWallLeft");
        }

        public virtual void VisitWallRight(WallRight v)
        {
            Debug.WriteLine("Visit by VisitWallRight");
        }

        public virtual void VisitWallObject(WallObject v)
        {
            Debug.WriteLine("Visit by VisitWallLeft");
        }

        public virtual void VisitWallRoot(WallRoot v)
        {
            Debug.WriteLine("Visit by VisitWallRoot");
        }

        public virtual void VisitMissileRoot(MissileRoot v)
        {
            Debug.WriteLine("Visit by MissileRoot");
        }

        public virtual void VisitMissile(Missile v)
        {
            Debug.WriteLine("Visit by Missile");
        }

        public virtual void VisitNullObject(NullObject v)
        {
            Debug.WriteLine("Visit by Null");
        }

        public virtual void VisitColumn(Column v)
        {
            Debug.WriteLine("Visit by Column");
        }

        public virtual void VisitShieldRoot(ShieldRoot v)
        {
            Debug.WriteLine("Visit by ShieldRoot");
        }

        public virtual void VisitShield(Shield v)
        {
            Debug.WriteLine("Visit by Shield");
        }

        public virtual void VisitUFORoot(UFORoot v)
        {
            Debug.WriteLine("Visit by UFORoot");
        }

        public virtual void VisitUFO(UFO v)
        {
            Debug.WriteLine("Visit by UFO");
        }

    }

}

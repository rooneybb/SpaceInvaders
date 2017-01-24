using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionObserver : ColLink
    {
        public abstract void notify();

        public CollisionSubject colSub;
    }
}

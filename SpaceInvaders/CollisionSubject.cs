using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionSubject
    {

        public GameObject gObj1;
        public GameObject gObj2;
        public CollisionObserver colObserverHead;

        public CollisionSubject()
        {
            this.gObj1 = null;
            this.gObj2 = null;
            this.colObserverHead = null;
        }

        public void Attach(CollisionObserver colObserver)
        {
            colObserver.colSub = this;

            if (colObserverHead == null)
            {
                colObserverHead = colObserver;
                colObserver.next = null;
                colObserver.prev = null;
            }
            else
            {
                colObserver.next = colObserverHead;
                colObserverHead.prev = colObserver;
                colObserverHead = colObserver;
            }
        }

        public void notify()
        {
            CollisionObserver cObs = this.colObserverHead;

            while (cObs != null)
            {
                cObs.notify();
                cObs = cObs.next as CollisionObserver;
            }
        }
    }
}

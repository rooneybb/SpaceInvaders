using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPairManager : Manager
    {
        private static CollisionPairManager cpMan = null;
        public CollisionPair temp;
        public CollisionPair colPair;

        private CollisionPairManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as CollisionPair;
            
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (cpMan == null)
            {
                cpMan = new CollisionPairManager(reserveNum, reserveGrow);
                
            }

        }

        public static CollisionPair Add(CollisionPair.Name name, int index, GameObject treeRoot1, GameObject treeRoot2)
        {
            CollisionPairManager cpMan = CollisionPairManager.getInstance();
            CollisionPair cp = cpMan.recycleAdd() as CollisionPair;
            cp.Set(name, index, treeRoot1, treeRoot2);
            return cp;
        }

        public static void remove()
        {
            CollisionPairManager cpMan = CollisionPairManager.getInstance();
            cpMan.recycleRemove();
        }

        public static CollisionPair find(CollisionPair.Name name, int index)
        {
            CollisionPairManager cpMan = CollisionPairManager.getInstance();
            cpMan.temp.name = name;
            Debug.Assert(cpMan.active != null);
            CollisionPair cpLink = cpMan.active as CollisionPair;

            while (cpLink != null)
            {
                if (cpLink.name == cpMan.temp.name)
                {
                    return cpLink;

                }
                cpLink = cpLink.next as CollisionPair;
            }

            return cpLink;
        }

        public static void process()
        {
            CollisionPairManager cpMan = CollisionPairManager.getInstance();

           cpMan.colPair = cpMan.active as CollisionPair;

            while (cpMan.colPair != null)
            {
                cpMan.colPair.Process();
             //   cpMan.colPair.notifyListeners();
                cpMan.colPair = cpMan.colPair.next as CollisionPair;
            }
        }

        public static CollisionPair getColPair()
        {
            CollisionPairManager cpMan = CollisionPairManager.getInstance();
            return cpMan.colPair;
        }

        private static CollisionPairManager getInstance()
        {
            return cpMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new CollisionPair() as CollisionPair;
            return d;
        }
    }
}

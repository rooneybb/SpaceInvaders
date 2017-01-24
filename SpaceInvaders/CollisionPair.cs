using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionPair : DLink
    {
        public enum Name
        {
            Alien_Missile,
            Alien_Wall,
            Alien_Shield,
            Col1_Missile,
            Col2_Missile,
            Col3_Missile,
            Col4_Missile,
            Col5_Missile,
            Col6_Missile,
            Col7_Missile,
            Col8_Missile,
            Col9_Missile,
            Col10_Missile,
            Col11_Missile,
            Missile_Shield,
            Missile_UFO,
            NullObject,
            Uninitialized
        }

        public CollisionPair.Name name;
        public GameObject tree1;
        public GameObject tree2;
        public int index;
        public CollisionSubject colSub;

        public CollisionPair()
        {
            this.name = CollisionPair.Name.Uninitialized;
            this.tree1 = null;
            this.tree2 = null;
            this.index = 0;
        }

        public void Set(CollisionPair.Name colPairNameParam, int indexParam, GameObject gOParam1, GameObject gOParam2)
        {
            this.tree1 = gOParam1;
            this.tree2 = gOParam2;
            this.name = colPairNameParam;
            this.index = indexParam;
            this.colSub = new CollisionSubject();
            this.setCollision(gOParam1, gOParam2);
        }

        public void Process()
        {
            Collide(this.tree1, this.tree2);
        }

        public static void Collide(GameObject safeTree1, GameObject safeTree2) 
        {
            GameObject gObj1 = safeTree1; //grid
            GameObject gObj2 = safeTree2; //child of wallRoot aka wallRight 1 , wallLeft 2

            while (gObj1 != null)
            {
                gObj2 = safeTree2;

                while (gObj2 != null)
                {
                    Debug.WriteLine("ColPair: {0}, {1}", gObj1.name, gObj2.name);
                    CollisionBox colBox1 = gObj1.colObj.colBoxRef;
                    CollisionBox colBox2 = gObj2.colObj.colBoxRef;

                    if (CollisionBox.intersect(colBox1, colBox2))
                    {
                        gObj1.accept(gObj2);
                        CollisionPair temp = CollisionPairManager.getColPair();
                        temp.notifyListeners();
                        break;
                    }

                    gObj2 = gObj2.pSibling as GameObject;
                }

                gObj1 = gObj1.pSibling as GameObject;
            }
        }

        public void attach(CollisionObserver colObs)
        {
            this.colSub.Attach(colObs);  //creates linked list of observers to this colpair.subject
        }

        public void notifyListeners()
        {
            this.colSub.notify(); // walks the list and notifies observers
        }

        public void setCollision(GameObject gObj1Param, GameObject gObj2Param)
        {
            this.colSub.gObj1 = gObj1Param;
            this.colSub.gObj2 = gObj2Param;
        }


    }
}

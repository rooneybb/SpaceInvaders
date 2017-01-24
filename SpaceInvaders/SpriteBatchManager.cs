using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : Manager
    {
        private static SpriteBatchManager sBatMan = null;
        public SpriteBatch sBat;

        private SpriteBatchManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.sBat = this.CreateNode() as SpriteBatch;
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (sBatMan == null)
            {
                sBatMan = new SpriteBatchManager(reserveNum, reserveGrow);
            }

        }

        public static SpriteBatch Add(SpriteBatch.NameSpriteBatch name, int reserveNum = 5, int reserveGrow = 1)
        {
            SpriteBatchManager sBatMan = SpriteBatchManager.getInstance();
            SpriteBatch sBat = sBatMan.recycleAdd() as SpriteBatch;
            sBat.set(name, reserveNum, reserveGrow);
            return sBat;
        }

        public static void remove(SpriteBatch sBat) // Sprite.Name nameParam
        {
            //SpriteBatchManager sBatMan = SpriteBatchManager.getInstance();
           // sBatMan.removeFrontActive();
            //Sprite temp = SpriteManager.find(nameParam);
            Debug.Assert(sBat != null);
            sBat.detach();
        }

        public static void remove(SpriteBatchNode sBatNode)
        {
            Debug.Assert(sBatNode != null);
            SpriteBatch sBat = sBatNode.sBatch;
            Debug.Assert(sBat != null);
            sBat.detach();
        }

        public static SpriteBatch find(SpriteBatch.NameSpriteBatch name)
        {
            SpriteBatchManager sBatMan = SpriteBatchManager.getInstance();
            sBatMan.sBat.name = name;
            Debug.Assert(sBatMan.active != null);
            SpriteBatch sBatLink = sBatMan.active as SpriteBatch;

            while (sBatLink != null)
            {
                if (sBatLink.name == sBatMan.sBat.name)
                {
                    return sBatLink;

                }
                sBatLink = sBatLink.next as SpriteBatch;
            }

            return sBatLink;
        }

      /*  public static void Draw() //implement iterator pattern
        {
            SpriteBatchManager sBatMan = SpriteBatchManager.getInstance();
            SpriteBatch sBatLink = sBatMan.active as SpriteBatch;
            

            while (sBatLink != null)
            {
                sBatLink.draw();
                sBatLink = sBatLink.next as SpriteBatch;
            }
        } */

        public static void Draw()
        {
            SpriteBatchManager sBatMan = SpriteBatchManager.getInstance();
            SpriteBatch sBat = sBatMan.active as SpriteBatch;
            SpriteBatchNode sBatNode; 

            while (sBat != null)
            {
                sBatNode = sBat.active as SpriteBatchNode;

                while (sBatNode != null)
                {
                    sBatNode.sBase.render();
                    sBatNode = sBatNode.next as SpriteBatchNode;
                }

                sBat = sBat.next as SpriteBatch;
            }
        }

        private static SpriteBatchManager getInstance()
        {
            return sBatMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new SpriteBatch() as SpriteBatch;
            return d;
        }

    }
}

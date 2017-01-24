using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectManager : Manager
    {
        private static GameObjectManager gObjMan = null;
        public GameObjectNode gObjNode;
        public PCSTree root;

        private GameObjectManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.gObjNode = this.CreateNode() as GameObjectNode;
            Debug.Assert(this.gObjNode != null);
            this.root = new PCSTree();
            Debug.Assert(this.root != null);
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (gObjMan == null)
            {
                gObjMan = new GameObjectManager(reserveNum, reserveGrow);
            }

        }

        public static GameObjectNode attachTree(GameObject gameObjectParam, PCSTree tree)
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();
            GameObjectNode gONode = gObjMan.recycleAdd() as GameObjectNode;  //only root nodes get added to GobjMan
            gONode.set(gameObjectParam, tree);
            return gONode;
        }

        public static void remove()
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();
            gObjMan.recycleRemove();
        }

        public static void remove(GameObject gObjParam)  //puts gObj as root of tree and then pops off
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();
            GameObject safetyGObj = gObjParam;

            GameObject temp = gObjParam;
            GameObject pRoot = null;
            while (temp != null) 
            {
                pRoot = temp;
                temp = temp.pParent as GameObject;
            }


            GameObjectNode pTree = gObjMan.active as GameObjectNode;

            while (pTree != null)
            {
                if (pTree.gObj == pRoot)
                {
                    break;
                }

                pTree = pTree.next as GameObjectNode;
            }

          //  Debug.Assert(pTree.gObj != null);
            gObjMan.root.SetRoot(pTree.gObj); 
            gObjMan.root.Remove(gObjParam);
            gObjParam.colObj.sBox.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
            
            //gObjParam.colObj.updatePosition(0.0f, 0.0f, 1.0f, 1.0f);

        }

        public static void insert(GameObject gameObjParam, GameObject parent)
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();

            if (parent == null)
            {
                GameObjectManager.attachTree(gameObjParam, null);
            }
            else
            {
                gObjMan.root.SetRoot(parent);
                gObjMan.root.Insert(gameObjParam, parent);
              //  gameObjParam.colObj.sBox.changeColor(1.0f, 0.0f, 0.0f, 1.0f);
            }

        }

        public static void update()
        {

            GameObjectManager gObjMan = GameObjectManager.getInstance();
            GameObjectNode pRoot = gObjMan.active as GameObjectNode;

            int count = 0;

            while (pRoot != null)
            {

                PCSTreeIterator iterator = new PCSTreeIterator(pRoot.gObj);
                GameObject gameObj = iterator.First() as GameObject;

                while (gameObj != null)
                {
                    count++;
                    gameObj.update();
                    gameObj = iterator.Next() as GameObject;
                }

                pRoot = pRoot.next as GameObjectNode;
            }

        }

        public static void removeFromGrid(PCSTree tree)
        {

            GameObject iterator = tree.root as GameObject;
            Debug.Assert(iterator != null);

            while (iterator != null)
            {
                // iterator.locX += 2.0f;
                iterator.pS.locX += 1000.0f;
                iterator.update();
                //  iterator.colObj.updatePosition(iterator.pS.locX, iterator.pS.locY);

                if (iterator.pChild != null)
                {
                    iterator = iterator.pChild as AlienObject;
                    iterator.pS.locX += 1000.0f;
                    iterator.update();
                    //   iterator.colObj.updatePosition(iterator.pS.locX, iterator.pS.locY);
                }

                iterator = iterator.pSibling as AlienObject;

            }


        
          
        }

        public static GameObject Find(GameObject.Name nameParam, int index)
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();
          //  Debug.Assert(nameParam == GameObject.Name.unitialized);
            Debug.Assert(gObjMan.gObjNode != null);
            // Compare functions only compares two Nodes

            GameObject temp = new GameObject(GameObject.Name.unitialized);
            temp.name = nameParam;
            temp.index = index;

            GameObjectNode pRoot = gObjMan.active as GameObjectNode;
            GameObject pGameObj = null;

            bool found = false;
            while (pRoot != null && found == false)
            {
                // OK at this point, I have a Root tree,
                // need to walk the tree completely before moving to next tree
                PCSTreeIterator pIterator = new PCSTreeIterator(pRoot.gObj);

                // Initialize
                pGameObj = pIterator.First() as GameObject;

                while (pGameObj != null)
                {
                    if ((pGameObj.name == temp.name) && (pGameObj.index == temp.index))
                    {
                        found = true;
                        break;
                    }

                    // Advance
                    pGameObj = pIterator.Next() as GameObject;
                }

                // Goto Next tree
                pRoot = pRoot.next as GameObjectNode;
            }

            return pGameObj;
        }


        public static GameObject find2(GameObject.Name nameParam, int indexParam = 0)  //using exmaple method
        {
            GameObjectManager gObjMan = GameObjectManager.getInstance();
            Debug.Assert(gObjMan.gObjNode != null);
            gObjMan.gObjNode.gObj.name = nameParam;
            gObjMan.gObjNode.gObj.index = indexParam;

            GameObjectNode pRoot = gObjMan.active as GameObjectNode;
            GameObject gObj = null;

            bool found = false;

            while (pRoot != null && found == false)
            {
                PCSTreeIterator iterator = new PCSTreeIterator(pRoot.gObj);

                gObj = iterator.First() as GameObject;

                while (gObj != null)
                {
                    if ((gObj.name == gObjMan.gObjNode.gObj.name) && (gObj.index == gObjMan.gObjNode.gObj.index))
                    {
                        found = true;
                        break;
                    }

                    gObj = iterator.Next() as GameObject;
                }

                pRoot = pRoot.next as GameObjectNode;
            }
            return gObj;
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


        private static GameObjectManager getInstance()
        {
            return gObjMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new GameObjectNode() as GameObjectNode;
            Debug.Assert(d != null);
            return d;
        }
    }
}

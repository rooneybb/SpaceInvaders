using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNode : DLink
    {
        public GameObject gObj;
        public PCSTree tree;

        public GameObjectNode()
            : base()
        {
            this.gObj = null;
        }

        public void set(GameObject gameObjectParam)
        {
            this.gObj = gameObjectParam;
        }

        public void set(GameObject gameObjectParam, PCSTree treeParam) //when attached to GObjMan tree root is set in attachtree Method
        {
            this.gObj = gameObjectParam;
            Debug.Assert(this.gObj != null);
            this.tree = treeParam;
            Debug.Assert(this.tree != null);
            this.tree.Insert(this.gObj, null);
        }
    }
}

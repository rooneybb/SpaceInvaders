using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : Container
    {
        public enum NameSpriteBatch
        {
            Aliens,
            Aliens2,
            Aliens3,
            Aliens4,
            Aliens5,
            ProxyAliens,
            Background,
            Boxes,
            Boxes2,
            Ship,
            UFO,
            ShipMissile,
            AliensMissile,
            Walls,
            WallBoxes,
            Columns,
            ColumnBoxes,
            Uninitialized
        }

        public SpriteBatch.NameSpriteBatch name;

        public SpriteBatch(int reserveNum = 12, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.reserveNum = reserveNum;
            this.reserveGrow = reserveGrow;
        }

        public void draw()  //need to call update / and update function
        {
            SpriteBatchNode sBatNode = this.active as SpriteBatchNode;

            while(sBatNode != null)
            {
                sBatNode.sBase.render();
                sBatNode = sBatNode.next as SpriteBatchNode;
            }
        }

        public void attach(Sprite sBase)
        {
           // Debug.Assert(sBaseName != null);
            SpriteBatchNode sBatNode = this.recycleAdd() as SpriteBatchNode;
            sBatNode.set(sBase, this);
        }

        public void attach(ProxySprite pSBase)
        {
            // Debug.Assert(sBaseName != null);
            SpriteBatchNode sBatNode = this.recycleAdd() as SpriteBatchNode;
            sBatNode.set(pSBase, this);
        }

        public void attach(SpriteBox sBoxBase)
        {
            // Debug.Assert(sBaseName != null);
            SpriteBatchNode sBatNode = this.recycleAdd() as SpriteBatchNode;
            sBatNode.set(sBoxBase, this);
        }

        public void detach()
        {
            // Debug.Assert(sBaseName != null);
            this.recycleRemove();
           // sBatNode.set(sBase);
        }


        protected override CLink CreateNode()
        {
            SpriteBatchNode sBatNode = new SpriteBatchNode();
            return sBatNode;
        }

        public void set(SpriteBatch.NameSpriteBatch name, int reserveNum, int reserveGrow)
        {
            this.name = name;
            this.reserveNum = reserveNum;
            this.reserveGrow = reserveGrow;

        }
    }
}

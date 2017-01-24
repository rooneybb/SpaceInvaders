using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Grid : AlienObject
    {

        public float xDelta;
        public float yDelta;
        private float total;
        public float iteratorDelta;
        public PCSTree pcsTree;
        public bool moveDown;
        //public PCSNode root;
       

        public Grid(GameObject.Name name, Sprite.Name spriteNameParam, int index, float xParam, float yParam)
            : base(name, spriteNameParam, index, AlienObject.AlienType.grid)
        {
            this.locX = xParam;
            this.locY = yParam;
          //  this.sprite = SpriteManager.find(spriteNameParam);
            this.proxyX = this.sprite.image.azulRect.x;
            this.proxyY = this.sprite.image.azulRect.y;
            this.xDelta = 2.0f;
            this.yDelta = 25.0f;
            this.iteratorDelta = 2.0f;
            // this.yDelta = 100.0f;
            this.total = 0.0f;
           this.pcsTree = new PCSTree();
           
        }

        public Grid(GameObject.Name name, Sprite.Name spriteNameParam, int index, float xParam, float yParam, SpriteBatch sBatParam)
            : base(name, spriteNameParam, index, AlienObject.AlienType.grid)
        {
            this.locX = xParam;
            this.locY = yParam;
            //this.sprite = SpriteManager.find(spriteNameParam);
            this.proxyX = this.sprite.image.azulRect.x;
            this.proxyY = this.sprite.image.azulRect.y;
            this.xDelta = 5.0f;
            this.yDelta = 25.0f;
            this.iteratorDelta = 2.0f;
            // this.yDelta = 100.0f;
            this.total = 0.0f;
            this.pcsTree = new PCSTree();
            this.ActivateSprite(sBatParam, this.locX, this.locY);
            this.colObj = new CollisionObject(this.sprite, this.index);
            sBatParam.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.locX, this.locY);
        }

        public override void update()
        {
            
            base.update();
            this.updateBoundingBox();
        }

        public void updateBoundingBox()
        {
            /* AlienObject iterator = this;
             Debug.Assert(iterator != null);
             CollisionBox cBox = this.colObj.colBoxRef;
             Debug.Assert(cBox != null);
             Grid gridTemp = this;
             Grid gridChild = gridTemp.pChild as Grid;
             GameObject gObjTemp = gridChild as GameObject;
             cBox.Set(gObjTemp.colObj.colBoxRef);

             while (iterator != null)
             {
                 gObjTemp = iterator as AlienObject;
                 cBox.Union(gObjTemp.colObj.colBoxRef);

       /*          if (iterator.pChild != null)
                 {
                     iterator = iterator.pChild as AlienObject;
                    
                 } 


                 iterator = iterator.pSibling as AlienObject;

                 this.locX = this.colObj.colBoxRef.locX;
                 this.locY = this.colObj.colBoxRef.locY;  

             }*/

            PCSNode pcsNode = this as PCSNode;
            pcsNode = pcsNode.pChild;
            GameObject gObj = pcsNode as GameObject;
            CollisionBox ColTotal = this.colObj.colBoxRef;
            ColTotal.Set(gObj.colObj.colBoxRef);

            while (pcsNode != null)
            {
                gObj = (GameObject)pcsNode;
                ColTotal.Union(gObj.colObj.colBoxRef);

                pcsNode = pcsNode.pSibling;
            }
            this.locX = this.colObj.colBoxRef.x;
            this.locY = this.colObj.colBoxRef.y;

        }

        public void moveGrid()
        {
            PCSTreeIterator iterator = new PCSTreeIterator(this);
            Debug.Assert(iterator != null);
            PCSNode pcsNode = iterator.First();

            while (pcsNode != null)
            {
                GameObject gameObj = pcsNode as GameObject;
                gameObj.locX += this.xDelta;
                

              /*  if (gameObj.locX < 55 || gameObj.locX > 841)
                {
                    gameObj.locY -= this.yDelta;
                } */
                pcsNode = iterator.Next();
            }

            this.total += this.xDelta;

            if (this.total >= 400.0f || this.total >= 0.0f)
            {
                this.xDelta *= -1.0f;
                

            }
        }

        public void moveGrid2(PCSTree tree)
        {
            
            AlienObject iterator = tree.root as AlienObject;
            Debug.Assert(iterator != null);
            this.total += this.iteratorDelta;

            while (iterator != null)
            {
                // iterator.locX += 2.0f;
                
                
                iterator.pS.locX += this.xDelta;

                
              //  iterator.pS.locY = iterator.pS.locY - this.yDelta;
                //iterator.pS.locY = this.yDelta;
               // iterator.pS.locY = iterator.pS.locY - this.yDelta;
                iterator.update();
                //SoundManager.playFile("fastinvader4.wav");
              //  iterator.colObj.updatePosition(iterator.pS.locX, iterator.pS.locY);

                if (iterator.pChild != null)
                {
                    iterator = iterator.pChild as AlienObject;
                    iterator.pS.locX += this.xDelta;
                  //  iterator.pS.locY = iterator.pS.locY - this.yDelta;
                    iterator.update();

                   // SoundManager.playFile("fastinvader4.wav");
                 //   iterator.colObj.updatePosition(iterator.pS.locX, iterator.pS.locY);
                }

                if (this.moveDown == true)
                {
                    iterator.pS.locY = iterator.pS.locY - this.yDelta;
                    iterator.update();

                    if (iterator.pSibling == null)
                    {
                        this.moveDown = false;
                    }
                    
                    //     SoundManager.playFile("fastinvader4.wav");
                    // SoundManager.playFile("fastinvader4.wav");
                    //    iterator.colObj.updatePosition(iterator.pS.locX, iterator.pS.locY);
                }
                
                

                
                iterator = iterator.pSibling as AlienObject;
                

            }
                
            
            /*    if (this.total >= 200.0f || this.total <= 0.0f)
                {
                   // this.xDelta *= -1.0f;
                 //  this.iteratorDelta *= -1.0f;
                    //SoundManager.playFile("fastinvader4.wav");
                } */
                
            
            
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitGrid(this);
        }

        public override void VisitWallRoot(WallRoot v)
        {
            CollisionPair.Collide(this, v.pChild as GameObject);
        }
       
        




    }
}

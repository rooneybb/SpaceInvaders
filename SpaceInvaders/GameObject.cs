using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public  class GameObject : CollisionVisitor
    {
        public enum Name
        {
            crab,
            crab2,
            squid,
            octopus,
            octopus2,
            grid,
            column,
            nullRoot,
            ship,
            alienMissile,
            shipMissile,
            shipRoot,
            shield,
            wallRoot,
            wallLeft,
            wallRight,
            wallBottom,
            ufo,
            unitialized
        }

        public GameObject.Name name;
        public int index;
        public float proxyX;
        public float proxyY;
        public float locX;
        public float locY;
        public Sprite.Name sprName;
        public Sprite sprite;
        public ProxySprite pS;
        public CollisionObject colObj;
        public SpriteBatch sBat;

        public GameObject(GameObject.Name nameParam)  // use this for grid
        {
            this.name = nameParam;
            this.index = 0;
            this.proxyX = 0.0f;
            this.proxyY = 0.0f;
            this.locX = 0.0f;
            this.locY = 0.0f;
            this.pS = null;
            this.sprite = null;
        }

        public GameObject(GameObject.Name nameParam, Sprite.Name sParam, int indexParam) //int indexSiblingParam, int indexChildParam
        {
            this.name = nameParam;
            this.index = indexParam;
            this.proxyX = 0.0f;
            this.proxyY = 0.0f;
            this.locX = 0.0f;
            this.locY = 0.0f;
            this.sprName = sParam;
            this.sprite = SpriteManager.find(sParam);
            Debug.Assert(this.sprite != null);
            this.pS = null;
  
        }
        
        public void ActivateSprite(SpriteBatch sBat)
        {
            sBat.attach(this.sprite);
            Debug.Assert(sBat != null);
        }

        public void ActivateSprite(SpriteBatch sBat, float proxyX, float proxyY)
        {
            ProxySpriteManager.Add(this.sprName, proxyX, proxyY);
            this.pS = ProxySpriteManager.find(ProxySprite.Name.alienProxy);
            sBat.attach(this.pS);
            Debug.Assert(sBat != null);
        }

        public void ActivateSprite(SpriteBatch sBat, float proxyX, float proxyY, float locXParam, float locYParam)
        {
            ProxySpriteManager.Add(this.sprName, proxyX, proxyY);
            this.pS = ProxySpriteManager.find(ProxySprite.Name.alienProxy);
            this.pS.locX = locXParam;
            this.pS.locY = locYParam;
            sBat.attach(this.pS);
            //this.pS.setSpriteBatchNode()
            Debug.Assert(sBat != null);
        }

        public void ActivateColBox(SpriteBatch sBat)
        {
            if (this.pS != null)
            {
                
                this.colObj = new CollisionObject(this.pS.sprite, this.index);
                sBat.attach(this.colObj.sBox);
                this.colObj.updatePosition(this.pS.locX, this.pS.locY);
            }

            this.colObj = new CollisionObject(this.sprite, this.index);
            sBat.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.sprite.x, this.sprite.y);

            
            
        }

        public override int getIndex()
        {
            return this.index;
        }

        public override Enum getName()
        {
            return this.name;
        }

        public void remove()
        {
            Debug.Assert(this.pS != null);
            SpriteBatchNode sBatNode = this.pS.sBatNode;
            Debug.Assert(this.pS.sBatNode != null);
            SpriteBatchManager.remove(sBatNode);
            GameObjectManager.remove(this);
        }

        public virtual void update()
        {


            if (this.colObj != null)
            {
                if (this.pS != null)
                {
                    this.pS.update();
                    Debug.Assert(this.colObj != null);
                    this.colObj.updatePosition(this.pS.locX, this.pS.locY);
                    //this.colObj.sBox.update();
                }

                else
                {
                    Debug.Assert(this.sprite != null);
                    this.sprite.update();
                    this.colObj.updatePosition(this.sprite.x, this.sprite.y);
                    //  this.colObj.sBox.update();
                }
            }

            if (this.pS != null)
            {
                this.pS.update();
               
                //this.colObj.sBox.update();
            }

            else
            {
                Debug.Assert(this.sprite != null);
                this.sprite.update();
 
            }

        
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            throw new NotImplementedException();
        }

    }
}

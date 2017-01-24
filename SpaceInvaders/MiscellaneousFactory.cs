using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class MiscellaneousFactory
    {
        public SpriteBatch sBat;
        //public SpriteBatch boxBatch;
        public GameObject parent;
        public GameObject newParent;
        public PCSTree tree;

        public MiscellaneousFactory(SpriteBatch sBatParam, PCSTree treeParam, GameObject parentParam)
        {
            this.sBat = sBatParam;
            this.tree = treeParam;
            this.parent = parentParam;

        }

            public void setParent(GameObject newParentParam) 
        {
            this.newParent = newParentParam;
        }

        public GameObject createMisc(GameObject.Name gObjName, Sprite.Name sprName, Image.NameImage imgName, SpriteBatch boxBatchParam, float locX, float locY, float widthX, float heightY, int index)
        {
            GameObject misc = null;  
            SpriteManager.Add(sprName, imgName, locX, locY, widthX, heightY);
            Sprite temp = SpriteManager.find(sprName);

            switch (gObjName)
            {
                case GameObject.Name.ship:
                    misc = new Ship(GameObject.Name.ship, Sprite.Name.Ship, index);
                    GameObjectManager.insert(misc, this.parent);
                    misc.ActivateSprite(this.sBat);
                    misc.colObj = new CollisionObject(misc.sprite, misc.index);
                    boxBatchParam.attach(misc.colObj.sBox);
                    misc.colObj.updatePosition(misc.sprite.x, misc.sprite.y);
                    break;

                case GameObject.Name.shipMissile:
                    misc = new ShipMissile(GameObject.Name.shipMissile, Sprite.Name.ShipMissile, index, locX, locY);
                    GameObjectManager.insert(misc, this.parent);
                    misc.ActivateSprite(this.sBat);
                    misc.colObj = new CollisionObject(misc.sprite, misc.index);
                    boxBatchParam.attach(misc.colObj.sBox);
                    misc.colObj.updatePosition(misc.sprite.x, misc.sprite.y);
                    break;

                case GameObject.Name.wallRight:
                    misc = new WallRight(GameObject.Name.wallRight, Sprite.Name.NullRoot, index, locX, locY, widthX, heightY, this.sBat);
                    GameObjectManager.insert(misc, this.parent);
                    misc.ActivateSprite(this.sBat);
                    misc.colObj = new CollisionObject(misc.sprite, misc.index);
                    boxBatchParam.attach(misc.colObj.sBox);
                    misc.colObj.updatePosition(misc.sprite.x, misc.sprite.y);
                    break;

                default:
                    Debug.Assert(false);
                    break;

            }
            
            
            return misc;
        }
    }
}

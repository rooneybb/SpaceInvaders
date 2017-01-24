using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        public SpriteBatch sBat;
        //public SpriteBatch boxBatch;
        public GameObject parent;
        public GameObject newParent;
        public PCSTree tree;
        
        
        public AlienFactory(SpriteBatch sBatParam, GameObjectNode gObjNodeParam)
        {
            this.sBat = sBatParam;
            this.tree = gObjNodeParam.tree;
            this.parent = gObjNodeParam.gObj;
          //  this.newParent = new GameObject();
        }

        public void setParent(GameObject newParentParam) 
        {
            this.newParent = newParentParam;
        }


        public AlienObject createAlien(AlienObject.AlienType aType, GameObject.Name gObjName, Sprite.Name sprName, Image.NameImage imgName, SpriteBatch boxBatchParam, float proxyX, float proxyY, float locX, float locY, int index)
        {
            AlienObject alien = null;
           // Sprite tempAlien;
            
         //   CollisionObject colObj;

            switch (aType)
            {
                case AlienObject.AlienType.crab:
                    SpriteManager.Add(sprName, imgName, locX, locY, 25.0f, 50.0f);
                   // tempAlien = SpriteManager.find(sprName);
                    alien = new Crab(gObjName, sprName, index, proxyX, proxyY, locX, locY);
                    GameObjectManager.insert(alien, this.parent);
                    alien.ActivateSprite(this.sBat, proxyX, proxyY, locX, locY);
                    alien.colObj = new CollisionObject(alien.pS.sprite, alien.index);
                    boxBatchParam.attach(alien.colObj.sBox);
                    alien.colObj.updatePosition(alien.pS.locX, alien.pS.locY);
                     break;

                case AlienObject.AlienType.octopus:
                    SpriteManager.Add(sprName, imgName, locX, locY, 25.0f, 50.0f);
                  //  Sprite tempAlien = SpriteManager.find(sprName);
                     alien = new Octopus(gObjName, sprName, index, proxyX, proxyY, locX, locY);
                     GameObjectManager.insert(alien, this.parent);    
                //this.tree.Insert(alien, this.parent);
                    alien.ActivateSprite(this.sBat, proxyX, proxyY, locX, locY);
                    alien.colObj = new CollisionObject(alien.pS.sprite, alien.index);
                    boxBatchParam.attach(alien.colObj.sBox);
                    alien.colObj.updatePosition(alien.pS.locX, alien.pS.locY);
                     break;

                case AlienObject.AlienType.squid:
                    SpriteManager.Add(sprName, imgName, locX, locY, 25.0f, 50.0f);
                //    Sprite tempAlien = SpriteManager.find(sprName);
                     alien = new Squid(gObjName, sprName, index, proxyX, proxyY, locX, locY);
                     GameObjectManager.insert(alien, this.parent);    
                //this.tree.Insert(alien, this.parent);
                    alien.ActivateSprite(this.sBat, proxyX, proxyY, locX, locY);
                    alien.colObj = new CollisionObject(alien.pS.sprite, alien.index);
                    boxBatchParam.attach(alien.colObj.sBox);
                    alien.colObj.updatePosition(alien.pS.locX, alien.pS.locY);
                     break;

                case AlienObject.AlienType.grid:
                    SpriteManager.Add(sprName, imgName, locX, locY, 25.0f, 50.0f);
               //     Sprite tempAlien = SpriteManager.find(sprName);
                    alien = new Grid(gObjName, sprName, index, locX, locY);
                    GameObjectManager.attachTree(alien, this.tree);
                    alien.ActivateSprite(this.sBat, proxyX, proxyY);
                    alien.colObj = new CollisionObject(alien.pS.sprite, alien.index);
                    boxBatchParam.attach(alien.colObj.sBox);
                    alien.colObj.updatePosition(alien.pS.locX, alien.pS.locY);
                    break;

                case AlienObject.AlienType.column:
                    SpriteManager.Add(sprName, imgName, locX, locY, 25.0f, 250.0f);
                    alien = new Column(GameObject.Name.column, Sprite.Name.NullColumn, index, locX, locY);
                    GameObjectManager.insert(alien, this.parent);
                    alien.ActivateSprite(this.sBat, proxyX, proxyY);
                    alien.colObj = new CollisionObject(alien.sprite, alien.index);
                    boxBatchParam.attach(alien.colObj.sBox);
                    alien.colObj.updatePosition(alien.sprite.x, alien.sprite.y);
                    this.setParent(alien);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            
            return alien;
            // return this.alien;
        }



    }
}

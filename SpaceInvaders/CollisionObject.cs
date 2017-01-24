using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionObject
    {
        public CollisionBox colBoxRef;
        public SpriteBox sBox;
        public int index;
        //public Sprite spr;
      //  public ProxySprite pSpr;
       // public SpriteBatch sBat;


        public CollisionObject(ProxySprite pSpriteParam, int indexParam)
        {
            
            this.colBoxRef = new CollisionBox(pSpriteParam.sprite.x, pSpriteParam.sprite.y, pSpriteParam.sprite.sx, pSpriteParam.sprite.sy);
            this.sBox = SpriteBoxManager.Add(SpriteBox.Name.CollisionBox, pSpriteParam.sprite.x, pSpriteParam.sprite.y, pSpriteParam.sprite.sx, pSpriteParam.sprite.sy);
            this.index = indexParam;
        }

        public CollisionObject(Sprite spriteParam, int indexParam)
        {
            this.colBoxRef = new CollisionBox(spriteParam.screenRect);
            this.sBox = SpriteBoxManager.Add(SpriteBox.Name.CollisionBox, new Azul.Rect(spriteParam.x, spriteParam.y, spriteParam.sx, spriteParam.sy));
            this.index = indexParam;
        }


        public void updatePosition(Sprite spr)
        {
            this.colBoxRef.locY = spr.x;
            this.colBoxRef.locY = spr.y;

            this.sBox.x = this.colBoxRef.locX;
            this.sBox.y = this.colBoxRef.locY;

            this.sBox.set(SpriteBox.Name.CollisionBox, new Azul.Rect(this.colBoxRef.locX, this.colBoxRef.locY, this.colBoxRef.widthX, this.colBoxRef.heightY));
            this.sBox.update();
        }

        public void updatePosition(ProxySprite pSpr)
        {

            this.colBoxRef.locX = pSpr.sprite.x;
            this.colBoxRef.locY = pSpr.sprite.y;

            this.sBox.azulSpriteBox.x = this.colBoxRef.locX;
            this.sBox.azulSpriteBox.y = this.colBoxRef.locY;
            this.sBox.set(SpriteBox.Name.CollisionBox, new Azul.Rect(this.colBoxRef.locX, this.colBoxRef.locY, this.colBoxRef.widthX, this.colBoxRef.heightY));
               
                this.sBox.update();
            
        }

        public void updatePosition(float x, float y)
        {
            this.colBoxRef.locX = x;
            this.colBoxRef.locY = y;

            this.sBox.x = this.colBoxRef.locX;
            this.sBox.y = this.colBoxRef.locY;

            this.sBox.set(SpriteBox.Name.CollisionBox, new Azul.Rect(this.colBoxRef.locX, this.colBoxRef.locY, this.colBoxRef.widthX, this.colBoxRef.heightY));
            Debug.Assert(this.sBox != null);
            this.sBox.update();
        }

        public void updatePosition(float x, float y, float sx, float sy)
        {
            this.colBoxRef.locX = x;
            this.colBoxRef.locY = y;
            this.colBoxRef.widthX = sx;
            this.colBoxRef.heightY = sy;
           // this.colBoxRef.update();
        }
    }
}

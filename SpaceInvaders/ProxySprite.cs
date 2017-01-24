using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ProxySprite : SpriteBase
    {
        public enum Name
        {
            alienProxy,
            crabProxy,
            octopusProxy,
            squidProxy,
            missileProxy,
            nullProxy,
            uninitialized
        }

        public ProxySprite.Name name;
        public Sprite sprite;
        public Azul.Color azulColor;
        public float x;
        public float y;
        public float origX;
        public float origY;
        public float locX;
        public float locY;
        public int count;

        public ProxySprite()
            : base()
        {
            this.name = ProxySprite.Name.uninitialized;
            this.sprite = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.origX = 0.0f;
            this.origY = 0.0f;
            this.locX = 0.0f;
            this.locY = 0.0f;
            this.azulColor = new Azul.Color(0.0f, 1.0f, 0.0f);
        }

        public ProxySprite(Sprite.Name spriteNameParam)
            : base()
        {
            this.name = ProxySprite.Name.alienProxy;
            this.sprite = SpriteManager.find(spriteNameParam);
            Debug.Assert(this.sprite != null);
            this.x = 0.0f;
            this.y = 0.0f;
            this.origX = this.sprite.image.azulRect.x;
            this.origY = this.sprite.image.azulRect.y;
            this.locX = this.sprite.azulSprite.x;
            this.locY = this.sprite.azulSprite.y;
            this.azulColor = new Azul.Color(0.0f, 1.0f, 0.0f);
        }

        public void set(Sprite.Name spriteNameParam, float x, float y)
        {
            this.name = ProxySprite.Name.alienProxy;
            this.sprite = SpriteManager.find(spriteNameParam);
            Debug.Assert(this.sprite != null);
            this.x = x;
            this.y = y;
            this.origX = this.sprite.image.azulRect.x;
            this.origY = this.sprite.image.azulRect.y;
            this.locX = this.sprite.azulSprite.x;
            this.locY = this.sprite.azulSprite.y;
            this.azulColor = this.sprite.azulColor;

        }

        override public void update()
        {

            this.sprite.azulSprite.x = locX;
            this.sprite.azulSprite.y = locY;
            this.sprite.azulSprite.Update();
            //this.sprite.azulSprite.x = this.x;
            //this.sprite.azulSprite.y = this.y;
            count += 1;

            if (count % 100 == 0)
            {
                
                this.sprite.azulSprite.SwapTextureRect(new Azul.Rect(this.x, this.y, this.sprite.image.azulRect.width, this.sprite.image.azulRect.height));
                this.sprite.azulSprite.Update();
                //squidProxy.resetImage();
                // squidProxy.update();
            }

            if (count % 200 == 0)
            {
                this.resetImage();
            }

            
            
            //this.sprite.azulSprite.Update();
            //this.resetImage();
        }



        public void switchSpriteImage()
        {
            this.sprite.x = this.x;
            this.sprite.y = this.y;
        }

        public void resetImage()
        {

            this.sprite.azulSprite.SwapTextureRect(new Azul.Rect(this.origX, this.origY, this.sprite.image.azulRect.width, this.sprite.image.azulRect.height));
            this.sprite.azulSprite.Update();
        }

        override public void render()
        {
            //this.switchSpriteImage();
            this.sprite.azulSprite.Render();
     
        }
    }
}

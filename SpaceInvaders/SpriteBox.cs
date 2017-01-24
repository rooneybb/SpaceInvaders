using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBox : SpriteBase
    {

        public enum Name
        {
            Box1,
            Box2,
            Box3,
            CollisionBox,
            NullBox,
            Uninitialized
        } 

        public SpriteBox.Name name;
        public Azul.SpriteBox azulSpriteBox;
        public Azul.Color azulColor;
        public Azul.Rect screenRect;
        public float x;
        public float y;


        public SpriteBox(SpriteBox.Name sprBoxName, Azul.Rect screenRectParam)
            : base()
        {
            this.name = sprBoxName;
            this.screenRect = new Azul.Rect(screenRectParam);
            this.azulColor = new Azul.Color(1.0f, 1.0f, 0.0f, 1.0f);
        }

        public SpriteBox()
            : base()
        {
            this.name = SpriteBox.Name.Uninitialized;
            this.screenRect = null;
            this.azulColor = new Azul.Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        public void set(SpriteBox.Name sprBoxName, Azul.Rect screenRectParam)
        {
            this.name = sprBoxName;
            this.screenRect = screenRectParam;
            Debug.Assert(this.screenRect != null);
            this.azulColor = new Azul.Color(1.0f, 0.0f, 0.0f, 1.0f);
            this.azulSpriteBox = new Azul.SpriteBox(this.screenRect, this.azulColor);
            Debug.Assert(this.azulSpriteBox != null);
            this.x = this.azulSpriteBox.x;
            this.y = this.azulSpriteBox.y;
            this.sx = this.azulSpriteBox.sx;
            this.sy = this.azulSpriteBox.sy;

        }

        

        public void changeColor(float red, float green, float blue, float alpha)
        {
            this.azulSpriteBox.SwapColor(new Azul.Color(red, green, blue, alpha));

        }

        public override void update()
        {
            this.azulSpriteBox.x = this.x;
            this.azulSpriteBox.y = this.y;
            this.azulSpriteBox.sx = this.sx;
            this.azulSpriteBox.sy = this.sy;
            this.azulSpriteBox.angle = this.angle;
            this.azulSpriteBox.Update();

        }

        public override void render()
        {
            this.azulSpriteBox.Render();
        }


    }
}

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile : GameObject
    {
        public bool hit;
        
        public Missile(GameObject.Name nameParam, Sprite.Name spriteName, int index, float x, float y, SpriteBatch sBatCol)
            : base(nameParam, spriteName, index)
        {
            this.locX = x;
            this.locY = y;
            this.hit = false;
            this.colObj = new CollisionObject(this.sprite, this.index);
            sBatCol.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.locX, this.locY);
        }

        public override void update()
        {
            base.update();

            if (!hit)
            {
                this.sprite.y -= 5.0f;
                
                if (this.sprite.y < 0.0f)
                {
                    this.sprite.y = 600.0f;
                }
            }
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitMissile(this);
        }
    }
}

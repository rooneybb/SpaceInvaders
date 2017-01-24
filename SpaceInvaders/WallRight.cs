using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRight : GameObject
    {
        public WallRight(GameObject.Name gOName, Sprite.Name sprName, int index, float x, float y, float sx, float sy, SpriteBatch sBatCol)
            : base(gOName, sprName, index)
        {
            this.locX = x;
            this.locY = y;
            this.colObj = new CollisionObject(this.sprite, this.index);
            sBatCol.attach(this.colObj.sBox);
            this.colObj.sBox.sx = sx;
            this.colObj.sBox.sy = sy;
            this.colObj.updatePosition(this.locX, this.locY);
        }

        public override void update()
        {
            base.update();
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitWallRight(this);
        }
    }
}

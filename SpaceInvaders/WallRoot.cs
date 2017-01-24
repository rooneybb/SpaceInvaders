using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRoot : GameObject
    {
        
        public WallRoot(GameObject.Name gOName, Sprite.Name sprName, int index, float x, float y, float sx, float sy, SpriteBatch sBatCol)
            : base(gOName, sprName, index)
        {
            this.locX = x;
            this.locY = y;
            this.colObj = new CollisionObject(this.sprite, this.index);
            sBatCol.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.locX, this.locY);

        }

      /*  public override void update()
        {
            base.update();
        } */
         
        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitWallRoot(this);
        }
    }
}

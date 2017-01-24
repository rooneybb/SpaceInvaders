using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class WallLeft : GameObject
    {
        public WallLeft(GameObject.Name gOName, Sprite.Name sprName, int index, float x, float y, float sx, float sy, SpriteBatch sBatCol)
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
            cVisitor.VisitWallLeft(this);
        }

    }
}

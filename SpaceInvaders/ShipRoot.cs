﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRoot : GameObject
    {
        public ShipRoot(GameObject.Name nameParam, Sprite.Name spriteName, int index, float x, float y, SpriteBatch sBatCol)
            : base(nameParam, spriteName, index)
        {
            this.locX = x;
            this.locY = y;
            this.colObj = new CollisionObject(this.sprite, this.index);
            sBatCol.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.locX, this.locY);
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitShipRoot(this);
        }
    }
}
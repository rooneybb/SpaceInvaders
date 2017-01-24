using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallObject : GameObject
    {
        public enum WallType
        {
            top,
            bottom,
            left, 
            right,
            root,
            unitialized
        }

        public WallObject.WallType wallType;

        public WallObject(GameObject.Name gOName, Sprite.Name sprName, WallObject.WallType wallTypeParam, int index)
            : base(gOName, sprName, index)
        {
            this.wallType = wallTypeParam;
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitWallObject(this);
        }
    }
}

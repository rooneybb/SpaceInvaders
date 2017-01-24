using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    public class NullObject : GameObject
    {
        public NullObject()
            : base(GameObject.Name.nullRoot, Sprite.Name.NullRoot, 0)
        {

        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitNullObject(this);
        }
    }
}

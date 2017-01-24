using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InObsMoveLeft : InputObserver
    {
        public override void Notify()
        {
            Ship temp = GameObjectManager.Find(GameObject.Name.ship, 1) as Ship;
            Debug.Assert(temp != null);
            temp.sprite.x -= 10.0f;
            Debug.WriteLine("Left");
        }
    }
}

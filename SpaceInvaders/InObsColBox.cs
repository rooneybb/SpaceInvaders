using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class InObsColBox : InputObserver
    {
        public override void Notify()
        {
            Debug.WriteLine("Collision Boxes On");
        }
    }
}

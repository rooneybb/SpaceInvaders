using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    abstract class InputObserver : ColLink
    {
        public InputSubject subject;
        
        abstract public void Notify();

    }
}

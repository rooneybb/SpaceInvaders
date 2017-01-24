using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Iterator
    {
        public abstract PCSNode First();
        public abstract PCSNode Next();
        public abstract PCSNode CurrentItem();
        public abstract bool IsDone();
    }
}

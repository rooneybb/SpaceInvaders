using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLink
    {
        
        public enum DLinkStatus  //taken from DLink example
        {
            Active,
            Reserve,
            Uninitialized
        }

        public DLink next;
        public DLink prev;
        public float delta;
        public DLinkStatus status;

        public DLink() //each new DLink has no attachments, those are added through Manager methods
        {
            this.Clear();
        }

        public void Clear()  //erases all DLink attachments
        {
            this.next = null;
            this.prev = null;
            this.status = DLinkStatus.Uninitialized;
        }
    }
}

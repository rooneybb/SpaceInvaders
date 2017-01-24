using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    public class ColLink
    {
        public enum ColLinkStatus
        {
            Active, 
            Reserve,
            Unitialized
        }

        public ColLink next;
        public ColLink prev;
        public ColLink.ColLinkStatus status;

        public ColLink()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.next = null;
            this.prev = null;
            this.status = ColLinkStatus.Unitialized;
        }
    }
}

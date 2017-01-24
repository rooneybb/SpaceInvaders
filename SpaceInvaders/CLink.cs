using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class CLink
    {
        public enum CLinkStatus  //taken from DLink example
        {
            Active,
            Reserve,
            Uninitialized
        }

        public CLink next;
        public CLink prev;
        public CLinkStatus status;

        public CLink() //each new Clink has no attachments, those are added through Manager methods
        {
            this.Clear();
        }

        public void Clear()  //erases all Clink attachments
        {
            this.next = null;
            this.prev = null;
            this.status = CLinkStatus.Uninitialized;
        }
    }
}

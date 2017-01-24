using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Manager
    {
        public DLink active;
        public DLink reserve;
        private int delta;
        private int nodesActive;
        private int nodesReserve;
        private int nodesAll;
        public int reserveNum;
        public int reserveGrow;

        protected Manager(int reserveNum = 3, int reserveGrow = 1)  //why reserveNum
        {
            this.active = new DLink();
            this.reserve = new DLink();
            this.delta = reserveGrow;
            this.nodesReserve += reserveNum;
            this.nodesAll += reserveNum + reserveGrow;
            this.nodesActive = 0;
            this.nodesReserve = 0;

            this.fillReserve(reserveNum);
        }

        protected DLink recycleAdd()  // called in subManagers Add method
        {
            if (this.reserve == null)
            {
                this.fillReserve(delta);  // new node created in reserve
            }

            
            DLink d = this.removeFrontReserve();
            d.Clear();
            this.addFrontActive(d);
            return d;
        }

        protected DLink recycleRemove()
        {
            DLink d = this.removeFrontActive();
            d.Clear();
            this.addFrontReserve(d);
            return d;
        }


        protected void addFrontActive(DLink d)
        {
            this.insertFront(ref this.active, d);
            d.status = DLink.DLinkStatus.Active;
            this.nodesActive++;

        }

        protected void addFrontReserve(DLink d)
        {
            this.insertFront(ref this.reserve, d);
            d.status = DLink.DLinkStatus.Reserve;
            this.nodesReserve++;


        }
        protected DLink removeFrontActive()
        {
            DLink d = this.removeFront(ref this.active);
            d.status = DLink.DLinkStatus.Uninitialized;
            this.nodesActive--;
            return d;
        }

        protected DLink removeFrontReserve()
        {
            DLink d = this.removeFront(ref this.reserve);
            d.status = DLink.DLinkStatus.Uninitialized;
            this.nodesReserve--;
            return d;
        }
        

        private void fillReserve(int poolDelta)
        {

            for (int i = 0; i < poolDelta; i++)
            {
                DLink newResNode = this.CreateNode();
                this.addFrontReserve(newResNode);
                this.nodesAll++;
            }

        }
        
        private void insertFront(ref DLink head, DLink d)  //value stored in memory of head will change according to method
        {
            d.Clear();

            if (head == null)
            {
                head = d;
                d.next = null;
                d.prev = null;
            }

            head.prev = d;
            d.next = head;
            d.prev = null;
            head = d;

        }

        private DLink removeFront(ref DLink head)  //value stored in memory of head will change according to method
        {
            DLink temp = head;

            head = temp.next;

            if (head != null)
            {
                head.prev = null;

            }

            temp.Clear();
            
            return temp;

        }

        abstract protected DLink CreateNode();
    }
}

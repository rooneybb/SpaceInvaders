using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    public abstract class Container : DLink
    {
        public CLink active;
        public CLink reserve;
        private int deltaContainer;
        public int nodesActive;
        public int nodesReserve;
        public int nodesAll;
        public int reserveNum;
        public int reserveGrow;


        
        protected Container(int reserveNum = 3, int reserveGrow = 1)  //why reserveNum
        {
            this.active = new CLink();
            this.reserve = new CLink();
            this.deltaContainer = reserveGrow;
            this.nodesReserve += reserveNum;
            this.nodesAll += reserveNum + reserveGrow;
            this.nodesActive = 0;
            this.nodesReserve = 0;

            this.fillReserve(reserveNum);

        }

        protected CLink recycleAdd()  // called in subManagers Add method
        {
            if (this.reserve == null)
            {
                this.fillReserve(deltaContainer);  // new node created in reserve
            }

            
            CLink c = this.removeFrontReserve();
            c.Clear();
            this.addFrontActive(c);
            return c;
        }

        protected CLink recycleRemove()
        {
            CLink c = this.removeFrontActive();
            c.Clear();
            this.addFrontReserve(c);
            return c;
        }

        protected void addFrontActive(CLink c)
        {
            this.insertFront(ref this.active, c);
            c.status = CLink.CLinkStatus.Active;
            this.nodesActive++;

        }

        protected void addFrontReserve(CLink c)
        {
            this.insertFront(ref this.reserve, c);
            c.status = CLink.CLinkStatus.Reserve;
            this.nodesReserve++;


        }
        
        protected CLink removeFrontActive()
        {
            CLink c = this.removeFront(ref this.active);
            c.status = CLink.CLinkStatus.Uninitialized;
            this.nodesActive--;
            return c;
        }

        protected void removeFromActive(CLink cNode)
        {
            CLink cNode2 = this.active;

            if (cNode2 == cNode)
            {
                this.removeFront(ref this.active);
                this.addFrontReserve(cNode);
            }

            else
            {
                if (this.active.next != null)
                {
                    cNode.next.prev = cNode.prev;
                    cNode.prev.next = cNode.next;
                    this.addFrontReserve(cNode);
                }
                else
                {
                    cNode.prev.next = null;
                    this.addFrontReserve(cNode);
                }

            }
        }
        

        protected CLink removeFrontReserve()
        {
            CLink c = this.removeFront(ref this.reserve);
            c.status = CLink.CLinkStatus.Uninitialized;
            this.nodesReserve--;
            return c;
        }
        

        private void fillReserve(int poolDelta)
        {

            for (int i = 0; i < poolDelta; i++)
            {
                CLink newResNode = this.CreateNode();
                this.addFrontReserve(newResNode);
                this.nodesAll++;
            }

        }

        private void insertFront(ref CLink head, CLink c)  //value stored in memory of head will change according to method
        {
            c.Clear();

            if (head == null)
            {
                head = c;
                c.next = null;
                c.prev = null;
            }

            head.prev = c;
            c.next = head;
            c.prev = null;
            head = c;

        }

        private CLink removeFront(ref CLink head)  //value stored in memory of head will change according to method
        {
            Debug.Assert(head != null);
            CLink temp = head;

          //  ;
          //  
            head = head.next;

            if (head != null)
           {
               head.prev = null;

          }
            
           // head = temp.next;

            // temp.next = null;
          temp.Clear();
            
            return temp;

        }

        abstract protected CLink CreateNode();

       // abstract protected Iterator CreateIterator();
    }
}

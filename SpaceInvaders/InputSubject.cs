using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputSubject
    {
        public InputObserver inputHead;

        public void Attach(InputObserver inObserver)
        {
            inObserver.subject = this;

            if (inputHead == null)
            {
                inputHead = inObserver;
                inObserver.next = null;
                inObserver.prev = null;
            }
            else
            {
                inObserver.next = inputHead;
                inObserver.prev = null;
                inputHead.prev = inObserver;
                inputHead = inObserver;
            }
        }

        public void Notify()
        {
            InputObserver temp = this.inputHead;

            while (temp != null)
            {
                temp.Notify();
                temp = temp.next as InputObserver;
            }
        }
    }
}

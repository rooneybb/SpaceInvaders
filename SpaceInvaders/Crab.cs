using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Crab : AlienObject
    {


        public Crab(GameObject.Name name, Sprite.Name sprite, int index, float xParamProxy, float yParamProxy)
            : base(name, sprite, index, AlienObject.AlienType.crab)
        {
            this.proxyX = xParamProxy;
            this.proxyY = yParamProxy;
        }

        public Crab(GameObject.Name name, Sprite.Name sprite, int index, float xParamProxy, float yParamProxy, float xParamLoc, float yParamLoc)
            : base(name, sprite, index, AlienObject.AlienType.crab)
        {
            this.proxyX = xParamProxy;
            this.proxyY = yParamProxy;
            this.locX = xParamLoc;
            this.locY = yParamLoc;
            this.index = index;
           /* Debug.Assert(this.pS.sprite != null);
            this.colObj = new CollisionObject(this.pS.sprite, this.index);
            Debug.Assert(this.colObj != null);
            this.colObj.updatePosition(this.pS.locX, this.pS.locY); */

        }

        public Crab(GameObject.Name name, Sprite.Name sprite, int index, float xParamProxy, float yParamProxy, float xParamLoc, float yParamLoc, SpriteBatch boxBatch)
            : base(name, sprite, index, AlienObject.AlienType.crab)
        {
            this.proxyX = xParamProxy;
            this.proxyY = yParamProxy;
            this.locX = xParamLoc;
            this.locY = yParamLoc;
            this.colObj = new CollisionObject(this.pS.sprite, this.index);
            Debug.Assert(this.colObj != null);
            boxBatch.attach(this.colObj.sBox);
            this.colObj.updatePosition(this.pS.locX, this.pS.locY);
        }

        public override void accept(CollisionVisitor cVisitor)
        {
            cVisitor.VisitCrab(this);
        }
    }
}

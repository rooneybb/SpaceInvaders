using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchNode : CLink
    {
        public SpriteBase sBase;
        public SpriteBatch sBatch;

        public SpriteBatchNode() : base()
        {
            this.sBase = null;
            this.sBatch = null;
        }

        public void set(Sprite sParam, SpriteBatch sBatchParam)
        {
            this.sBase = sParam;
            Debug.Assert(sBase != null);
            this.sBase.sBatNode = this;
            Debug.Assert(sBase.sBatNode != null);
            this.sBatch = sBatchParam;
            //this.sBatch = sBatchParam;
           // Debug.Assert(sBatch != null);
        }

        public void set(ProxySprite pSParam, SpriteBatch sBatchParam)
        {
            this.sBase = pSParam;
            Debug.Assert(sBase != null);
            this.sBase.sBatNode = this;
            Debug.Assert(sBase.sBatNode != null);
            this.sBatch = sBatchParam;
            Debug.Assert(sBatch != null);
        }

        public void set(SpriteBox sBoxParam, SpriteBatch sBatchParam)
        {
            this.sBase = sBoxParam;
            Debug.Assert(sBase != null);
            this.sBase.sBatNode = this;
            Debug.Assert(sBase.sBatNode != null);
            this.sBatch = sBatchParam;
            Debug.Assert(sBatch != null);
        }
    }
}

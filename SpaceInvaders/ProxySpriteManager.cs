using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ProxySpriteManager : Manager
    {
        private static ProxySpriteManager pSMan = null;
        public ProxySprite temp;

        private ProxySpriteManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as ProxySprite;
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (pSMan == null)
            {
                pSMan = new ProxySpriteManager(reserveNum, reserveGrow);
            }

        }

        public static ProxySprite Add(Sprite.Name spriteNameParam, float x, float y)
        {
            ProxySpriteManager pSMan = ProxySpriteManager.getInstance();
            ProxySprite pS = pSMan.recycleAdd() as ProxySprite;
           // Sprite spriteRef = SpriteManager.find(name);
            pS.set(spriteNameParam, x, y);
            Debug.Assert(pS.sprite != null);
            return pS;
        }

        public static void remove()
        {
            ProxySpriteManager pSMan = ProxySpriteManager.getInstance();
            pSMan.recycleRemove();
        }

        public static ProxySprite find(ProxySprite.Name name)
        {
            ProxySpriteManager pSMan = ProxySpriteManager.getInstance();
            pSMan.temp.name = name;
            Debug.Assert(pSMan.active != null);
            ProxySprite pSLink = pSMan.active as ProxySprite;

            while (pSLink != null)
            {
                if (pSLink.name == pSMan.temp.name)
                {
                    return pSLink;

                }
                pSLink = pSLink.next as ProxySprite;
            }

            return pSLink;
        }

        private static ProxySpriteManager getInstance()
        {
            return pSMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new ProxySprite() as ProxySprite;
            return d;
        }
    }
}

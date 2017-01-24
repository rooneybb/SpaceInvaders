using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager : Manager
    {
        private static SpriteManager sMan = null;
        public Sprite temp;

        private SpriteManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as Sprite;
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (sMan == null)
            {
                sMan = new SpriteManager(reserveNum, reserveGrow);
            }

        }

        public static Sprite Add(Sprite.Name name, Image.NameImage name2, float x, float y, float sx, float sy)
        {
            SpriteManager sMan = SpriteManager.getInstance();
            Sprite s = sMan.recycleAdd() as Sprite;
            s.set(name, name2, new Azul.Rect(x, y, sx, sy));
            return s;
        }

        public static void remove()
        {
            SpriteManager sman = SpriteManager.getInstance();
            sMan.recycleRemove();
        }

        public static Sprite find(Sprite.Name name)
        {
            SpriteManager sman = SpriteManager.getInstance();
            sMan.temp.name = name;
            Debug.Assert(sMan.active != null);
            Sprite sLink = sMan.active as Sprite;

            while (sLink != null)
            {
                if (sLink.name == sMan.temp.name)
                {
                    return sLink;

                }
                sLink = sLink.next as Sprite;
            }

            return sLink;
        }

        private static SpriteManager getInstance()
        {
            return sMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new Sprite() as Sprite;
            return d;
        }
    }
    
}

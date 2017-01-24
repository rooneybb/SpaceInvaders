using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxManager : Manager
    {
        private static SpriteBoxManager sbMan = null;
        public SpriteBox temp;

        private SpriteBoxManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as SpriteBox;
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (sbMan == null)
            {
                sbMan = new SpriteBoxManager(reserveNum, reserveGrow);
            }

        }

        public static SpriteBox Add(SpriteBox.Name name, float x, float y, float sx, float sy)
        {
            SpriteBoxManager sbMan = SpriteBoxManager.getInstance();
            SpriteBox sb = sbMan.recycleAdd() as SpriteBox;
            sb.set(name, new Azul.Rect(x, y, sx, sy));
            return sb;
        }

        public static SpriteBox Add(SpriteBox.Name name, Azul.Rect rectParam)
        {
            SpriteBoxManager sbMan = SpriteBoxManager.getInstance();
            SpriteBox sb = sbMan.recycleAdd() as SpriteBox;
            sb.set(name, rectParam);
            return sb;
        }

        public static void remove()
        {
            SpriteBoxManager sbMan = SpriteBoxManager.getInstance();
            sbMan.recycleRemove();
        }

        public static SpriteBox find(SpriteBox.Name name)
        {
            SpriteBoxManager sbMan = SpriteBoxManager.getInstance();
            sbMan.temp.name = name;
            Debug.Assert(sbMan.active != null);
            SpriteBox sbLink = sbMan.active as SpriteBox;

            while (sbLink != null)
            {
                if (sbLink.name == sbMan.temp.name)
                {
                    return sbLink;

                }
                sbLink = sbLink.next as SpriteBox;
            }

            return sbLink;
        }

        private static SpriteBoxManager getInstance()
        {
            return sbMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new SpriteBox() as SpriteBox;
            return d;
        }
    }
}

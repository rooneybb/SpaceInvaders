using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
    {
        private static ImageManager iMan = null;
        public Image temp;

        private ImageManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as Image;
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            if (iMan == null)
            {
                iMan = new ImageManager(reserveNum, reserveGrow);
            }

        }

        public static Image Add(Image.NameImage name, Texture.NameTexture name2, float x, float y, float sx, float sy)
        {
            ImageManager iMan = ImageManager.getInstance();
            // Debug.Assert(iMan.active != null);
            //Texture t = TextureManager.find(name2);
            Image i = iMan.recycleAdd() as Image;
            i.set(name, name2, new Azul.Rect(x, y, sx, sy));
            return i;
        }

        public static void remove()
        {
            ImageManager iMan = ImageManager.getInstance();
            iMan.recycleRemove();
        }

        public static Image find(Image.NameImage name)
        {
            ImageManager iMan = ImageManager.getInstance();
            iMan.temp.name = name;
            Debug.Assert(iMan.active != null);
            Image iLink = iMan.active as Image;

            while (iLink != null)
            {
                if (iLink.name == iMan.temp.name)
                {
                    return iLink;

                }
                iLink = iLink.next as Image;
            }

            return iLink;
        }

        private static ImageManager getInstance()
        {
            return iMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new Image() as Image;
            return d;
        }
    }
}

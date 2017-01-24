using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureManager : Manager
    {
        private static TextureManager tMan = null;
        public Texture temp;


        private TextureManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.temp = this.CreateNode() as Texture;

            
        }

        public static void createInstance(int reserveNum = 3, int reserveGrow = 1)
        {
            
            
                if (tMan == null)
                {
                    tMan = new TextureManager(reserveNum, reserveGrow);
                }
                
           
        }


        public static Texture find(Texture.NameTexture name)
        {
            TextureManager tMan = TextureManager.getInstance();
        
            Texture tLink = tMan.active as Texture;

            while (tLink != null)
            {
                if (tLink.name == name)
                {
                    return tLink;
                    
                }
                tLink = tLink.next as Texture;
            }

            return tLink;
        
        }

        public static Boolean Compare(Texture t1, Texture t2)
        {
            Debug.Assert(t1 != null);
            Debug.Assert(t2 != null);

            Boolean status = false;

            if (t1 == t2)
            {
                status = true;
            }

            return status;
        }

        public static Texture Add(Texture.NameTexture name, String textureFile, Azul.Texture_Filter min, Azul.Texture_Filter mag) 
        {
            TextureManager tMan = TextureManager.getInstance();
            //Texture t = new Texture();
           // Debug.Assert(t != null);
            //tMan.addFrontActive(t);
            Texture t = tMan.recycleAdd() as Texture;
            t.set(name, textureFile, min, mag);
            return t;
        }

        public static void remove()
        {
            TextureManager tMan = TextureManager.getInstance();
            tMan.recycleRemove();
        }

        private static TextureManager getInstance()
        {
            return tMan;
        }

        override protected DLink CreateNode()
        {
            DLink d = new Texture() as Texture;
            return d;
        }
        

}
}

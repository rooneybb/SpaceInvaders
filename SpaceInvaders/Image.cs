using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Image : DLink
    {
        public enum NameImage
        {
            AlienRow1,
            AlienRow1_2,
            AlienRow2,
            AlienRow2_2,
            AlienRow3,
            AlienRow3_2,
            AlienRow4,
            Explosion,
            Ship,
            Missile,
            Bomb,
            ShipMissile,
            Alienmissile,
            UFO,
            Shield,
            NullImage,
            Uninitialized
        }

        public Image.NameImage name;
        public Texture texture;
        public Azul.Rect azulRect;

        public Image(Image.NameImage nameParam, Texture textureParam, Azul.Rect azulRectParam)
            : base()
        {
            this.name = nameParam;
            this.azulRect = new Azul.Rect(azulRectParam);
            this.texture = textureParam;
        }

        public Image()
            : base()
        {
            this.name = Image.NameImage.Uninitialized;
            this.azulRect = null;
            this.texture = null;
        }



        public void set(Image.NameImage name, Texture.NameTexture name2, Azul.Rect azulRectParam)
        {
            this.name = name;
            this.texture = TextureManager.find(name2);
            this.azulRect = new Azul.Rect(azulRectParam);
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Sprite : SpriteBase
    {

        public enum Name
        {
            AlienRow1,
            AlienRow2,
            AlienRow3,
            AlienRow4,
            AlienRow5,
            Explosion,
            Ship,
            UFO,
            NullColumn,
            AlienRoot,
            NullRoot,
            WallRoot,
            WallRight,
            WallLeft,
            WallTop,
            WallBottom,
            AlienMissile,
            ShipMissile,
            Shield1,
            Shield2,
            Shield3,
            Shield4,
            Uninitialized
        } 

        public Sprite.Name name;
        public Azul.Sprite azulSprite;
        public Azul.Color azulColor;
        public Image image;
        public Texture texture;
        public Azul.Rect screenRect;
        public float x;
        public float y;


        public Sprite(Sprite.Name sprName, Image imageParam, Azul.Rect screenRectParam)
            : base()
        {
            this.name = sprName;
            this.image = imageParam;
            this.texture = imageParam.texture;
            this.screenRect = new Azul.Rect(screenRectParam);
            this.azulColor = new Azul.Color(0.0f, 1.0f, 0.0f, 1.0f);
        }

        public Sprite()
            : base()
        {
            this.name = Sprite.Name.Uninitialized;
            this.image = null;
            this.texture = null;
            this.screenRect = null;
            this.azulSprite = null;
            this.azulColor = null;
        }

        public void set(Sprite.Name sprName, Image.NameImage imageName, Azul.Rect screenRectParam)
        {
            this.name = sprName;
            this.image = ImageManager.find(imageName);
            this.texture = image.texture;
            this.screenRect = new Azul.Rect(screenRectParam);
            this.azulColor = new Azul.Color(0.0f, 1.0f, 0.0f, 1.0f);
            this.azulSprite = new Azul.Sprite(texture.azulTexture, image.azulRect, screenRect, azulColor);
            this.x = this.azulSprite.x;
            this.y = this.azulSprite.y;
            this.sx = this.azulSprite.sx;
            this.sy = this.azulSprite.sy;
            
        }

        public void changeColor(float red, float green, float blue, float alpha)
        {
            this.azulSprite.SwapColor(new Azul.Color(red, green, blue, alpha));

        }

        public void changeImage(float x, float y)
        {
            this.azulSprite.SwapTextureRect(new Azul.Rect(x, y, this.sx, this.sy));
        }

        public override void update()
        {
            this.azulSprite.x = this.x;
            this.azulSprite.y = this.y;
            this.azulSprite.sx = this.sx;
            this.azulSprite.sy = this.sy;
            this.azulSprite.angle = this.angle;
            this.azulSprite.Update();

        }

        public override void render()
        {
            this.azulSprite.Render();
        }
    }
}

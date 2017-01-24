using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink
    {
        public enum NameTexture
        {
            SpaceInvaders,
            Missiles,
            Unitialized
        }

        public Texture.NameTexture name;

        public Azul.Texture azulTexture;

        public Texture()
            : base()
        {
            this.name = Texture.NameTexture.Unitialized;
            this.azulTexture = new Azul.Texture();

        }
        

        public void set(Texture.NameTexture textureName, String fileName, Azul.Texture_Filter min, Azul.Texture_Filter mag)
        {
            this.name = textureName;
            this.azulTexture.Set(fileName, min, mag);
        }

    }
}

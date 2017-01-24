using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionBox : Azul.Rect
    {
        
     //   public Azul.Rect azulRect;
        public float locX;
        public float locY;
        public float widthX;
        public float heightY;


        public CollisionBox(float x, float y, float sx, float sy) : base(x, y, sx, sy)
        {

         //   this.azulRect = new Azul.Rect(x, y, sx, sy);
            this.locX = x;
            this.locY = y;
            this.widthX = sx;
            this.heightY = sy;
        }

        public CollisionBox(Azul.Rect colAzulRect) : base(colAzulRect)
        {
            // this.azulRect = new Azul.Rect(colAzulRect);
            //Debug.Assert(this.azulRect != null);
            this.locX = colAzulRect.x;
            this.locY = colAzulRect.y;
            this.widthX = colAzulRect.width;
            this.heightY = colAzulRect.height;
        }


        public static bool intersect(CollisionBox cBox1, CollisionBox cBox2) //same as example
        {
            bool intersect = false;

            float min1x = cBox1.locX - (cBox1.widthX / 2);
            float max1x = cBox1.locX + (cBox1.widthX / 2);
            float min1y = cBox1.locY - (cBox1.heightY / 2);
            float max1y = cBox1.locY + (cBox1.heightY / 2);

            float min2x = cBox2.locX - (cBox2.widthX / 2);
            float max2x = cBox2.locX + (cBox2.widthX / 2);
            float min2y = cBox2.locY - (cBox2.heightY / 2);
            float max2y = cBox2.locY + (cBox2.heightY / 2);

            if ((max2x < min1x) || (min2x > max1x) || (max2y < min2y) || (min2y > max1y))  //seems backwards should look for any intersecting pairs not any non-Intersecting pairs
            {
                intersect = false;
            }
            else
            {
                intersect = true;
            }
            return intersect;
        }

        public void Union(CollisionBox colBox2)  //same as example
        {
            float minX;
            float maxX;
            float minY;
            float maxY;

            if ((this.locX - this.widthX / 2) < (colBox2.locX - colBox2.widthX / 2))
            {
                minX = (this.locX - this.widthX / 2);
            }
            else
            {
                minX = (colBox2.locX - colBox2.widthX / 2);
            }

            if ((this.locX + this.widthX / 2) > (colBox2.locX + colBox2.widthX / 2))
            {
                maxX = this.locX + this.widthX / 2;
            }
            else
            {
                maxX = colBox2.locX + colBox2.widthX / 2;
            }

            if ((this.locY - this.heightY / 2) < (colBox2.locY - colBox2.heightY / 2))
            {
                minY = this.locY - this.heightY / 2;
            }
            else
            {
                minY = colBox2.locY - colBox2.heightY / 2;
            }

            if ((this.locY + this.heightY / 2) > (colBox2.locY + colBox2.heightY / 2))
            {
                maxY = this.locY + this.heightY / 2;
            }
            else
            {
                maxY = colBox2.locY + colBox2.heightY / 2;
            }

            this.widthX = (maxX - minX);
            this.heightY = (maxY - minY);
            this.locX = minX + this.widthX / 2;
            this.locY = minY + this.heightY / 2;
        }
    }
}

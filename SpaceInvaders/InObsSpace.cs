using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InObsSpace : InputObserver
    {
        public override void Notify()
        {
            Ship temp = GameObjectManager.Find(GameObject.Name.ship, 1) as Ship;
            ShipMissile temp2 = GameObjectManager.Find(GameObject.Name.shipMissile, 1) as ShipMissile;
            Debug.Assert(temp != null);
            Debug.Assert(temp2 != null);
            
          //  temp.sprite.y += 2.0f;
           // bool shoot = true;
           

            temp2.sprite.x = temp.sprite.x;
            temp2.sprite.y = temp.sprite.y;

            temp2.shoot = true;

            if (temp2.sprite.y >= 1000.0f)
            {
                temp2.sprite.y = temp.sprite.y;
                temp2.shoot = true;
            }

            else if (temp2.sprite.y != temp.sprite.y && temp2.sprite.y < 1000.0f)
            {
                temp2.shoot = false;
            }

            
            
            if (temp2.shoot == true)
            {

            SoundManager.playFile("shoot.wav");
            temp2.update();
            }

         //   temp2.shoot = false;






            temp2.sprite.x = temp.sprite.x;
            temp2.sprite.y = temp.sprite.y;
            temp2.update();

                Debug.WriteLine("Shoot");
                
            }
          //  temp2.sprite.y = temp.sprite.y + 30.0f;

        //   temp2.sprite.y += 5.0f; 
            
            
           
        }
    
}

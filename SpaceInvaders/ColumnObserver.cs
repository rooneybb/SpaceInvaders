using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColumnObserver : CollisionObserver
    {

        public bool octo1Remove;
        public bool octo2Remove;
        public bool crabRemove;
        public bool crab2Remove;
        public bool squidRemove;
        public bool speedGrid;
        public bool ufoAdd;

        public ColumnObserver()
        {
            this.octo1Remove = true;
            this.octo2Remove = false;
            this.crabRemove = false;
            this.crab2Remove = false;
            this.squidRemove = false;
            this.speedGrid = false;
            this.ufoAdd = false;
        }

        public override void notify()
        {
            Debug.WriteLine("ColumnObserver: {0}, {1}", this.colSub.gObj1, this.colSub.gObj2);
            Ship shipTemp = GameObjectManager.Find(GameObject.Name.ship, 1) as Ship;
            Column column = this.colSub.gObj2 as Column;
            Debug.Assert(column != null);

            ShipMissile shipMissile = this.colSub.gObj1 as ShipMissile;
            Debug.Assert(shipMissile != null);

            GameObject temp = GameObjectManager.Find(GameObject.Name.octopus2, column.index);
            GameObject temp2 = GameObjectManager.Find(GameObject.Name.octopus, column.index);
            GameObject temp3 = GameObjectManager.Find(GameObject.Name.crab2, column.index);
            GameObject temp4 = GameObjectManager.Find(GameObject.Name.crab, column.index);
            GameObject temp5 = GameObjectManager.Find(GameObject.Name.squid, column.index);
            GameObject ufo = GameObjectManager.Find(GameObject.Name.ufo, 1);
            Grid gridTemp = GameObjectManager.Find(GameObject.Name.grid, 0) as Grid;

            ufo.sprite.y = 800.0f;
            ufo.sprite.x = -25.0f;

            if (temp != null && this.octo1Remove == true)
            {

                if (CollisionBox.intersect(shipMissile.colObj.colBoxRef, temp.colObj.colBoxRef) == true)
                {
                    Debug.WriteLine("HITHIT!!!!!!!!!!!!!!");
                    SoundManager.playFile("invaderkilled.wav");
                    Player1.addScore(10);
                    Debug.WriteLine("Player1 Score: {0}", Player1.getScore());
                    shipMissile.shoot = false;
                    // shipMissile.sprite.x = shipTemp.sprite.x;
                    shipMissile.sprite.y = 1001.0f;
                    GameObjectManager.remove(temp);
                   // ufo.sprite.x += 10.0f;
                    //  column.colObj.colBoxRef.heightY = column.colObj.colBoxRef.heightY - 25.0f;
                    //column.colObj.sBox.azulSpriteBox.y = column.colObj.sBox.azulSpriteBox.y + 25.0f;
                    temp.sprite.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
                    this.octo1Remove = false;
                    this.octo2Remove = true;
                }
                
      
            }

            else if (temp2 != null && this.octo2Remove == true)
            {
                if (CollisionBox.intersect(shipMissile.colObj.colBoxRef, temp2.colObj.colBoxRef) == true)
                {
                    Debug.WriteLine("HITHIT!!!!!!!!!!!!!!");
                    SoundManager.playFile("invaderkilled.wav");
                    Player1.addScore(10);
                    Debug.WriteLine("Player1 Score: {0}", Player1.getScore());
                    shipMissile.shoot = false;
                    shipMissile.sprite.y = -100.0f;
                    GameObjectManager.remove(temp2);
                    temp2.sprite.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
                    this.octo2Remove = false;
                    this.crabRemove = true;
                }
                
            }

            else if (temp3 != null && this.crabRemove == true)
            {
                if (CollisionBox.intersect(shipMissile.colObj.colBoxRef, temp3.colObj.colBoxRef) == true)
                {
                    ufo.sprite.x = 400.0f;
                    ufo.sprite.y = 1000.0f;
                    SoundManager.playFile("ufo_lowpitch.wav");
                    Debug.WriteLine("HITHIT!!!!!!!!!!!!!!");
                    SoundManager.playFile("invaderkilled.wav");
                    Player1.addScore(20);
                    Debug.WriteLine("Player1 Score: {0}", Player1.getScore());
                    shipMissile.shoot = false;
                    shipMissile.sprite.y = -100.0f;
                    GameObjectManager.remove(temp3);
                    temp3.sprite.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
                    this.crabRemove = false;
                    this.crab2Remove = true;
                }
                
            }

            else if (temp4 != null && this.crab2Remove == true)
            {
                if (CollisionBox.intersect(shipMissile.colObj.colBoxRef, temp4.colObj.colBoxRef) == true)
                {
                    Debug.WriteLine("HITHIT!!!!!!!!!!!!!!");
                    SoundManager.playFile("invaderkilled.wav");
                    Player1.addScore(20);
                    Debug.WriteLine("Player1 Score: {0}", Player1.getScore());
                    shipMissile.shoot = false;
                    shipMissile.sprite.y = -100.0f;
                    GameObjectManager.remove(temp4);
                    temp4.sprite.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
                    ufo.sprite.y = 1200.0f;
                    this.crab2Remove = false;
                    this.squidRemove = true;
                }
                
            }
            else if (temp5 != null && this.squidRemove == true)
            {
                if (CollisionBox.intersect(shipMissile.colObj.colBoxRef, temp5.colObj.colBoxRef) == true)
                {
                    Debug.WriteLine("HITHIT!!!!!!!!!!!!!!");
                    SoundManager.playFile("explosion.wav");
                    Player1.addScore(30);
                    Debug.WriteLine("Player1 Score: {0}", Player1.getScore());
                    shipMissile.shoot = false;
                    shipMissile.sprite.y = -100.0f;
                    GameObjectManager.remove(temp5);
                    temp5.sprite.changeColor(0.0f, 0.0f, 0.0f, 0.0f);
                    this.squidRemove = false;
                    this.ufoAdd = true;
                    this.speedGrid = true;
                }

                if (this.speedGrid == true && this.squidRemove == false)
                {
                    gridTemp.xDelta = gridTemp.xDelta * 2.0f;
                }
                
            }

            else
            {
                Debug.WriteLine("Column Empty");
            }

            
            

            

            
        }

    }
}

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
      

        SpriteBatch crabBatch;
        SpriteBatch crabBatch2;
        SpriteBatch octopusBatch;
        SpriteBatch octopusBatch2;
        SpriteBatch squidBatch;
        SpriteBatch gridBatch;
        SpriteBatch rootBatch;
        SpriteBatch boxBatch1;
        SpriteBatch boxBatch2;
        SpriteBatch boxBatch3;
        SpriteBatch boxBatch4;
        SpriteBatch boxBatch5;
        SpriteBatch shipBatch;
     //   SpriteBatch UFOBatch;
        SpriteBatch missileBatch;
        SpriteBatch missileBatch2;
        SpriteBatch wallBatch;
        SpriteBatch wallBoxBatch;
        SpriteBatch columnBatch;
        SpriteBatch columnBoxBatch;
        SpriteBatch shieldUFOBatch;

      //  CollisionObject coTest;
       // SpriteBox sbox;
        GameObjectNode alienGrid;
       // GameObjectNode boxGrid;
        Grid gridReal;

    //    CollisionObject colBox;
     //   CollisionBox colBoxTemp;

 
        //int count = 0;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Milestone2");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            TextureManager.createInstance(4, 1);
            ImageManager.createInstance(12, 1);
            SpriteBoxManager.createInstance(100, 1);
            SpriteManager.createInstance(100, 1);
            SpriteBatchManager.createInstance(50, 1);
            ProxySpriteManager.createInstance(75, 1);
            GameObjectManager.createInstance(6, 1);
            InputManager.createInstance();
            SoundManager.createInstance();
            CollisionPairManager.createInstance(15, 1);
            Player1.createInstance();
            
            

        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

          //  sndEngine = new IrrKlang.ISoundEngine();
            

             gridBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Background, 3, 1);
             crabBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens, 12, 1);
             crabBatch2 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens4, 12, 1);
             octopusBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens2, 12, 1);
             octopusBatch2 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens5, 12, 1);
             squidBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens3, 12, 1);
             rootBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Background, 12, 1);
             boxBatch1 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Boxes, 25, 1);
             boxBatch2 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens2, 12, 1);
             boxBatch3 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens3, 12, 1);
             boxBatch4 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens4, 12, 1);
             boxBatch5 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Aliens5, 12, 1);
             shipBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Ship, 12, 1);
             missileBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.ShipMissile, 5, 1);
             missileBatch2 = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.AliensMissile, 12, 1);
             wallBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Walls, 12, 1);
             wallBoxBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.WallBoxes, 12, 1);
            columnBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.Columns, 12, 1);
            columnBoxBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.ColumnBoxes, 12, 1);
            shieldUFOBatch = SpriteBatchManager.Add(SpriteBatch.NameSpriteBatch.UFO, 12, 1);

            TextureManager.Add(Texture.NameTexture.SpaceInvaders, "spaceInvadersSS.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            Texture invaderSheet = TextureManager.find(Texture.NameTexture.SpaceInvaders);

            TextureManager.Add(Texture.NameTexture.Missiles, "spaceInvadersMissiles.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            Texture missileSheet = TextureManager.find(Texture.NameTexture.Missiles);

            ImageManager.Add(Image.NameImage.AlienRow1, invaderSheet.name, 0.0f, 0.0f, 128.0f, 85.0f);
            Image invaderRect = ImageManager.find(Image.NameImage.AlienRow1);

            ImageManager.Add(Image.NameImage.AlienRow1_2, invaderSheet.name, 128.0f, 0.0f, 128.0f, 85.0f);
            Image invaderRect_2 = ImageManager.find(Image.NameImage.AlienRow1);

            ImageManager.Add(Image.NameImage.AlienRow2, invaderSheet.name, 256.0f, 0.0f, 128.0f, 85.0f);
            Image invaderRect2 = ImageManager.find(Image.NameImage.AlienRow2);

            ImageManager.Add(Image.NameImage.AlienRow2_2, invaderSheet.name, 384.0f, 0.0f, 128.0f, 85.0f);
            Image invaderRect2_2 = ImageManager.find(Image.NameImage.AlienRow1);

            ImageManager.Add(Image.NameImage.AlienRow3, invaderSheet.name, 0.0f, 85.0f, 128.0f, 85.0f);
            Image invaderRect3 = ImageManager.find(Image.NameImage.AlienRow3);

            ImageManager.Add(Image.NameImage.AlienRow3_2, invaderSheet.name, 128.0f, 85.0f, 128.0f, 85.0f);
            Image invaderRect3_2 = ImageManager.find(Image.NameImage.AlienRow1);

            ImageManager.Add(Image.NameImage.Ship, invaderSheet.name, 155.0f, 440.0f, 72.0f, 55.0f);
            Image shipRect = ImageManager.find(Image.NameImage.Ship);

            ImageManager.Add(Image.NameImage.ShipMissile, missileSheet.name, 535.0f, 1968.0f, 12.0f, 65.0f);
            Image shipMissileRect = ImageManager.find(Image.NameImage.ShipMissile);

            ImageManager.Add(Image.NameImage.Alienmissile, missileSheet.name, 575.0f, 1506.0f, 50.0f, 115.0f);
            Image alienMissileRect = ImageManager.find(Image.NameImage.Alienmissile);

            ImageManager.Add(Image.NameImage.UFO, invaderSheet.name, 0.0f, 425.0f, 128.0f, 85.0f);
            Image ufoRect = ImageManager.find(Image.NameImage.UFO);

            ImageManager.Add(Image.NameImage.Shield, invaderSheet.name, 0.0f, 510.0f, 128.0f, 85.0f);
            Image shieldRect = ImageManager.find(Image.NameImage.Shield);

            ImageManager.Add(Image.NameImage.NullImage, missileSheet.name, 0.0f, 0.0f, 1.0f, 1.0f);
            Image nullRect = ImageManager.find(Image.NameImage.NullImage);


            InputSubject inputSubject;
           
            inputSubject = InputManager.getSpaceBarSubject();
            inputSubject.Attach(new InObsSpace());

            inputSubject = InputManager.getArrowRightSubject();
            inputSubject.Attach(new InObsMoveRight());

            inputSubject = InputManager.getArrowLeftSubject();
            inputSubject.Attach(new InObsMoveLeft());

            inputSubject = InputManager.getCollisionBoxSubject();
            inputSubject.Attach(new InObsColBox());



         
            SpriteManager.Add(Sprite.Name.WallRoot, nullRect.name, -20.0f, -20.0f, 1.0f, 1.0f);
             SpriteManager.Add(Sprite.Name.WallRight, nullRect.name, 845.0f, 500.0f, 50.0f, 900.0f);
             SpriteManager.Add(Sprite.Name.WallLeft, nullRect.name, 51.0f, 500.0f, 50.0f, 900.0f);
             SpriteManager.Add(Sprite.Name.AlienRoot, nullRect.name, 400.0f, 800.0f, 1.0f, 1.0f);
             SpriteManager.Add(Sprite.Name.NullRoot, nullRect.name, 400.0f, 500.0f, 1.0f, 1.0f);
             SpriteManager.Add(Sprite.Name.AlienMissile, alienMissileRect.name, 400.0f, 650.0f, 20.0f, 45.0f);
             SpriteManager.Add(Sprite.Name.UFO, ufoRect.name, 1500.0f, 800.0f, 50.0f, 75.0f);
             SpriteManager.Add(Sprite.Name.Shield1, shieldRect.name, 150.0f, 200.0f, 50.0f, 75.0f);
             SpriteManager.Add(Sprite.Name.Shield2, shieldRect.name, 300.0f, 200.0f, 50.0f, 75.0f);
             SpriteManager.Add(Sprite.Name.Shield3, shieldRect.name, 450.0f, 200.0f, 50.0f, 75.0f);
             SpriteManager.Add(Sprite.Name.Shield4, shieldRect.name, 600.0f, 200.0f, 50.0f, 75.0f);

             //wallSprite = SpriteManager.find(Sprite.Name.NullRoot);

             PCSTree shieldUFOTree = new PCSTree();
             ShieldRoot shieldRoot = new ShieldRoot(GameObject.Name.nullRoot, Sprite.Name.NullRoot, 0, 0.0f, 0.0f, shieldUFOBatch);
             GameObjectManager.attachTree(shieldRoot, shieldUFOTree);
             shieldRoot.ActivateSprite(shipBatch);

             Shield shield1 = new Shield(GameObject.Name.shield, Sprite.Name.Shield1, 1, 150.0f, 200.0f, shieldUFOBatch);
             shieldUFOTree.Insert(shield1, shieldRoot);
             shield1.ActivateSprite(shieldUFOBatch);

             Shield shield2 = new Shield(GameObject.Name.shield, Sprite.Name.Shield2, 2, 150.0f, 200.0f, shieldUFOBatch);
             shieldUFOTree.Insert(shield2, shieldRoot);
             shield2.ActivateSprite(shieldUFOBatch);

             Shield shield3 = new Shield(GameObject.Name.shield, Sprite.Name.Shield3, 3, 150.0f, 200.0f, shieldUFOBatch);
             shieldUFOTree.Insert(shield3, shieldRoot);
             shield3.ActivateSprite(shieldUFOBatch);

             Shield shield4 = new Shield(GameObject.Name.shield, Sprite.Name.Shield4, 4, 150.0f, 200.0f, shieldUFOBatch);
             shieldUFOTree.Insert(shield4, shieldRoot);
             shield4.ActivateSprite(shieldUFOBatch);

             UFO ufo = new UFO(GameObject.Name.ufo, Sprite.Name.UFO, 1, 200.0f, 200.0f, shieldUFOBatch);
             shieldUFOTree.Insert(ufo, shieldRoot);
             ufo.ActivateSprite(shieldUFOBatch);


            gridReal = new Grid(GameObject.Name.grid, Sprite.Name.AlienRoot, 0, 10.0f, 10.0f, gridBatch);
            

              alienGrid = GameObjectManager.attachTree(gridReal, gridReal.pcsTree) as GameObjectNode;
            
              gridReal.ActivateSprite(gridBatch);
               gridReal.colObj = new CollisionObject(gridReal.sprite, gridReal.index);
               gridBatch.attach(gridReal.colObj.sBox);

             PCSTree missileTree = new PCSTree();
              MissileRoot mRoot = new MissileRoot(GameObject.Name.nullRoot, Sprite.Name.NullRoot, 0, 0.0f, 0.0f, missileBatch2);
               GameObjectManager.attachTree(mRoot, missileTree);
               mRoot.ActivateSprite(missileBatch2);

               Missile missileObj = new Missile(GameObject.Name.alienMissile, Sprite.Name.AlienMissile, 1, 405.0f, 800.0f, missileBatch2);
               missileTree.Insert(missileObj, mRoot);
               missileObj.ActivateSprite(missileBatch2);
              // boxBatch4.attach(missileObj.colObj.sBox);
               missileTree.dumpTree();

               PCSTree wallTree = new PCSTree();
               WallRoot wRoot = new WallRoot(GameObject.Name.wallRoot, Sprite.Name.WallRoot, 0, 0.0f, 0.0f, 0.0f, 0.0f, wallBoxBatch);
               GameObjectManager.attachTree(wRoot, wallTree);
               Debug.Assert(wallTree.root != null);
               wRoot.ActivateSprite(wallBatch);

               WallRight wRight = new WallRight(GameObject.Name.wallRight, Sprite.Name.WallRight, 1, 800.0f, 400.0f, 50.0f, 900.0f, wallBoxBatch);
               wallTree.Insert(wRight, wRoot);
               wRight.ActivateSprite(wallBatch);
               
            WallLeft wLeft = new WallLeft(GameObject.Name.wallLeft, Sprite.Name.WallLeft, 1, 0.0f, 0.0f, 50.0f, 900.0f, wallBoxBatch);
               wallTree.Insert(wLeft, wRoot);
               wRight.ActivateSprite(wallBatch);
            
               wallTree.dumpTree();

            PCSTree shipTree = new PCSTree();   
            ShipRoot shipRoot = new ShipRoot(GameObject.Name.shipRoot, Sprite.Name.NullRoot, 0, 0.0f, 0.0f, shipBatch);
            GameObjectManager.attachTree(shipRoot, shipTree);
            shipRoot.ActivateSprite(shipBatch);
               

               MiscellaneousFactory shipFactory = new MiscellaneousFactory(shipBatch, shipTree, shipRoot);
               MiscellaneousFactory missileFactory = new MiscellaneousFactory(missileBatch, shipTree, shipRoot);
               
             //  MiscellaneousFactory missileFactory = new MiscellaneousFactory(missileBatch, alienGrid);
            AlienFactory crabFactory = new AlienFactory(crabBatch, alienGrid);
            AlienFactory crabFactory2 = new AlienFactory(crabBatch2, alienGrid);
            AlienFactory octopusFactory = new AlienFactory(octopusBatch, alienGrid);
            AlienFactory octopusFactory2 = new AlienFactory(octopusBatch2, alienGrid);
            AlienFactory squidFactory = new AlienFactory(squidBatch, alienGrid);
            AlienFactory columnFactory = new AlienFactory(columnBatch, alienGrid);

            missileFactory.createMisc(GameObject.Name.shipMissile, Sprite.Name.ShipMissile, shipMissileRect.name, boxBatch2, 400.0f, 100.0f, 10.0f, 20.0f, 1);
                shipFactory.createMisc(GameObject.Name.ship, Sprite.Name.Ship, shipRect.name, boxBatch1, 400.0f, 100.0f, 75.0f, 50.0f, 1);
          
            
                

            for (int i = 1; i < 12; i++)
            {

                columnFactory.createAlien(AlienObject.AlienType.column, GameObject.Name.column, Sprite.Name.NullColumn, nullRect.name, columnBoxBatch, 0.0f, 0.0f, i * 50.0f + 100.0f, 800.0f, i);
               // Debug.Assert(newColumn != null);
             /*   crabFactory.setParent(temp);
                crabFactory2.setParent(temp);
                octopusFactory.setParent(temp);
                octopusFactory2.setParent(temp);
                squidFactory.setParent(temp); */
                crabFactory.createAlien(AlienObject.AlienType.crab, GameObject.Name.crab, Sprite.Name.AlienRow1, invaderRect.name, boxBatch1, 128.0f, 0.0f, i * 50.0f + 100.0f,850.0f, i);
                crabFactory2.createAlien(AlienObject.AlienType.crab, GameObject.Name.crab2, Sprite.Name.AlienRow4, invaderRect.name, boxBatch2, 128.0f, 0.0f, i * 50.0f + 100.0f, 800.0f, i);
                octopusFactory.createAlien(AlienObject.AlienType.octopus, GameObject.Name.octopus, Sprite.Name.AlienRow2, invaderRect3.name, boxBatch3, 128.0f, 85.0f, i * 50.0f + 100.0f, 750.0f, i);
                octopusFactory2.createAlien(AlienObject.AlienType.octopus, GameObject.Name.octopus2, Sprite.Name.AlienRow5, invaderRect3.name, boxBatch4, 128.0f, 85.0f, i * 50.0f + 100.0f, 700.0f, i);
                squidFactory.createAlien(AlienObject.AlienType.squid, GameObject.Name.squid, Sprite.Name.AlienRow3, invaderRect2.name, boxBatch5, 384.0f, 0.0f, i * 50.0f + 100.0f, 900.0f, i);

                
            }


           

            gridReal.pcsTree.dumpTree();

            ShipMissile sMiss = GameObjectManager.Find(GameObject.Name.shipMissile, 1) as ShipMissile;

            Octopus shotOcto = GameObjectManager.Find(GameObject.Name.octopus2, 3) as Octopus;

            Column shotColumn1 = GameObjectManager.Find(GameObject.Name.column, 1) as Column;
            Column shotColumn2 = GameObjectManager.Find(GameObject.Name.column, 2) as Column;
            Column shotColumn3 = GameObjectManager.Find(GameObject.Name.column, 3) as Column;
            Column shotColumn4 = GameObjectManager.Find(GameObject.Name.column, 4) as Column;
            Column shotColumn5 = GameObjectManager.Find(GameObject.Name.column, 5) as Column;
            Column shotColumn6 = GameObjectManager.Find(GameObject.Name.column, 6) as Column;
            Column shotColumn7 = GameObjectManager.Find(GameObject.Name.column, 7) as Column;
            Column shotColumn8 = GameObjectManager.Find(GameObject.Name.column, 8) as Column;
            Column shotColumn9 = GameObjectManager.Find(GameObject.Name.column, 9) as Column;
            Column shotColumn10 = GameObjectManager.Find(GameObject.Name.column, 10) as Column;
            Column shotColumn11 = GameObjectManager.Find(GameObject.Name.column, 11) as Column;


            CollisionPair alienGridRight = CollisionPairManager.Add(CollisionPair.Name.Alien_Missile, 0, gridReal, wRight);
            alienGridRight.attach(new AlienGridObserver());

            CollisionPair alienGridLeft = CollisionPairManager.Add(CollisionPair.Name.Alien_Shield, 1, gridReal, wLeft);
            alienGridLeft.attach(new AlienGridObserver());

            CollisionPair columnShooter1 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 2, sMiss, shotColumn1);
            columnShooter1.attach(new ColumnObserver());

            CollisionPair columnShooter2 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 3, sMiss, shotColumn2);
            columnShooter2.attach(new ColumnObserver());

            CollisionPair columnShooter3 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 4, sMiss, shotColumn3);
            columnShooter3.attach(new ColumnObserver());

            CollisionPair columnShooter4 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 5, sMiss, shotColumn4);
            columnShooter4.attach(new ColumnObserver());

            CollisionPair columnShooter5 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 6, sMiss, shotColumn5);
            columnShooter5.attach(new ColumnObserver());

            CollisionPair columnShooter6 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 7, sMiss, shotColumn6);
            columnShooter6.attach(new ColumnObserver());

            CollisionPair columnShooter7 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 8, sMiss, shotColumn7);
            columnShooter7.attach(new ColumnObserver());

            CollisionPair columnShooter8 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 9, sMiss, shotColumn8);
            columnShooter8.attach(new ColumnObserver());

            CollisionPair columnShooter9 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 10, sMiss, shotColumn9);
            columnShooter9.attach(new ColumnObserver());

            CollisionPair columnShooter10 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 11, sMiss, shotColumn10);
            columnShooter10.attach(new ColumnObserver());

            CollisionPair columnShooter11 = CollisionPairManager.Add(CollisionPair.Name.Col1_Missile, 12, sMiss, shotColumn11);
            columnShooter11.attach(new ColumnObserver());

    

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            //int count = 1000;
            
           // colBox.updatePosition(alienGrid.gObj.pS.locX, alienGrid.gObj.pS.locY);
            SoundManager.update();
            
            //GameObject temp = pcsIt.First() as GameObject;
           // gridReal.colObj.updatePosition(gridReal.pS.sprite.x, gridReal.pS.sprite.y); 
          //  GameObject tempAlien = GameObjectManager.Find(GameObject.Name.crab, 1);
            // Debug.Assert(tempAlien != null);

            CollisionPairManager.process();



            gridReal.moveGrid2(alienGrid.tree);
            gridReal.update();
           // colBox.update();
            GameObjectManager.update();

           // boxBatch5.detach();  //seems to remove entire batch, want to just push last one out
            InputManager.Update();

            


        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {

            SpriteBatchManager.Draw();


        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}


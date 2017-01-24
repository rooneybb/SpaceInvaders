using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private static InputManager iMan = null;
        private InputSubject arrowRightSubject;
        private InputSubject arrowLeftSubject;
        private InputSubject spaceBarSubject;
        private InputSubject collisionBoxSubject;
        private bool shootPrev;

        private InputManager()
        {
            this.arrowLeftSubject = new InputSubject();
            this.arrowRightSubject = new InputSubject();
            this.spaceBarSubject = new InputSubject();
            this.collisionBoxSubject = new InputSubject();
        }

        public static InputManager createInstance()
        {
            if (iMan == null)
            {
                iMan = new InputManager();
            }

            return iMan;
        }

        public static InputManager getInstance()
        {
            return iMan;

        }

        public static InputSubject getArrowRightSubject()
        {
            InputManager iMan = InputManager.getInstance();
            return iMan.arrowRightSubject;
        }

        public static InputSubject getArrowLeftSubject()
        {
            InputManager iMan = InputManager.getInstance();
            return iMan.arrowLeftSubject;
        }

        public static InputSubject getSpaceBarSubject()
        {
            InputManager iMan = InputManager.getInstance();
            return iMan.spaceBarSubject;
        }

        public static InputSubject getCollisionBoxSubject()
        {
            InputManager iMan = InputManager.getInstance();
            return iMan.collisionBoxSubject;
        }

        public static void Update()
        {
            InputManager iMan = InputManager.getInstance();

            bool shoot = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (shoot == true && iMan.shootPrev == false)
            {
                iMan.spaceBarSubject.Notify();
            }
            iMan.shootPrev = shoot;

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                iMan.arrowRightSubject.Notify();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                iMan.arrowLeftSubject.Notify();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B) == true)
            {
                iMan.collisionBoxSubject.Notify();
            }

        }
    }
}

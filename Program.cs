using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using States;
using Mainmenu;


namespace Physcs
{
    public static class program
    {
        static void Main()
        { 
            windows menu = new windows();
            menu.window();
        }
    }      
    class windows
    {
        private
            uint windowwidth = 1920;
            uint windowheight = 1080;
            View view;
            state state = new state();
            layout Menu = new layout();
            state.menustates currentstate = state.menustates.menu;


        public void visibleArea(SizeEventArgs eventsize)
        {
            //view.Size = new Vector2f(eventsize.Width, eventsize.Height);
            
        }
        public void window()
        {
            double windowWidthrangelower = windowwidth*0.30;
            double windowWidthrangehigher = windowwidth*0.60;
            double windowHeightrangelower = windowheight*0.30;
            double windowHieghtrangehigher = windowheight*0.60;

            view = new View(new FloatRect(0.0f, 0.0f, windowwidth, windowheight));
            VideoMode mode = new VideoMode(windowwidth, windowheight);
            RenderWindow window = new RenderWindow(mode, "Main");
            Random random = new Random();

            view.Zoom(1f);
            window.SetView(view);
            
            Menu.initMenu(windowwidth, windowheight, window);
            //Main loop for window 
            while (window.IsOpen)
            {
                //Checks if the X button is pressed to close
                window.DispatchEvents();
                window.Closed += (s, a) => window.Close();
                window.KeyReleased += (s, a) => state.setKeyRelease(false);
                //clears window and sets background as black
                window.Clear(Color.White);
                window.Resized += (s, a) => visibleArea(a);
                window.SetView(view);

                switch (this.currentstate)
                {
                    case state.menustates.menu:
                        this.currentstate = Menu.mainmenu(window, state.getMpv(window));
                        break;

                    case state.menustates.create:         
                        //Checks different keypresses
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                        {
                            //Zooms in if up arrow is pressed
                            view.Zoom(1.05f);
                            window.SetView(view);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                        {
                            //Zooms out if down arrow is pressed
                            view.Zoom(0.95f);
                            window.SetView(view);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                        {
                            //Camera moves upwards if W is pressed
                            Vector2f dim = view.Center;
                            dim.Y = dim.Y - 20;
                            view.Center = dim;
                            window.SetView(view);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                        {
                            //Camera moves downwards if S is pressed
                            Vector2f dim = view.Center;
                            dim.Y = dim.Y + 20;
                            view.Center = dim;
                            window.SetView(view);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                        {
                            //Camera moves left if A is pressed
                            Vector2f dim = view.Center;
                            dim.X = dim.X - 20;
                            view.Center = dim;
                            window.SetView(view);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                        {
                            //Camera moves right is D is pressed
                            Vector2f dim = view.Center;
                            dim.X = dim.X + 20;
                            view.Center = dim;
                            window.SetView(view);
                        }
                        break;
                }
                window.Display();
                window.SetFramerateLimit(60);
                
            }
            Console.WriteLine("0");     
        }

    }
}


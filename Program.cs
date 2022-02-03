using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using gravity;
using GUI;

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
            List<gravity.Nbody> Body = new List<gravity.Nbody>();
            //window iniztialization
            uint windowheight = 1080;
            uint windowwidth = 1920;
            bool keyrelease = false;
            bool pause = false;
            bool menu = true;
        public void window()
        {

            double windowWidthrangelower = windowwidth*0.30;
            double windowWidthrangehigher = windowwidth*0.60;
            double windowHeightrangelower = windowheight*0.30;
            double windowHieghtrangehigher = windowheight*0.60;
            View view;
            view = new View(new FloatRect(0.0f, 0.0f, 1920.0f, 1080.0f));
            VideoMode mode = new VideoMode(windowwidth, windowheight);
            RenderWindow window = new RenderWindow(mode, "Main");
            Random random = new Random();
            view.Zoom(1f);
            window.SetView(view);
            window.SetKeyRepeatEnabled(false);

            button button = new button(x, y, width, height, font, text, idleColor, hoverColor, activeColor);

            //Slider ResistivitySlider = new Slider(x, y, width, height, font, text,  idleColor, hoverColor, activeColor);



            //Assigning objects to list
            for (int i = 0; i < 5; i++)
            {
                Body.Add(new gravity.Nbody(random.Next((int)windowWidthrangelower, (int)windowWidthrangehigher), random.Next((int)windowHeightrangelower, (int)windowHieghtrangehigher)));
            }
            //Gets length of object list body and adds one to set as NULL
            int currentlockedsystem = Body.Count + 1;
            //Main loop for window 
            while (window.IsOpen)
            {
                //Checks if the X button is pressed to close
                window.DispatchEvents();
                window.Closed += (s, a) => window.Close();
                window.KeyReleased += (s, a) => keyrelease = false;
                //clears window and sets background as black
                window.Clear(Color.Black);

                switch (menu)
                {
                    case true:
                        continue;

                    case false:         
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
                        //Picks which body camera locks onto
                        else if(Keyboard.IsKeyPressed(Keyboard.Key.Right))
                        {
                            //resets pointer on list to 0 as a circular movement
                            if(currentlockedsystem == Body.Count)
                            {
                                //Prevent's multikey press
                                if (!keyrelease)
                                {
                                    currentlockedsystem = 0;
                                }
                            }
                            else    
                            {
                                //Prevent's multikey press
                                
                                if (!keyrelease)
                                {
                                    //Moves pointer to the right
                                    currentlockedsystem += 1;
                                }
                            }
                            keyrelease = true;
                            Console.WriteLine(currentlockedsystem);
                        }
                        else if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
                        {
                            if(currentlockedsystem == 0)
                            {
                                if(!keyrelease)
                                {
                                    currentlockedsystem = Body.Count;
                                }
                            }
                            else
                            {
                                if(!keyrelease)
                                {
                                    currentlockedsystem -= 1;
                                }
                            }
                            keyrelease = true;
                            Console.WriteLine(currentlockedsystem);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                        {
                            if (!keyrelease)
                            {
                                switch(pause)
                                {
                                    case true:
                                        pause = false;
                                        break;
                                    case false:
                                        pause = true;
                                        break;
                                }
                                keyrelease = true;

                            }
                        }


                        if(!pause)
                        {
                            for (int i = 0; i < Body.Count; i++)
                            {
                                for (int x = 0; x < Body.Count; x++)
                                {
                                    if (i != x)
                                    {
                                        Body[i].xmovement(Body[x].Currentx, Body[x].Currenty);
                                        Body[i].ymovement(Body[x].Currentx, Body[x].Currenty);
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < Body.Count; i++)
                        {
                            if(!pause)
                            {
                                Body[i].LocationCalc();
                                Body[i].trail();
                            }
                            Body[i].drawTrail(window);
                            window.Draw(Body[i].returngrad());
                            if (i == currentlockedsystem)
                            {
                                Body[i].centerCamera(window, view);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;
                }
                window.Display();
                window.SetFramerateLimit(60);
                Clock clock = new Clock();
                clock.Restart();
                
            }
        }

        public void menuinit(RenderTarget window)
        {

            button button = new button(x, y, width, height, font, text, idleColor, hoverColor, activeColor);
            button.update(window)
        }
    }
}


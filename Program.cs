using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using gravity;
using GUI;
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
            List<gravity.Nbody> Body = new List<gravity.Nbody>();
            bool pause = true;
            bool menu = true;
            View view;
            state state = new state();
            layout Menu = new layout();
            Font normFont = new Font("Fonts/BebasNeue-Regular.ttf");


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
            //Assigning objects to list
            for (int i = 0; i < 100; i++)
            {
                Body.Add(new gravity.Nbody(random.Next((int)windowWidthrangelower, (int)windowWidthrangehigher), random.Next((int)windowHeightrangelower, (int)windowHieghtrangehigher)));
            }
            Text currentlockedsystemtext = new Text();
            currentlockedsystemtext.CharacterSize = 20;
            currentlockedsystemtext.FillColor = Color.White;
            currentlockedsystemtext.Font = normFont;
            currentlockedsystemtext.Position = new Vector2f(100, windowheight - 100);
            //Gets length of object list body and adds one to set as NULL
            int currentlockedsystem = Body.Count + 1;
            //Main loop for window 
            while (window.IsOpen)
            {
                //Checks if the X button is pressed to close
                window.DispatchEvents();
                window.Closed += (s, a) => window.Close();
                window.KeyReleased += (s, a) => state.setKeyRelease(false);
                //clears window and sets background as black
                window.Clear(Color.Black);
                window.Resized += (s, a) => visibleArea(a);
                window.SetView(view);

                switch (menu)
                {
                    case true:
                        menu = Menu.mainmenu(window, state.getMpv(window));
                        break;

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
                                if (!state.getKeyRelease())
                                {
                                    currentlockedsystem = 0;
                                }
                            }
                            else    
                            {
                                //Prevent's multikey press
                                
                                if (!state.getKeyRelease())
                                {
                                    //Moves pointer to the right
                                    currentlockedsystem += 1;
                                }
                            }
                            state.setKeyRelease(true);
                            Console.WriteLine(currentlockedsystem);
                        }
                        else if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
                        {
                            if(currentlockedsystem == 0)
                            {
                                if(!state.getKeyRelease())
                                {
                                    currentlockedsystem = Body.Count;
                                }
                            }
                            else
                            {
                                if(!state.getKeyRelease())
                                {
                                    currentlockedsystem -= 1;
                                }
                            }
                            state.setKeyRelease(true);
                            Console.WriteLine(currentlockedsystem);
                        }
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                        {
                            if (!state.getKeyRelease())
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
                                state.setKeyRelease(true);

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
                                        Body[i].xmovement(Body[x].Currentx, Body[x].Currenty, Body[x].mass);
                                        //Body[i].ymovement(Body[x].Currentx, Body[x].Currenty, Body[x].mass);
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < Body.Count; i++)
                        {
                            if(!pause)
                            {
                                Body[i].LocationCalc();
                                //Body[i].trail();
                            }
                            //Body[i].drawTrail(window);
                            window.Draw(Body[i].returngrad());
                            if (i == currentlockedsystem)
                            {
                                Body[i].centerCamera(window, view);
                                Console.WriteLine(Body[i].getvelocity());
                            }
                            else
                            {
                                continue;
                            }
                        }
                        
                        currentlockedsystemtext.DisplayedString = $"Locked Body {currentlockedsystem} ";
                        window.Draw(currentlockedsystemtext);
                        break;
                }
                window.Display();
                window.SetFramerateLimit(60);
                Clock clock = new Clock();
                clock.Restart();
                
            }
            Console.WriteLine("0");     
        }

    }
}


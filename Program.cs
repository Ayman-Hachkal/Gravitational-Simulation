using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using gravity;

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
        public void window()
        {
            //creating list of objects
            List<gravity.Nbody> Body = new List<gravity.Nbody>();
            //window iniztialization
            uint windowheight = 1080;
            uint windowwidth = 1920;
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
                    if(currentlockedsystem == Body.Count + 1)
                    {
                        currentlockedsystem = 0;
                    }
                    else
                    {
                        //Moves pointer to the right
                        currentlockedsystem += 1;
                    }
                    Console.WriteLine(currentlockedsystem);
                }
                else if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    if(currentlockedsystem == 0)
                    {
                        currentlockedsystem = Body.Count + 1;
                    }
                    else
                    {
                        currentlockedsystem -= 1;
                    }
                    Console.WriteLine(currentlockedsystem);
                }
                //clears window and sets background as black
                window.Clear(Color.Black);
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

                for (int i = 0; i < Body.Count; i++)
                {
                    Body[i].LocationCalc();
                    window.Draw(Body[i].returngrad());
                    Body[i].trail();
                    Body[i].drawTrail(window);
                }
                
                window.Display();
                window.SetFramerateLimit(60);
                Clock clock = new Clock();
                clock.Restart();
                
            }
        }
    }
}


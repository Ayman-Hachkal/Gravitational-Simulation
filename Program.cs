using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
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
            int BodyCount;
            //creating list of objects
            List<gravity.Nbody> Body = new List<gravity.Nbody>();
            //window iniztialization
            uint windowheight = 800;
            uint windowwidth = 1000;
            VideoMode mode = new VideoMode(windowwidth, windowheight);
            RenderWindow window = new RenderWindow(mode, "Main");
            Random random = new Random();
            //assigning objects to list
            for (int i = 0; i < 6; i++)
            {
                Body.Add(new gravity.Nbody(random.Next((int)windowwidth), random.Next((int)windowheight)));
            }
            BodyCount = Body.Count;
            //main loop for window 
            while (window.IsOpen)
            {
                //if close button is pressed close the window
                window.DispatchEvents();
                window.Closed += (s, a) => window.Close();
                
                //clears window and sets background as black
                window.Clear(Color.Black);
                for (int i = 0; i < Body.Count; i++)
                {
                    for (int x = 0; x < Body.Count; x++)
                    {
                        Body[i].xmovement(BodyCount, Body[x]);
                        Body[i].ymovement(BodyCount, Body[x]);
                    }
                    window.Draw(Body[i].returngrad());
                }
                window.Display();
                window.SetFramerateLimit(60);
                Clock clock = new Clock();
                clock.Restart();
                
            }
        }
    }
}


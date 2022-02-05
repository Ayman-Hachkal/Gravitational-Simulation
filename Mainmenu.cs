using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using gravity;
using GUI;

namespace Mainmenu
{
    class layout
    {
        
        Font menuFont = new Font("Fonts/BebasNeue-Regular.ttf");
        Color idleColor = new Color(242, 104, 102);
        Color hoverColor = new Color(237, 43, 40);
        Color pressedColor = new Color(68, 134, 219);
        List<button> menubuttons = new List<button>();
        Title title;
        button Scenario;
        button Close;
        button Options;
        uint windowheight;
        uint windowwidth;

        public void initMenu(uint windowwidth, uint windowheight, RenderWindow window)
        {
            this.windowwidth = windowwidth;
            this.windowheight = windowheight;
            this.title = new Title(windowwidth/2, windowheight/2 - 100, "N-BODY", this.menuFont);
            this.Scenario = new button(windowwidth/2, windowheight/2, 100, 30, this.menuFont, "Scenario", 20, idleColor, hoverColor, pressedColor);
            this.Options =  new button(windowwidth/2, windowheight/2 + 50, 100, 30, this.menuFont, "Options", 20, idleColor, hoverColor, pressedColor);
            this.Close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, this.menuFont, "Close", 20, idleColor, hoverColor, pressedColor);
            this.menubuttons.Add(this.Scenario);
            this.menubuttons.Add(this.Options);
            this.menubuttons.Add(this.Close);
            
        }
        public void mainmenu(RenderWindow window, Vector2f mpV)
        {
            for (int i = 0; i < this.menubuttons.Count; i++)
            {
                this.menubuttons[i].update(mpV);
                this.menubuttons[i].render(window);
                this.title.render(window);
                if (this.menubuttons[i].isPressed())
                {
                    
                }
            }
        }
    }

    
}

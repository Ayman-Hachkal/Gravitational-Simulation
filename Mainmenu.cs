using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using GUI;
using States;

namespace Mainmenu
{
    class layout
    {
        List<button> menubuttons = new List<button>();
        uint windowheight;
        uint windowwidth;
        state.menustates currentLayout = state.menustates.menu;
        bool menu = true;

        public void initMenu(uint windowwidth, uint windowheight, RenderWindow window)
        {
            this.windowwidth = windowwidth;
            this.windowheight = windowheight;
            button title = new button(windowwidth/2, windowheight/2 - 100, 0.1f,0.1f, "Title", "Sprites/Title.png");
            button create = new button(windowwidth/2, windowheight/2, 0.1f, 0.1f, "Create", "Sprites/Create.png");
            button options = new button(windowwidth/2, windowheight/2 + 50, 0.1f, 0.1f, "Options", "Sprites/Options.png");
            button close = new button(windowwidth/2, windowheight/2 + 100, 0.1f, 0.1f, "Close", "Sprites/Close.png");
            this.menubuttons.Add(create);
            this.menubuttons.Add(options);
            this.menubuttons.Add(close);
            
        }
        public States.state.menustates mainmenu(RenderWindow window, Vector2f mpV)
        {
            window.Clear();
                for (int i = 0; i < this.menubuttons.Count; i++)
                {
                    this.menubuttons[i].update(mpV);
                    this.menubuttons[i].render(window);
                    if (this.menubuttons[i].isPressed())
                    {
                        state.menustates action = this.menubuttons[i].act();
                        switch (action)
                        {
                            case state.menustates.create:
                                    
                                currentLayout = state.menustates.create;
                                //window.SetView(new View(new Vector2f(0,0)));
                                break;
                            case state.menustates.options:
                                currentLayout = state.menustates.options;
                                break;
                            case state.menustates.close:
                                window.Close();
                                break;
                            default:
                                break;

                        }
                    }
                }
                return currentLayout;
            }
        }

    
}

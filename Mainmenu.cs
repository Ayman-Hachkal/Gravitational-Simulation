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
        Title title;
        uint windowheight;
        uint windowwidth;
        state.buttonAction currentLayout = state.buttonAction.menu;
        bool menu = true;

        public void initMenu(uint windowwidth, uint windowheight, RenderWindow window)
        {
            this.windowwidth = windowwidth;
            this.windowheight = windowheight;
            button title = new button(windowwidth/2, windowheight/2 - 100, 100,30, "Title", "Sprites/Title");
            button create = new button(windowwidth/2, windowheight/2, 100, 30, "Create", "Sprites/Create.png");
            button options = new button(windowwidth/2, windowheight/2 + 50, 100, 30, "Options", "Sprites/Options.png");
            button close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, "Close", "Sprites/Close.png");
            this.menubuttons.Add(create);
            this.menubuttons.Add(options);
            this.menubuttons.Add(close);
            
        }
        public bool mainmenu(RenderWindow window, Vector2f mpV)
        {
            window.Clear();
                for (int i = 0; i < this.menubuttons.Count; i++)
                {
                    this.menubuttons[i].update(mpV);
                    this.menubuttons[i].render(window);
                    if (currentLayout == state.buttonAction.menu)
                    {
                        this.title.render(window);
                    }
                    if (this.menubuttons[i].isPressed())
                    {
                        state.buttonAction action = this.menubuttons[i].act();
                        switch (action)
                        {
                            case state.buttonAction.create:
                                    
                                currentLayout = state.buttonAction.create;
                                menu = false;
                                break;
                            case state.buttonAction.options:
                                initOptions();
                                currentLayout = state.buttonAction.options;
                                break;
                            case state.buttonAction.close:
                                window.Close();
                                break;
                            case state.buttonAction.menu:
                                initMenu();
                                currentLayout = state.buttonAction.menu;
                                break;
                            default:
                                break;

                        }
                    }
                }
                return menu;
        }
        public void initOptions()
        {  
            this.menubuttons.Clear();
                
        }
        public void initMenu()
        {
            this.menubuttons.Clear();
            button create = new button(windowwidth/2, windowheight/2, 100, 30, "Create", "Sprites/Create.png");
            button options = new button(windowwidth/2, windowheight/2 + 50, 100, 30, "Options", "Sprites/Options.png");
            button close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, "Close", "Sprites/Close.png");
            this.menubuttons.Add(create);
            this.menubuttons.Add(options);
            this.menubuttons.Add(close);
        }
    }

    class creation
    {

    }

    
}

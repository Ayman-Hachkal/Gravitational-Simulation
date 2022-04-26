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
        
        Font menuFont = new Font("Fonts/BebasNeue-Regular.ttf");
        Color idleColor = new Color(242, 104, 102);
        Color hoverColor = new Color(237, 43, 40);
        Color pressedColor = new Color(68, 134, 219);
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
            this.title = new Title(windowwidth/2, windowheight/2 - 100, "N-BODY", this.menuFont);
            button scenario = new button(windowwidth/2, windowheight/2, 100, 30, this.menuFont, "Scenario", 20, idleColor, hoverColor, pressedColor, "SCENARIO");
            button options =  new button(windowwidth/2, windowheight/2 + 50, 100, 30, this.menuFont, "Options", 20, idleColor, hoverColor, pressedColor, "OPTIONS");
            button close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, this.menuFont, "Close", 20, idleColor, hoverColor, pressedColor, "QUIT");
            this.menubuttons.Add(scenario);
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
                            case state.buttonAction.scenario:
                                initScenario();
                                currentLayout = state.buttonAction.scenario;
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
        public void initScenario()
        {
            this.menubuttons.Clear();
            button scenario = new button(windowwidth/2, windowheight/2, 100, 30, this.menuFont, "Scenario", 20, idleColor, hoverColor, pressedColor, "CREATE");
            button options =  new button(windowwidth/2, windowheight/2 + 50, 100, 30, this.menuFont, "Options", 20, idleColor, hoverColor, pressedColor, "OPTIONS");
            button close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, this.menuFont, "Close", 20, idleColor, hoverColor, pressedColor, "QUIT");
            this.menubuttons.Add(scenario);
            this.menubuttons.Add(options);
            this.menubuttons.Add(close);
            
        }
        public void initOptions()
        {  
            this.menubuttons.Clear();
                
        }
        public void initMenu()
        {
            this.menubuttons.Clear();
            button scenario = new button(windowwidth/2, windowheight/2, 100, 30, this.menuFont, "Scenario", 20, idleColor, hoverColor, pressedColor, "SCENARIO");
            button options =  new button(windowwidth/2, windowheight/2 + 50, 100, 30, this.menuFont, "Options", 20, idleColor, hoverColor, pressedColor, "OPTIONS");
            button close = new button(windowwidth/2, windowheight/2 + 100, 100, 30, this.menuFont, "Close", 20, idleColor, hoverColor, pressedColor, "QUIT");
            this.menubuttons.Add(scenario);
            this.menubuttons.Add(options);
            this.menubuttons.Add(close);
        }
    }

    
}

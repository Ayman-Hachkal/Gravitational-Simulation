using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace States
{
    public class state
    {
        bool keyrelease = false;
        Vector2i mpS;
        Vector2i mpW;
        Vector2f mpV;
        public enum buttonAction {noact = 0, scenario, options, close, menu}
        public Vector2i getMps(RenderWindow window)
        {
            this.mpS = Mouse.GetPosition();
            return this.mpW;
        }
        public Vector2i getMpW(RenderWindow window)
        {
            this.mpW = Mouse.GetPosition(window);
            return this.mpW;
        }
        public Vector2f getMpv(RenderWindow window)
        {
            this.mpV = window.MapPixelToCoords(Mouse.GetPosition(window));
            return this.mpV;
        }
        public void setKeyRelease(bool keyrelease)
        {
            this.keyrelease = keyrelease;
        }
        public bool getKeyRelease()
        {
            return this.keyrelease;
        }
    }
    
}
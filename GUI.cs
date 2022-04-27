using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using States;
using Mainmenu;

namespace GUI
{
    enum button_states{BTN_IDLE = 0, BTN_HOVER, BTN_PRESSED};
    
    class button
    {
        private
        
        state guiState = new state();
        button_states buttonState;
        Sprite Button;
        string BTN_ACTION;

        public button(float x, float y, float scaleX, float scaleY, string BTN_ACTION, string image)
        {
            Texture texture = new Texture(image);
            this.Button = new Sprite(texture);
            this.Button.Origin = new Vector2f(this.Button.GetGlobalBounds().Width/2, this.Button.GetGlobalBounds().Height/2);
            this.Button.Scale = new Vector2f(scaleX, scaleY);
            this.Button.Position = new Vector2f(x, y);
            this.buttonState = button_states.BTN_IDLE;
            this.BTN_ACTION = BTN_ACTION;
        }
        public void update(Vector2f mousepos)
        {
            this.buttonState = button_states.BTN_IDLE;
            if(this.Button.GetGlobalBounds().Contains((float)mousepos.X, (float)mousepos.Y))
            {
                this.buttonState = button_states.BTN_HOVER;
                if(Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    this.buttonState = button_states.BTN_PRESSED;
                }
            }
            
        }
        public void render(RenderWindow window)
        {
            window.Draw(this.Button);
            //Draw shapes
        }

        public bool isPressed()
        {
            if (this.buttonState == button_states.BTN_PRESSED)
            {
                return true;
            }
            else{return false;}
        }
        public state.menustates act()
        {
            switch (this.BTN_ACTION)
            {
                case "Create":
                    return state.menustates.create;
                case "Options":
                    return state.menustates.options;
                case "Close":
                    return state.menustates.close;
                default:
                    return state.menustates.noact ;
            }
        }
    }
    class Title
    {
        private
        Text text = new Text();
        public Title(uint x,uint y, string text, Font font)
        {
            this.text.DisplayedString = text;
            this.text.CharacterSize = 40;
            this.text.FillColor = Color.White;
            this.text.Font = font;
            this.text.Position = new Vector2f(x - this.text.GetGlobalBounds().Width/2, y - this.text.GetGlobalBounds().Height/2.0f );
        }
        public void render(RenderWindow window)
        {
            window.Draw(this.text);
        }
    }
}
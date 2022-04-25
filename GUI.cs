using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using States;
using Mainmenu;

namespace GUI
{
    enum button_states{BTN_IDLE = 0, BTN_HOVER, BTN_PRESSED};
    class Slider
    {
        private
        RectangleShape bgrectangle;
        CircleShape scircle;
        Font font;
        Text text;
        
        Color idleColor;
        Color hoverColor;
        Color pressedColor;

        public Slider(float x, float y, float width, float height, Font font, string text, Color idleColor, Color hoverColor, Color pressedColor)
        {
            this.bgrectangle.Size = new Vector2f(width, height);
            this.bgrectangle.Position = new Vector2f(x, y);
            this.bgrectangle.FillColor = Color.White;

            this.scircle.Radius = height/2;
            this.scircle.FillColor = Color.Black;
            this.scircle.Position = new Vector2f(x, y);
            
            this.font = font;
            this.text.Font = this.font;
            this.text.DisplayedString = text;
            this.text.FillColor = Color.White;
            this.text.CharacterSize = 12;
            this.text.Position = new Vector2f(x, y + height + 10);


            this.idleColor = idleColor;
            this.hoverColor = hoverColor;
            this.pressedColor = pressedColor;


        }
        public void update(float x, float y)
        {
            if(this.scircle.GetGlobalBounds().Contains(x, y))
            {
                
            }
        }
        public void render(RenderTarget window)
        {
            window.Draw(this.bgrectangle);
            window.Draw(this.scircle);
        }
    }

    class button
    {
        private
        
        state guiState = new state();
        button_states buttonState;
        RectangleShape shape;
        Font font;
        Text text = new Text();
        
        Color idleColor;
        Color hoverColor;
        Color pressedColor;
        string BTN_ACTION;

        public button(float x, float y, float width, float height, Font font, string text, uint charsize, Color idleColor, Color hoverColor, Color pressedColor, string BTN_ACTION)
        {
            this.shape = new RectangleShape(new Vector2f(width, height));
            this.shape.Origin = new Vector2f(width/2, height/2);
            this.shape.Position = new Vector2f(x,y);
            this.shape.FillColor = Color.White;

            this.buttonState = button_states.BTN_IDLE;

            this.font = font;
            this.text.Font = this.font;
            this.text.DisplayedString = text;
            this.text.FillColor = Color.White;
            this.text.CharacterSize = charsize;
            this.text.Position = new Vector2f(this.shape.Position.X - this.text.GetGlobalBounds().Width/2.0f, this.shape.Position.Y - this.text.GetGlobalBounds().Height);


            this.idleColor = idleColor;
            this.hoverColor = hoverColor;
            this.pressedColor = pressedColor;

            this.BTN_ACTION = BTN_ACTION;


        }
        public void update(Vector2f mousepos)
        {
            this.buttonState = button_states.BTN_IDLE;
            if(this.shape.GetGlobalBounds().Contains((float)mousepos.X, (float)mousepos.Y))
            {
                this.buttonState = button_states.BTN_HOVER;
                if(Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    this.buttonState = button_states.BTN_PRESSED;
                }
            }
            switch (buttonState)
            {
                case button_states.BTN_IDLE:
                    this.shape.FillColor = this.idleColor;
                    break;
                case button_states.BTN_HOVER:
                    this.shape.FillColor = this.hoverColor;
                    break;
                case button_states.BTN_PRESSED:
                    this.shape.FillColor = this.pressedColor;
                    break;
                default:
                    this.shape.FillColor = Color.Red;
                    break;
            }
        }
        public void render(RenderWindow window)
        {
            window.Draw(this.shape);
            window.Draw(this.text);
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
        public state.buttonAction act()
        {
            switch (this.BTN_ACTION)
            {
                case "SCENARIO":
                    return state.buttonAction.scenario;
                case "OPTIONS":
                    return state.buttonAction.options;
                case "QUIT":
                    return state.buttonAction.close;
                default:
                    return state.buttonAction.noact ;
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
    class selection
    {
        RectangleShape shape;
        Font font;
        Text text = new Text();
        Texture texture;
        public selection(float x, float y, float width, float height, Font font, string text, uint charsize,string image)
        {
            try
            {
                texture = new Texture(image);
            }
            catch
            {
                Console.WriteLine("Can't load texture/s");
                System.Environment.Exit(3);
            }
            this.shape = new RectangleShape(new Vector2f(width, height));
            this.shape.Origin = new Vector2f(width/2, height/2);
            this.shape.Position = new Vector2f(x,y);
            this.shape.FillColor = Color.White;
            
            this.font = font;
            this.text.Font = this.font;
            this.text.DisplayedString = text;
            this.text.FillColor = Color.White;
            this.text.CharacterSize = charsize;
            this.text.Position = new Vector2f(this.shape.Position.X - this.text.GetGlobalBounds().Width/2.0f, this.shape.Position.Y - this.text.GetGlobalBounds().Height);

        }
    }
}
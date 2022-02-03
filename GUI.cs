using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GUI
{
    class Slider
    {
        private
        RectangleShape bgrectangle;
        CircleShape scircle;
        Font font;
        Text text;
        
        Color idleColor;
        Color hoverColor;
        Color activeColor;

        public Slider(float x, float y, float width, float height, Font font, Text text, Color idleColor, Color hoverColor, Color activeColor)
        {
            this.bgrectangle.Size = new Vector2f(width, height);
            this.bgrectangle.Position = new Vector2f(x, y);
            this.bgrectangle.FillColor = Color.White;

            this.scircle.Radius = height/2;
            this.scircle.FillColor = Color.Black;
            this.scircle.Position = new Vector2f(x, y);
            
            this.font = font;
            this.text.Font = this.font;
            this.text = text;
            this.text.FillColor = Color.White;
            this.text.CharacterSize = 12;
            this.text.Position = new Vector2f(x, y + height + 10);


            this.idleColor = idleColor;
            this.hoverColor = hoverColor;
            this.activeColor = activeColor;


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
        RectangleShape shape;
        Font font;
        Text text;
        
        Color idleColor;
        Color hoverColor;
        Color activeColor;

        public button(float x, float y, float width, float height, Font font, Text text, Color idleColor, Color hoverColor, Color activeColor)
        {
            this.shape.Size = new Vector2f(width, height);
            this.shape.Position = new Vector2f(x, y);
            this.shape.FillColor = Color.White;

            this.font = font;
            this.text.Font = this.font;
            this.text = text;
            this.text.FillColor = Color.White;
            this.text.CharacterSize = 12;
            this.text.Position = new Vector2f(x, y + height + 10);


            this.idleColor = idleColor;
            this.hoverColor = hoverColor;
            this.activeColor = activeColor;


        }
        public void update(float x, float y)
        {
            if(this.shape.GetGlobalBounds().Contains(x, y))
            {
                
            }
        }
        public void render(RenderTarget window)
        {
            window.Draw(this.shape);
        }
    }
}
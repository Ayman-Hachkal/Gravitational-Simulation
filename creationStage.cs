using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using States;
using Mainmenu;


namespace creation
{
    class gridlayout
    {
        RenderWindow window;
        View view;

        public gridlayout(RenderWindow Window, View View)
        {
            this.window = Window; 
            this.view = View;
        }
        public void updateGrid(RenderWindow Window, View View)
        {
            this.window = Window;
            this.view = View;
            this.window.SetView(view);
            float windowWidth  = this.window.Size.X;
            float windowHeight = this.window.Size.Y;

            for (float x = view.Viewport.Height; x < view.Center.X + windowWidth; x += 50)
            {
                for (float y = view.Viewport.Width; y < windowHeight; y += 50)
                {
                    RectangleShape Verticle = new RectangleShape(new Vector2f(2, 50));
                    Verticle.FillColor = Color.Black;
                    Verticle.Position = new Vector2f(x, y);
                    this.window.Draw(Verticle);
                    RectangleShape Horizontal = new RectangleShape(new Vector2f(50, 2));
                    Horizontal.FillColor = Color.Black;
                    Horizontal.Position = new Vector2f(x, y);
                    this.window.Draw(Horizontal);
                }
            }
            for (float x = view.Viewport.Height; x > view.Center.X - windowWidth; x -= 50)
            {
                for (float y = view.Viewport.Width; y >view.Center.Y - windowHeight; y -= 50)
                {
                    RectangleShape Verticle = new RectangleShape(new Vector2f(2, 50));
                    Verticle.FillColor = Color.Black;
                    Verticle.Position = new Vector2f(x, y);
                    this.window.Draw(Verticle);
                    RectangleShape Horizontal = new RectangleShape(new Vector2f(50, 2));
                    Horizontal.FillColor = Color.Black;
                    Horizontal.Position = new Vector2f(x, y);
                    this.window.Draw(Horizontal);
                }
            }
            for (float x = view.Viewport.Left; x > view.Center.X - windowWidth; x -= 50)
            {
                for (float y = view.Viewport.Top; y < view.Center.Y + windowHeight; y += 50)
                {
                    RectangleShape Verticle = new RectangleShape(new Vector2f(2, 50));
                    Verticle.FillColor = Color.Black;
                    Verticle.Position = new Vector2f(x, y);
                    this.window.Draw(Verticle);
                    RectangleShape Horizontal = new RectangleShape(new Vector2f(50, 2));
                    Horizontal.FillColor = Color.Black;
                    Horizontal.Position = new Vector2f(x, y);
                    this.window.Draw(Horizontal);
                }
            }
            for (float x = view.Viewport.Left; x < view.Center.X + windowWidth; x += 50)
            {
                for (float y = view.Viewport.Top; y > view.Center.Y - windowHeight; y -= 50)
                {
                    RectangleShape Verticle = new RectangleShape(new Vector2f(2, 50));
                    Verticle.FillColor = Color.Black;
                    Verticle.Position = new Vector2f(x, y);
                    this.window.Draw(Verticle);
                    RectangleShape Horizontal = new RectangleShape(new Vector2f(50, 2));
                    Horizontal.FillColor = Color.Black;
                    Horizontal.Position = new Vector2f(x, y);
                    this.window.Draw(Horizontal);
                }
            }
            Console.WriteLine(view.Center.X);
        }
    }
}

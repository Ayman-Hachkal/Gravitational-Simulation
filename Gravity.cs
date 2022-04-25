using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace gravity
{
    class Nbody
    {
        private Random random = new Random();
        double Gconst = 6.673889 * Math.Pow(10, -11);
        CircleShape circle;
        double time = 0.1;
        public double mass;
        double xvelocity;
        double yvelocity;
        public float Currentx;
        public float Currenty;
        double Ay;
        float dragCo = 0.47f;
        float density = 100f;
        double Xdragforce;
        double Ydragforce;
        double Ax;
        float dimensions;
        double Force;
        double xF;
        double yF;
        VertexArray curve = new VertexArray(PrimitiveType.LineStrip, 100);

        List<float> prevlocX = new List<float> {};
        List<float> prevlocY = new List<float> {};
        public Nbody(int xlocation, int ylocation)
        {
            dimensions = random.Next(10,20);
            circle = new CircleShape(dimensions, 1000);
            circle.FillColor = Color.Green;
            circle.Origin = new Vector2f(dimensions/2, dimensions/2);
            circle.Position = new Vector2f(xlocation, ylocation);
            Currentx = xlocation;
            Currenty = ylocation;
            xvelocity = random.Next(-10,10);
            yvelocity = random.Next(-10,10);
            mass = 1000000000;
            
        }
    
        public void xmovement(float Outerx, float Outery, double mass2)
        {
            Xdragforce = -1/2 * density * Math.PI * Math.Pow(dimensions,2) * dragCo * Math.Pow(xvelocity, 2);
            double distancey = (Currenty - Outery);    
            double distancex = (Currentx - Outerx); 
            double distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            
            Force = -(Gconst*mass*mass2)/(Math.Pow(distance, 2));


            double alpha = Math.Atan2(distancex,distancey);
            double angle = (180/Math.PI) * alpha;

            xF += Force * Math.Sin(alpha);
            yF += Force * Math.Cos(alpha);

        }

        public void ymovement(float Outerx, float Outery, double mass2)
        {
            Ydragforce = -1/2 * density * Math.PI * Math.Pow(dimensions, 2) * dragCo * Math.Pow(yvelocity, 2);
            double distancey = Math.Abs(Currenty - Outery); 
            double distancex = Math.Abs(Currentx - Outerx); 
            double distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ay += (mass*Gconst)/Math.Pow(distance,2);
            //Ay += -mass*(Currenty-Outery)/Math.Pow(distance,2);
            
        }

        public void LocationCalc()
        {
            double ForceX = Ax * mass;
            double sumForceX = ForceX - Xdragforce;
            Ax = sumForceX/mass;

            double ForceY = Ay * mass;
            double sumForceY = ForceY - Ydragforce;
            Ay = sumForceY/mass;
            if (Force > 0 || Force < 0)
            {
                Ax += xF/mass;
                Ay += yF/mass;
            }

            xvelocity += time*Ax;
            Currentx += (float)time*(float)xvelocity;
            yvelocity += time*Ay;
            Currenty += (float)time*(float)yvelocity;
            circle.Position = new Vector2f(Currentx, Currenty);

        }
        public Drawable returngrad()    
        {
            return circle;
        }
        public void trail()
        {
            if (prevlocX.Count < 100)
            {
                prevlocX.Add(Currentx);
                prevlocY.Add(Currenty);
            }
            else
            {
                prevlocX.RemoveAt(0);
                prevlocY.RemoveAt(0);
                for (int i = 1; i < prevlocX.Count; i++)
                {
                    prevlocX[i-1] = prevlocX[i];
                    prevlocY[i-1] = prevlocY[i];
                }
                prevlocX.RemoveAt(prevlocX.Count - 1);
                prevlocY.RemoveAt(prevlocY.Count - 1);
                prevlocX.Add(Currentx);
                prevlocY.Add(Currenty);


            }
        }
        public void drawTrail(RenderWindow window)
        {   
            for (int i = 0; i < prevlocX.Count; i++)
            {

                //curve.Append(new Vertex(new Vector2f(Currentx, Currenty)));

                CircleShape point;
                point = new CircleShape(1, 30);
                point.FillColor = Color.Green;
                point.Origin = new Vector2f(3/2, 3/2);
                point.Position = new Vector2f(prevlocX[i], prevlocY[i]);
                window.Draw(point);
            }
        }
        public void centerCamera(RenderWindow window, View view)
        {
            view.Center = new Vector2f(Currentx, Currenty);
            window.SetView(view);
        }
        public double getvelocity()
        {
            return xvelocity;
        }
        public double mass2()
        {
            return mass;
        }
    }
}
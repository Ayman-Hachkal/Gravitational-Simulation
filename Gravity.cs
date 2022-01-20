using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace gravity
{
    public class Nbody
    {
        private Random random = new Random();
        double Gconst = 6.673889 * Math.Pow(10, -11);
        CircleShape circle;
        double time = 0.1;
        float mass;
        float xvelocity;
        float yvelocity;
        int Currentx;
        int Currenty;
        float Ay;
        float Ax;
        public Nbody(int xlocation, int ylocation)
        {
            float dimensions = random.Next(30);
            circle = new CircleShape(dimensions, 30);
            circle.FillColor = Color.White;
            circle.Origin = new Vector2f(dimensions/2, dimensions/2);
            circle.Position = new Vector2f(xlocation, ylocation);
            Currentx = xlocation;
            Currenty = ylocation;
            xvelocity = random.Next(100);
            yvelocity = random.Next(100);
            mass = circle.Radius;
            //double fieldStrength = (Gconst*mass*M2);
        }

        public void xmovement(object Body)
        {
            float distancey = Math.Abs(Currenty - Body.getCurrenty); 
            float distancex = Math.Abs(Currentx - Body.getCurrentx); 
            float distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ax += -mass*(Currentx-Body.Currentx)/Math.Pow(distance,3);
        }

        public void ymovement(object Body)
        {
            float distancey = Math.Abs(Currenty - Body.Currenty); 
            float distancex = Math.Abs(Currentx - Body.Currentx); 
            float distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ay += -mass*(Currenty-Body.Currenty)/Math.Pow(distance,3);
        }

        public void LocationCalc()
        {
            xvelocity += time*Ax;
            Currentx += time*xvelocity;

            yvelocity += time*Ay;
            Currenty += time*yvelocity;
            circle.Position = new Vector2f(Currentx, Currenty);

        }
        public Drawable returngrad()
        {
            return circle;
        }

        public int getCurrenty()
        {
            return Currenty;
        }
        public int getCurrentx()
        {
            return Currentx;
        }

    }


}
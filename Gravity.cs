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
        double time = 0.5;
        double mass;
        double xvelocity;
        double yvelocity;
        public float Currentx;
        public float Currenty;
        double Ay;
        double Ax;
        float dimensions;
        List<float> prevlocX = new List<float> {};
        List<float> prevlocY = new List<float> {};
        public Nbody(int xlocation, int ylocation)
        {
            dimensions = random.Next(10,20);
            circle = new CircleShape(dimensions, 30);
            circle.FillColor = Color.Green;
            circle.Origin = new Vector2f(dimensions/2, dimensions/2);
            circle.Position = new Vector2f(xlocation, ylocation);
            Currentx = xlocation;
            Currenty = ylocation;
            xvelocity = 0;//random.Next(-10,10);
            yvelocity = 0;//random.Next(-10,10);
            mass = 5;
            //double fieldStrength = (Gconst*mass*M2);
        }

        public void xmovement(float Outerx, float Outery)
        {
            double distancey = Math.Abs(Currenty - Outery); 
            double distancex = Math.Abs(Currentx - Outerx); 
            double distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ax += -mass*(Currentx-Outerx)/Math.Pow(distance,3);
            //xvelocity += time*Ax;
            //Currentx += (float)time*(float)xvelocity;

        }

        public void ymovement(float Outerx, float Outery)
        {
            double distancey = Math.Abs(Currenty - Outery); 
            double distancex = Math.Abs(Currentx - Outerx); 
            double distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ay += -mass*(Currenty-Outery)/Math.Pow(distance,3);
            //yvelocity += time*Ay;
            //Currenty += (float)time*(float)yvelocity;
        }

        public void LocationCalc()
        {
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
        public void trail(float locationX, float locationY)
        {
            if (prevlocX.Count < 100)
            {
                prevlocX.Add(locationX);
                prevlocY.Add(locationY);
            }
            else
            {
                prevlocX.RemoveAt(0);
                prevlocY.RemoveAt(0);
                for (int i = 1; i < prevlocX.Count; i++)
                {
                    prevlocX[i -1] = prevlocX[i];
                }


            }
        }
    }
}
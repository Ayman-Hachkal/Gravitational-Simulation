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
        float time = 0.1;
        float mass;
        float xvelocity = Random.Next(100);
        float yvelocity = Random.Next(100);
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
            mass = circle.Radius;
            double fieldStrength = (Gconst*mass*M2);
        }

        public void xmovement(int BodyCount,int SelfCount,List Body)
        {
            float distancey = Math.Abs(Currenty - Body[i].Currenty); 
            float distancex = Math.Abs(Currentx - Body[i].Currentx); 
            float distance =  Math.Sqrt(Math.Pow(distancex,2) + Math.Pow(distancey,2));
            Ax += -mass*(Currentx-Body[i].Currentx)/Math.Pow(distance,3);
            
            xvelocity += time*Ax;
            Currentx += time*xvelocity;
            circle.Position = new Vector2f(Currentx, Currenty);
        }

        public void ymovement(int BodyCount,int SelfCount,List Body)
        {
            for (int i = 0; i < BodyCount; i++)
            {
                if(i!=SelfCount)
                {
                    float distancey = Math.Abs(Currenty - Body[i].Currenty); 
                    float distancex = Math.Abs(Currentx - Body[i].Currentx); 
                    float distance =  Math.Sqrt(distancex^2 + distancey^2);
                    Ay += -mass*(Currenty-Body[i].Currenty)/distance^3;
                }
            }
        
            yvelocity += time*Ay;
            Currenty += time*yvelocity;
            circle.Position = new Vector2f(Currentx, Currenty);
        }
        public Drawable returngrad()
        {
            return circle;
        }

    }


}
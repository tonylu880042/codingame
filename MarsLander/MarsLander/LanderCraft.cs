using System;
using System.Collections.Generic;

namespace MarsLander
{
    public class Point
    {
        public long x { get; set; }
        public long y { get; set; }
    }
    public class LanderCraft
    {
        int EPSILON = 5;
        int MAX_VERTICAL_SPEED = 40;
        int MAX_HORIZONTAL_SPEED = 20;
        double GRAVITY = 3.711;
        int SECURITY_DISTANCE_FROM_FLAT_GROUND = 50;

        int hSpeed = 0;
        int vSpeed = 0;
        bool speedChanged = false;

        int output_angle = 0;
        int output_thrust = 0;

        public List<Point> Terrains { get; set; }
        public Point CurrentPos { get; set; }
        public List<Point> TargetZone { get; set; }

        public void SetupTerrains(long x,long y) {
            Point p = new Point();

            p.x = x;
            p.y = y;

            this.Terrains.Add(p);
        }
        public void CalTargetTerrains()
        {            
            Point prePoint = null;
            foreach(Point p in this.Terrains)
            {
                if (prePoint == null){
                    prePoint = p;
                }//if    
                else{
                    if (p.y == prePoint.y)
                    {
                        TargetZone.Add(prePoint);
                        TargetZone.Add(p);
                    }
                    else
                        prePoint = p;
                }//else
            }//foreach
        }
        public long DistanceToDestination()
        {
            long distanceX = this.CurrentPos.x - (long)((this.TargetZone[0].x + this.TargetZone[1].x) / 2);
            long distanceY = this.CurrentPos.y - (this.TargetZone[0].y);
            return (distanceX * distanceX) + (distanceY * distanceY);
        }//

        public long CalHorDistanceToDestination(){
            return this.CurrentPos.x - (long)((this.TargetZone[0].x + this.TargetZone[1].x) / 2);
        }
        public long CalVerDistanceToDestination()
        {
            return this.CurrentPos.y - (this.TargetZone[0].y);
        }
        public LanderCraft()
        {
            this.Terrains = new List<Point>();
            this.TargetZone = new List<Point>();
            this.CurrentPos = new Point();

        }//
        public void setCurrentPos(int x,int y)
        {
            this.CurrentPos.x = x;
            this.CurrentPos.y = y;
        }

        public void SetSpeed(int hspeed,int vspeed){
            if (this.hSpeed != hspeed || this.vSpeed != vspeed)
                this.speedChanged = true;
            this.hSpeed = hspeed;
            this.vSpeed = vspeed;
        }//
        public bool IsMarsLanderFlyingOverFlatGround()
        {
            if (CurrentPos.x < this.TargetZone[1].x && CurrentPos.x > this.TargetZone[0].x)
            {
                return true;
            }//if
            else
                return false;
        }
        public bool IsMarsLanderAboutToLand()
        {
            return this.CurrentPos.y < (this.TargetZone[0].y + SECURITY_DISTANCE_FROM_FLAT_GROUND);
        }
        public bool AreMarsLanderSpeedLimitsSatisfied()
        {
            return Math.Abs(this.hSpeed) <= (MAX_HORIZONTAL_SPEED - EPSILON) && Math.Abs(this.vSpeed) <= (MAX_VERTICAL_SPEED - EPSILON);
        }
        public int CalculateRotationToSlowDownMarsLander()
        {
            double speed = Math.Sqrt(Math.Pow(this.hSpeed, 2) + Math.Pow(this.vSpeed, 2));
            double rotationAsRadians = Math.Asin((double)this.hSpeed / speed);
            return (int)(rotationAsRadians*(180.0 / Math.PI));
        }
        public bool IsMarsLanderFlyingInTheWrongDirection()
        {
            if (this.CurrentPos.x < this.TargetZone[0].x && this.hSpeed < 0)
            {
                return true;
            }

            if (this.CurrentPos.x > this.TargetZone[1].x && this.hSpeed > 0)
            {
                return true;
            }

            return false;
        }
        public bool IsMarsLanderFlyingTooFastTowardsFlatGround()
        {
            return Math.Abs(this.hSpeed) > (MAX_HORIZONTAL_SPEED * 4);
        }
        public bool IsMarsLanderFlyingTooSlowTowardsFlatGround()
        {
            return Math.Abs(this.hSpeed) < (MAX_HORIZONTAL_SPEED * 2);
        }
        public int CalculateRotationToSpeedUpMarsLanderTowardsFlatGround()
        {
            if (this.CurrentPos.x < this.TargetZone[0].x)
            {
                return -(int)(Math.Acos(GRAVITY / 4.0)*(180.0 / Math.PI));
            }

            if (this.CurrentPos.x  > this.TargetZone[1].x)
            {
                return +(int)(Math.Acos(GRAVITY / 4.0)* (180.0 / Math.PI));
            }

            return 0;
        }
        public int CalculateThrustPowerToFlyTowardsFlatGround()
        {
            return (this.vSpeed >= 0) ? 3 : 4;
        }
        public void ActionControl(){
            if(this.IsMarsLanderFlyingOverFlatGround())
            {
                if (this.IsMarsLanderAboutToLand())
                {
                    this.output_angle = 0;
                    this.output_thrust = 3;
                }
                else if (this.AreMarsLanderSpeedLimitsSatisfied())
                {
                    this.output_angle = 0;
                    this.output_thrust = 2;
                }
                else
                {
                    this.output_angle = this.CalculateRotationToSlowDownMarsLander();
                    this.output_thrust = 4;
                }
            }
            else
            {
                if (this.IsMarsLanderFlyingInTheWrongDirection() || this.IsMarsLanderFlyingTooFastTowardsFlatGround())
                {
                    this.output_angle = this.CalculateRotationToSlowDownMarsLander();
                    this.output_thrust = 4;
                }
                else if (this.IsMarsLanderFlyingTooSlowTowardsFlatGround())
                {
                    this.output_angle = this.CalculateRotationToSpeedUpMarsLanderTowardsFlatGround();
                    this.output_thrust = 4;
                }
                else
                {
                    this.output_angle = 0;
                    this.output_thrust = this.CalculateThrustPowerToFlyTowardsFlatGround();
                }
            }

        }

        public int GetRotate(){
            return this.output_angle;
        }
        public int GetThrust(){
            return this.output_thrust;
        }
    }
}

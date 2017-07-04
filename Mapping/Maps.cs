using System;
using System.Collections.Generic;

namespace CharlesDeep
{
    public class Map
    {
        public Map(double xRadius, double yRadius)
        {
            xAxis = 0;
            yAxis = 0;
        }

        public double xAxis { get; }
        public double yAxis { get; }

        public double xRadius { get; private set; }
        public double yRadius { get; private set; }

        private List<KeyValuePair<object, Position>> things;
        
        public void SetObjectList(List<KeyValuePair<object, Position>> list)
        {
            things = list;
        }

        public List<KeyValuePair<object, Position>> GetObjectList()
        {
            return this.things;
        }

        public void ModifyBounds(double newXRadius, double newYRadius)
        {
            xRadius = newXRadius;
            yRadius = newYRadius;
        }

    }

    /// <summary>
    /// Provides a class for storing positions and movements of points in space
    /// </summary>
    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Movement movement { get; set; }

        public override bool Equals(object obj)
        {
            return this == (Position) obj;
        }

        public override int GetHashCode()
        {
            int hash = 31;
            hash = (hash * 6) + X.GetHashCode();
            hash = (hash * 6) + Y.GetHashCode();
            hash = (hash * 6) + movement.GetHashCode();
            return hash;
        }
    }

    /// <summary>
    /// Provides methods for common processing needs to vectors and positions
    /// </summary>
    public class Utils
    {
        public static double GetDistanceBetweenTwoPoints(Position point1, Position point2)
        {
            double xDistance = point1.X - point2.X;
            double yDistance = point1.Y - point2.Y;
            if (xDistance < 0) xDistance *= -1;
            if (yDistance < 0) yDistance *= -1;

            double distance =  Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(xDistance, 2));
            return distance;
        }

        class Vectors
        {
            public static Movement AddVectors(Movement vector1, Movement vector2)
            {
                double newVectorX = vector1.X + vector2.X;
                double newVectorY = vector1.Y + vector2.Y;
                Movement result = new Movement()
                {
                    X = newVectorX,
                    Y = newVectorY,
                    velocity = Math.Sqrt(Math.Pow(newVectorX, 2) + Math.Pow(newVectorY, 2))
                };

                return result;
            }

            public static Position CalculateNewPosition(Position oldPosition)
            {
                Position newPosition = new Position()
                {
                    movement = oldPosition.movement,
                    X = oldPosition.X + oldPosition.movement.velocity,
                    Y = oldPosition.Y + oldPosition.movement.velocity
                };
                return newPosition;
            }

            public static Movement AddVelocity(Movement vector, double velocity)
            {
                return new Movement { X = vector.X, Y = vector.Y, velocity = velocity };
            }
        }

    }

    /// <summary>
    /// Provides a way for using and storing vectors
    /// </summary>
    public class Movement
    {
        public double velocity { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return ("Velocity: " + velocity + ", X: " + X + ", Y: " + Y);
        }

        public override bool Equals(object obj)
        {
            return this == (Movement)obj;
        }

        public override int GetHashCode()
        {
            int hash = 59;
            hash = (hash * 12) + velocity.GetHashCode();
            hash = (hash * 12) + X.GetHashCode();
            hash = (hash * 12) + Y.GetHashCode();
            return hash;
        }
    }
    
}

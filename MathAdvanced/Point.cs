using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOPaleAPI.MathAdvanced
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Point(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Point(double[] pts)
        {
            if (pts.Length != 3) throw new FormatException("Le tableau de point \"pts\" doit avoir 3 valeurs.");
            this.X = pts[0];
            this.Y = pts[1];
            this.Z = pts[2];
        }

        public static implicit operator double[](Point d)
        {
            double[] ret = new double[3];
            ret[0] = d.X;
            ret[1] = d.Y;
            ret[2] = d.Z;
            return ret;  // implicit conversion
        }
        public static implicit operator Point(double[] d)
        {
            Point ret = new Point()
            {
                X = d[0],
                Y = d[1],
                Z = d.Length == 3 ? d[2] : 0
            };
            return ret;  // implicit conversion
        }
        public static bool operator ==(Point a, Point b)
        {
            if (a is null && b is null)
                return true;
            else if (a is null)
                return false;
            else if (b is null)
                return false;
            else
                return
                    System.Math.Round(a.X, 3) == System.Math.Round(b.X, 3)
                    && System.Math.Round(a.Y, 3) == System.Math.Round(b.Y, 3)
                    && System.Math.Round(a.Z, 3) == System.Math.Round(b.Z, 3)
                ;
        }
        public static bool operator !=(Point a, Point b)
        {
            if (a is null && b is null)
                return false;
            else if (a is null)
                return true;
            else if (b is null)
                return true;
            else
                return
                System.Math.Round(a.X, 3) != System.Math.Round(b.X, 3)
                || System.Math.Round(a.Y, 3) != System.Math.Round(b.Y, 3)
                || System.Math.Round(a.Z, 3) != System.Math.Round(b.Z, 3)
            ;
        }
        public override bool Equals(Object p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return
            System.Math.Round(X, 3) == System.Math.Round((p as Point).X, 3)
            && System.Math.Round(Y, 3) == System.Math.Round((p as Point).Y, 3)
            && System.Math.Round(Z, 3) == System.Math.Round((p as Point).Z, 3);
        }

        public override int GetHashCode()
        {
            return (int)(X * Y * Z);
        }
    }
}

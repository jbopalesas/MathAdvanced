using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOPaleAPI.MathAdvanced
{ 
    public static class Extensions
    {
        public static double DegreeToRadian(double angle)
        {
            return System.Math.PI * angle / 180.0;
        }
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / System.Math.PI);
        }

        public static bool AppartientSegmentAB(Point A, Point B, Point C, double Tolerance = 0)
        {
            Vecteur v1 = new Vecteur(A, B);
            Vecteur v2 = new Vecteur(A, C);

            Vecteur v = v1 ^ v2;
            if (System.Math.Abs(v.Norme) <= System.Math.Abs(Tolerance))
            {
                double Kac = v1.dot(v2);
                double Colineaire = System.Math.Abs(1 - Kac / (v1.Norme * v2.Norme));
                if (Colineaire <= System.Math.Abs(Tolerance) && v1.Norme >= v2.Norme)
                    return true;
            }


            return false;
        }

        public static int IntersectionCercleSegment(Point pCentre, double rayon, Point pA, Point pB, double toleranceX, double toleranceY, out double[][] intersect)
        {
            intersect = new double[2][];

            double Ax = pA.X;
            double Ay = pA.Y;
            double Bx = pB.X;
            double By = pB.Y;
            double Ox = pCentre.X + toleranceX;
            double Oy = pCentre.Y + toleranceY;

            double dx = Bx - Ax;
            double dy = By - Ay;
            double A = dx * dx + dy * dy;
            double B = 2 * (dx * (Ax - Ox) + dy * (Ay - Oy));
            double C = (Ax - Ox) * (Ax - Ox) + (Ay - Oy) * (Ay - Oy) - rayon * rayon;

            double delta = B * B - 4 * A * C;

            double racine1 = -1;
            double X1 = -1;
            double Y1 = -1;
            double racine2 = -1;
            double X2 = -1;
            double Y2 = -1;

            if (delta < 0)
            {
                return 0;
            }
            else if (delta == 0)
            {
                racine1 = -B / (2 * A);
                X1 = racine1 * dx + Ax;
                Y1 = racine1 * dy + Ay;
            }
            else
            {

                racine1 = (-B - System.Math.Sqrt(delta)) / (2 * A);
                X1 = racine1 * dx + Ax;
                Y1 = racine1 * dy + Ay;

                racine2 = (-B + System.Math.Sqrt(delta)) / (2 * A);
                X2 = racine2 * dx + Ax;
                Y2 = racine2 * dy + Ay;
            }
            intersect[0] = new double[3] { racine1, X1, Y1 };
            intersect[1] = new double[3] { racine2, X2, Y2 };

            return 1;
        }

        public static int IntersectionSegmentSegment(Point pA, Point pB, Point pC, Point pD, out Point intersect)
        {
            intersect = null;// new Point();

            double Ax = pA.X;
            double Ay = pA.Y;
            double Bx = pB.X;
            double By = pB.Y;
            double Cx = pC.X;
            double Cy = pC.Y;
            double Dx = pD.X;
            double Dy = pD.Y;

            double[] AB = new double[2] { Bx - Ax, By - Ay };
            double[] CD = new double[2] { Dx - Cx, Dy - Cy };
            double prodVect = AB[0] * CD[1] - CD[0] * AB[1];

            //vecteur collineaires
            if (prodVect == 0) return 0;

            bool denomPositive = prodVect > 0;

            double[] CA = new double[2] { Ax - Cx, Ay - Cy };
            double s_numer = AB[0] * CA[1] - CA[0] * AB[1];
            if ((s_numer < 0) == denomPositive)
                return 0; // No collision

            double t_numer = CD[0] * CA[1] - CA[0] * CD[1];
            if ((t_numer < 0) == denomPositive)
                return 0; // No collision

            if (((s_numer > prodVect) == denomPositive) || ((t_numer > prodVect) == denomPositive))
                return 0; // No collision

            // Collision detected
            double t = t_numer / prodVect;

            intersect = new Point();
            intersect.X = Ax + (t * AB[0]);
            intersect.Y = Ay + (t * AB[1]);

            return 1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOPaleAPI.MathAdvanced
{
    /// <summary>
    /// 
    /// </summary>
    public class Vecteur : System.Object
    {
        private double _X = 0.0;
        public double X
        {
            get { return _X; }
            set { _X = value; CalculerNorme(); }
        }
        private double _Y = 0.0;
        public double Y
        {
            get { return _Y; }
            set { _Y = value; CalculerNorme(); }
        }
        private double _Z = 0.0;
        public double Z
        {
            get { return _Z; }
            set { _Z = value; CalculerNorme(); }
        }
        public double Norme { get; private set; }

        public Vecteur()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        public Vecteur(double tX, double tY, double tZ, bool bNorme = false)
        {
            this.X = tX;
            this.Y = tY;
            this.Z = tZ;
            double tNorme = Norme;
            if (bNorme && tNorme != 0)//Gardé le vecteur normé même après modification X Y Z
            {
                this.X = (tX) / tNorme;
                this.Y = (tY) / tNorme;
                this.Z = (tZ) / tNorme;
            }
        }
        public Vecteur(double[] pts)
        {
            this.X = pts[0];
            this.Y = pts[1];
            this.Z = pts[2];
        }
        public Vecteur(double[,] pts)
        {
            this.X = pts[0, 0];
            this.Y = pts[0, 1];
            this.Z = pts[0, 2];
        }
        public Vecteur(Point v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }
        public Vecteur(Point A, Point B, bool bNorme = false)
        {
            this.X = B.X - A.X;
            this.Y = B.Y - A.Y;
            this.Z = B.Z - A.Z;
            double tNorme = Norme;
            if (bNorme && tNorme != 0)//Gardé le vecteur normé même après modification X Y Z
            {
                this.X = (B.X - A.X) / tNorme;
                this.Y = (B.Y - A.Y) / tNorme;
                this.Z = (B.Z - A.Z) / tNorme;
            }
        }
        public void Normalisation()
        {
            double tX = X;
            double tY = Y;
            double tZ = Z;
            double tNorme = Norme;
            if (tNorme != 0)//Gardé le vecteur normé même après modification X Y Z
            {
                this.X = (tX) / tNorme;
                this.Y = (tY) / tNorme;
                this.Z = (tZ) / tNorme;
            }
        }

        private void CalculerNorme()
        {
            Norme = System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        //Produit Scalaire
        public double dot(Vecteur V)
        {
            return X * V.X + Y * V.Y + Z * V.Z;
        }

        public static Vecteur operator +(Vecteur a, Vecteur b)
        {
            Vecteur v = new Vecteur();
            v.X = a.X + b.X;
            v.X = a.Y + b.Y;
            v.X = a.Z + b.Z;
            return v;
        }
        public static Vecteur operator *(Vecteur a, double b)
        {
            Vecteur v = new Vecteur();
            v.X = a.X * b;
            v.X = a.Y * b;
            v.X = a.Z * b;
            return v;
        }
        //Produit vectorielle
        public static Vecteur operator ^(Vecteur a, Vecteur b)
        {
            Vecteur v = new Vecteur();
            v.X = a.Y * b.Z - a.Z * b.Y;
            v.X = a.Z * b.X - a.X * b.Z;
            v.X = a.X * b.Y - a.Y * b.X;
            return v;
        }
        public static bool operator ==(Vecteur a, Vecteur b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(Vecteur a, Vecteur b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null || !(obj is Vecteur)) return false;

            Vecteur b = obj as Vecteur;

            return this.X == b.X && this.Y == b.Y && this.Z == b.Z;
        }
        public override int GetHashCode()
        {
            return (int)(X * Y * Z);
        }
    }
}

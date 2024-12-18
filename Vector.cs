using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ViewTransform2
{
    public class Vector
    {
        private double[] vec = new double[4];
        public Vector()
        {
            vec[0] = 0.0;
            vec[1] = 0.0;
            vec[2] = 0.0;
            vec[3] = 1.0;
        }
        public Vector(double x, double y, double z)
        {
            vec[0] = x;
            vec[1] = y;
            vec[2] = z;
            vec[3] = 1.0;
        }
        public double this[int index]
        {
            get => vec[index];
            set => vec[index] = value;
        }
        //public static void Swap(ref Vector v1, ref Vector v2)
        //{
        //    Vector temp;
        //    temp = v1;
        //    v1 = v2;
        //    v2 = temp;
        //}
        //public void round()
        //{
        //    vec[0] = (int)(vec[0] + 0.5);
        //    vec[1] = (int)(vec[1] + 0.5); 
        //}
        private double LenVec()
        {
            double len = Math.Sqrt(vec[0] * vec[0] + vec[1] * vec[1] + vec[2] * vec[2]);
            return len;
        }
        public void Normalize()
        {
            double l = 1.0;
            vec[0] = vec[0] * (l / LenVec());
            vec[1] = vec[1] * (l / LenVec());
            vec[2] = vec[2] * (l / LenVec());
        }
        static public Vector operator ^(Vector v1, Vector v2)   //Умножение двух векторов
        {
            Vector v = new Vector();
            v[0] = v1[1] * v2[2] - v1[2] * v2[1];
            v[1] = v1[2] * v2[0] - v1[0] * v2[2];
            v[2] = v1[0] * v2[1] - v1[1] * v2[0];
            v.Normalize();
            return v;
        }
        static public Vector operator -(Vector v1, Vector v2)   //Вычитание векторов
        {
            Vector v = new Vector();
            v[0] = v1[0] - v2[0];
            v[1] = v1[1] - v2[1];
            v[2] = v1[2] - v2[2];
            return v;
        }
        static public Vector operator +(Vector v1, Vector v2)   //Сложение векторов
        {
            Vector v = new Vector();
            v[0] = v1[0] + v2[0];
            v[1] = v1[1] + v2[1];
            v[2] = v1[2] + v2[2];
            return v;
        }
        static public Vector operator *(Vector v1, double val)   //Умножение вектора на число
        {
            Vector v = new Vector();
            v[0] = v1[0] * val;
            v[1] = v1[1] * val;
            v[2] = v1[2] * val;
            return v;
        }

        public static Vector operator *(Matrix m, Vector v)
        {
            Vector v1 = new Vector();
            v1[3] = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    v1[i] += m[i, j] * v[j];
                }
            }
            return v1;
        }
    }
}

//public double x
//{   get { return X; }
//    set { X = value; }  
//}

//public double y
//{ get { return Y; }
//  set { Y = value; }  
//} 

//public double z
//{ get { return Z; }
//  set { Z = value; }  
//}

//public double w
//{ get { return W; }
//  set { W = value; }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class Matrix_Gausa
    {
        public static void NoOne(ref double[,] matrix, ref double[] mas_b, int a)
        {
            double c = matrix[a, a];
            mas_b[a] = mas_b[a] / c;
            for (int i = a; i < matrix.GetLength(0); i++)
            {
                for (int j = a; j < matrix.GetLength(1); j++) matrix[i, j] = matrix[i, j] / c;
                break;
            }
        }

        public static void Zero(ref double[,] matrix, ref double[] mas_b, int a)
        {
            int k = a;
            while (k != mas_b.Length - 1)
            {
                double c1 = matrix[k + 1, a];
                mas_b[k + 1] = mas_b[k + 1] - c1 * mas_b[a];
                for (int f = a; f < mas_b.Length; f++) matrix[k + 1, f] = matrix[k + 1, f] - c1 * matrix[a, f];
                k++;
            }
        }


        public static double[] Gause(ref double[,] matrix, ref double[] mas_b)
        {
            int size = mas_b.Length;
            double[] mas_det = new double[size];

            double[,] matr = new double[4, 4];
            double[] mas_x = new double[size];
            for (int i = 0; i < size; i++) for (int j = 0; j < size; j++) matr[i, j] = matrix[i, j];

            int p = 0;
            int m = 0;
            int l = 0;
            while (p != size)
            {
                if (m != 1)
                {
                    if (p == 0)
                    {
                        if (matrix[0, 0] != 0)
                        {
                            mas_det[p] = matrix[p, p];
                            NoOne(ref matrix, ref mas_b, p);
                        }
                        if (matrix[0, 0] == 0)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                matrix[0, i] = matrix[1, i];
                                matrix[1, i] = matr[0, i];
                            }
                            l = 1;
                            double temp = mas_b[0];
                            mas_b[0] = mas_b[1];
                            mas_b[1] = temp;
                            mas_det[p] = matrix[p, p];
                            NoOne(ref matrix, ref mas_b, p);
                        }
                        Zero(ref matrix, ref mas_b, p);
                        p++;
                    }
                    else
                    {
                        if (matrix[p, p] != 0)
                        {
                            mas_det[p] = matrix[p, p];
                            NoOne(ref matrix, ref mas_b, p);
                            Zero(ref matrix, ref mas_b, p);
                            p++;
                        }
                        else m = 1;
                    }
                }
                else break;
            }
            if (m != 1)
            {
                double dob = 1;
                if (l == 0) for (int i = 0; i < size; i++)  dob = dob * mas_det[i];
                if (l == 1) for (int i = 0; i < size; i++) dob = dob * mas_det[i];
                for (int i = 0; i < size; i++) mas_x[i] = 0;
                mas_x[size - 1] = mas_b[size - 1];
                for (int i = size - 2; i >= 0; i--)
                {
                    double d = 0;
                    for (int j = 0; j < size; j++) d += mas_x[j] * matrix[i, j];
                    mas_x[i] = (mas_b[i] - d) / matrix[i, i];
                }
            }
            return mas_x;
        }
    }
}

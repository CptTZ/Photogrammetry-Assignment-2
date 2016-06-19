using System;

namespace XDDX.Algorithm
{
    /// <summary>
    /// 矩阵计算类
    /// TonyZ
    /// </summary>
    public static class MatrixOperation
    {
        /// <summary>
        /// 矩阵求逆
        /// </summary>
        public static Matrix Inverse(Matrix Ma)
        {
            return new Matrix(new MatrixInverse(Ma.Data).InversedMatrix, true);
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        public static Matrix MatrixTrans(Matrix Ma)
        {
            int m = Ma.Hang, n = Ma.Lie;

            Matrix Mc = new Matrix(n, m);
            double[,] c = Mc.Data;
            double[,] a = Ma.Data;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    c[i, j] = a[j, i];

            return Mc;
        }

        /// <summary>
        /// 矩阵相加
        /// </summary>
        public static Matrix Add(Matrix Ma, Matrix Mb)
        {
            int m = Ma.Hang,
                n = Ma.Lie,
                m2 = Mb.Hang,
                n2 = Mb.Lie;

            if ((m != m2) || (n != n2)) throw new Exception("数组维数不匹配");
            
            Matrix Mc = new Matrix(m, n);
            double[,] c = Mc.Data, a = Ma.Data, b = Mb.Data;

            int i, j;
            for (i = 0; i < m; i++)
                for (j = 0; j < n; j++)
                    c[i, j] = a[i, j] + b[i, j];

            return Mc;
        }

        /// <summary>
        /// 矩阵数乘
        /// </summary>
        public static Matrix SimpleMultiply(double k, Matrix Ma)
        {
            int m = Ma.Hang,
                n = Ma.Lie;

            Matrix Mc = new Matrix(m, n);
            double[,] c = Mc.Data, a = Ma.Data;

            int i, j;
            for (i = 0; i < m; i++)
                for (j = 0; j < n; j++)
                    c[i, j] = a[i, j] * k;

            return Mc;
        }

        /// <summary>
        /// 矩阵乘
        /// </summary>
        public static Matrix Multiply(Matrix Ma, Matrix Mb)
        {
            int m = Ma.Hang,
                n = Ma.Lie,
                m2 = Mb.Hang,
                n2 = Mb.Lie;

            if (n != m2) throw new Exception("数组维数不匹配");

            Matrix Mc = new Matrix(m, n2);
            double[,] c = Mc.Data, a = Ma.Data, b = Mb.Data;

            int i, j;
            for (i = 0; i < m; i++)
                for (j = 0; j < n2; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < n; k++)
                        c[i, j] += a[i, k] * b[k, j];
                }

            return Mc;
        }

        /// <summary>
        /// 矩阵减
        /// </summary>
        public static Matrix Sub(Matrix Ma, Matrix Mb)
        {
            int m = Ma.Hang,
                n = Ma.Lie,
                m2 = Mb.Hang,
                n2 = Mb.Lie;

            if ((m != m2) || (n != n2)) throw new Exception("数组维数不匹配");

            Matrix Mc = new Matrix(m, n);
            double[,] c = Mc.Data, a = Ma.Data, b = Mb.Data;

            int i, j;
            for (i = 0; i < m; i++)
                for (j = 0; j < n; j++)
                    c[i, j] = a[i, j] - b[i, j];

            return Mc;
        }

    }

    /// <summary>
    /// 矩阵
    /// </summary>
    public class Matrix
    {
        public double[,] Data { get; private set; }
        public int Hang { get; private set; }
        public int Lie { get; private set; }

        public Matrix(int am, int an)
        {
            this.Hang = am;
            this.Lie = an;
            this.Data = new double[Hang, Lie];
        }

        /// <summary>
        /// 从数组创建矩阵
        /// </summary>
        /// <param name="dat">数组</param>
        /// <param name="simpleMode">是否浅拷贝</param>
        public Matrix(double[,] dat, bool simpleMode = false)
        {
            this.Hang = dat.GetLength(0);
            this.Lie = dat.GetLength(1);

            if (simpleMode)
            {
                this.Data = dat;
                return;
            }

            this.Data = new double[dat.GetLength(0), dat.GetLength(1)];
            for (int i = 0; i < this.Hang; i++)
            {
                for (int j = 0; j < this.Lie; j++)
                {
                    this.Data[i, j] = dat[i, j];
                }
            }
        }

        public static Matrix operator /(int a, Matrix b)
        {
            if (a != 1) throw new ArgumentException("除数必须为1");
            return new Matrix(new MatrixInverse(b.Data).InversedMatrix, true);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return MatrixOperation.Sub(a, b);
        }

        public static Matrix operator *(Matrix b, double a)
        {
            return MatrixOperation.SimpleMultiply(a, b);
        }

        public static Matrix operator *(double a, Matrix b)
        {
            return MatrixOperation.SimpleMultiply(a, b);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return MatrixOperation.Multiply(a, b);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return MatrixOperation.Add(a, b);
        }

        /// <summary>
        /// 产生对角阵
        /// </summary>
        public void MakeE()
        {
            if (Hang != Lie) throw new FormatException("必须为方阵！");
            for (int i = 0; i < Hang; i++)
            {
                Data[i, i] = 1;
            }
        }
    }
}

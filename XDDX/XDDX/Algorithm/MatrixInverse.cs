using System;
using System.Collections.Generic;

namespace XDDX.Algorithm
{
    /// <summary>
    /// 高斯-约旦法求逆矩阵
    /// </summary>
    internal class MatrixInverse
    {
        public double[,] InversedMatrix { get; private set; }

        private readonly double[,] _oriMatrix;
        private readonly int nRow, nCol;

        /// <summary>
        /// 矩阵求逆
        /// </summary>
        /// <param name="m"></param>
        public MatrixInverse(double[,] m)
        {
            this._oriMatrix = m;
            nRow = _oriMatrix.GetLength(0);
            nCol = _oriMatrix.GetLength(1);

            if (nRow != nCol)
            {
                throw new ArgumentException("矩阵不是方阵");
            }

            InversedMatrix = new double[nRow, nCol];
            this.StartInverse();
        }

        /// <summary>
        /// 从第k行列往下寻找最大值
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private double[] findMax(double[,] arr, int k)
        {
            int len = arr.GetLength(0);
            double[] isMax =
            {
                arr[k, k],
                k, k
            };

            for (int i = k; i < len; i++)
            {
                for (int j = k; j < len; j++)
                {
                    if (Math.Abs(arr[i, j]) > Math.Abs(isMax[0]))
                    {
                        isMax[0] = arr[i, j];
                        isMax[1] = i;
                        isMax[2] = j;
                    }
                }
            }

            return isMax;
        }

        /// <summary>
        /// 行变换 
        /// </summary>
        /// <param name="Arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void rSwap(double[,] Arr, int i, int j)
        {
            if (i >= Arr.GetLength(0) || j >= Arr.GetLength(0)) return;

            for (int k = 0; k < Arr.GetLength(1); k++)
            {
                var tmp = Arr[i, k];
                Arr[i, k] = Arr[j, k];
                Arr[j, k] = tmp;
            }
        }

        /// <summary>
        /// 列变换
        /// </summary>
        /// <param name="Arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void cSwap(double[,] Arr, int i, int j)
        {
            if (i >= Arr.GetLength(1) || j >= Arr.GetLength(1)) return;

            for (int k = 0; k < Arr.GetLength(0); k++)
            {
                var tmp = Arr[k, i];
                Arr[k, i] = Arr[k, j];
                Arr[k, j] = tmp;
            }
        }

        /// <summary>
        /// 扩展出对角矩阵
        /// </summary>
        /// <returns></returns>
        private double[,] GenerateExtendMatrix()
        {
            double[,] mArr = new double[nRow, nCol * 2];
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    mArr[i, j] = _oriMatrix[i, j];
                    mArr[i, i + nCol] = 1;
                }
            }

            return mArr;
        }

        private void StartInverse()
        {
            //寻找主元，用于记录列变换 
            List<int> ColSwapRecord = new List<int>();
            double[,] extMatrix = GenerateExtendMatrix();

            for (int i = 0; i < nRow; i++)
            {
                double[] iMax = findMax(extMatrix, i);
                if (Math.Abs(iMax[0]) > 1E-30)  //iMax[0]!=0
                {
                    rSwap(extMatrix, (int)(iMax[1] + 0.5), i);
                    cSwap(extMatrix, (int)(iMax[2] + 0.5), i);
                    ColSwapRecord.Add((int)(iMax[2] + 0.5));
                    
                    MainFactorToOne(extMatrix, i, iMax);
                    ReduceFactor(i, extMatrix);
                }
                else
                {
                    throw new ArgumentException("矩阵不可逆");
                }
            }

            MakeInversedMatrix(extMatrix, ColSwapRecord);
        }

        /// <summary>
        /// 从扩展矩阵生成逆矩阵
        /// </summary>
        /// <param name="mArr"></param>
        /// <param name="swapCol"></param>
        private void MakeInversedMatrix(double[,] mArr, List<int> swapCol)
        {
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    InversedMatrix[i, j] = mArr[i, j + nCol];
                }
            }

            for (int i = nRow - 1; i >= 0; i--)
            {
                rSwap(InversedMatrix, swapCol[i], i);
            }
        }

        /// <summary>
        /// 主元化为1
        /// </summary>
        /// <param name="mArr"></param>
        /// <param name="i"></param>
        /// <param name="iMax"></param>
        private void MainFactorToOne(double[,] mArr, int i, double[] iMax)
        {
            for (int j = 0; j < nCol*2; j++)
            {
                mArr[i, j] = mArr[i, j]/iMax[0];
            }
        }

        /// <summary>
        /// 消元
        /// </summary>
        /// <param name="i"></param>
        /// <param name="mArr"></param>
        private void ReduceFactor(int i, double[,] mArr)
        {
            for (int k = 0; k < nRow; k++)
            {
                if (k != i)
                {
                    double n = mArr[k, i];
                    for (int j = 0; j < nCol*2; j++)
                    {
                        mArr[k, j] = mArr[k, j] - n*mArr[i, j];
                    }
                }
            }
        }
    }
}
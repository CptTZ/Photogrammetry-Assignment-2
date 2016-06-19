using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;
using XDDX.DataStruct;

namespace XDDX.Algorithm
{
    public class RelativeOrientation
    {

        #region 定义的一些公有属性
        /// <summary>
        /// 航向倾角
        /// </summary>
        public double p { get; private set; }

        /// <summary>
        /// 旁向倾角
        /// </summary>
        public double w { get; private set; }

        /// <summary>
        /// 像片旋角
        /// </summary>
        public double k { get; private set; }

        /// <summary>
        /// 迭代计数
        /// </summary>
        public int ItCount { get; private set; }

        #endregion

        private double _limits = 0.001;

        /// <summary>
        /// 设置限差
        /// </summary>
        public void SetLimit(double a)
        {
            this._limits = a;
        }

        public double GetLimit()
        {
            return this._limits;
        }

        /// <summary>
        /// 相对定向元素计算
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="cam">相机参数</param>
        public RelativeOrientation(List<Dictionary<string, double>> data, CameraPara cam)
        {
            
        }

        public void Process()
        {
            MainLoop();
        }

        /// <summary>
        /// 初始化定向元素
        /// </summary>
        private void InitialFactor()
        {
            this.p = 0;
            this.w = 0;
            this.k = 0;
        }

        private void MainLoop()
        {
            do
            {


            } while (!HasLimited(null));
        }

        /// <summary>
        /// 是否收敛，以结束计算
        /// </summary>
        private bool HasLimited(double[,] final)
        {
            if (this.ItCount > 500000) throw new Exception("迭代超过50W次无结果，该方程很可能不收敛");

            for (int i = 0; i < final.GetLength(0); i++)
            {
                if (Abs(final[i, 0]) > _limits)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 计算旋转矩阵R
        /// PPT:2-2.P31（P32为展开后的结果）
        /// </summary>
        /// <returns>R阵</returns>
        private Matrix MatrixR()
        {
            double[,]
                Rp =
                {
                    {Cos(this.p), 0, -Sin(this.p)},
                    {0, 1, 0},
                    {Sin(this.p), 0, Cos(this.p)}
                },
                Rw =
                {
                    {1, 0, 0},
                    {0, Cos(this.w), -Sin(this.w)},
                    {0, Sin(this.w), Cos(this.w)}
                },
                Rk =
                {
                    {Cos(this.k), -Sin(this.k), 0},
                    {Sin(this.k), Cos(this.k), 0},
                    {0, 0, 1}
                };

            Matrix mp = new Matrix(Rp, true),
                mw = new Matrix(Rw, true),
                mk = new Matrix(Rk, true);
            return mp * mw * mk;
        }

    }
}

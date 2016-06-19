using System;
using System.Collections.Generic;
using static System.Math;
using XDDX.DataStruct;

namespace XDDX.Algorithm
{
    /// <summary>
    /// 单独相对相对定向元素求解
    /// 学习用，未优化
    /// </summary>
    public class RelativeOrientation
    {
        #region 定义的一些公有属性
        /// <summary>
        /// 航向倾角
        /// </summary>
        public double p1 { get; private set; }

        /// <summary>
        /// 旁向倾角
        /// </summary>
        public double k1 { get; private set; }
        
        /// <summary>
        /// 航向倾角
        /// </summary>
        public double p2 { get; private set; }

        /// <summary>
        /// 旁向倾角
        /// </summary>
        public double w2 { get; private set; }

        /// <summary>
        /// 像片旋角
        /// </summary>
        public double k2 { get; private set; }

        /// <summary>
        /// 迭代计数
        /// </summary>
        public int ItCount { get; private set; }

        #endregion

        /// <summary>
        /// 第一次迭代的A/L
        /// </summary>
        public Matrix FirstL, FirstA;

        private double _limits = 0.001, w1 = 0;
        private readonly List<Dictionary<string, double>> _data;
        private readonly CameraPara _cam;

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
            this._data = data;
            this._cam = cam;

            InitialFactor();
        }

        /// <summary>
        /// 过程参考PPT:4-2:P27
        /// </summary>
        public void Process()
        {
            MainLoop();
        }

        /// <summary>
        /// 初始化定向元素
        /// </summary>
        private void InitialFactor()
        {
            this.p1 = 0;
            this.w1 = 0;
            this.k1 = 0;
            this.p2 = 0;
            this.w2 = 0;
            this.k2 = 0;
            this.ItCount = 0;
        }

        /// <summary>
        /// 过程参考书P85 
        /// </summary>
        private void MainLoop()
        {
            double[,] dFinal = null;
            do
            {
                var r1r2 = MatrixR();
                var auxCoord = CalcAuxCoord(r1r2);
                var A = CalcErrorA(auxCoord);
                var L = CalcErrorL(auxCoord);

                if (this.ItCount == 0)
                {
                    this.FirstA = A;
                    this.FirstL = L;
                }

                // 公式见书P83(5-27)
                var AT = MatrixOperation.MatrixTrans(A);
                dFinal = ((1 / (AT * A)) * AT * L).Data;

                // 叠加结果
                this.p1 += dFinal[0, 0];
                this.k1 += dFinal[1, 0];
                this.p2 += dFinal[2, 0];
                this.w2 += dFinal[3, 0];
                this.k2 += dFinal[4, 0];

                this.ItCount++;
            } while (!HasLimited(dFinal));
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
        /// 计算误差常数
        /// 系数参考书P84(5-29)
        /// </summary>
        /// <param name="aux">辅助空间坐标系的数值</param>
        /// <returns>n*1</returns>
        private Matrix CalcErrorL(Matrix[,] aux)
        {
            double[,] res = new double[this._data.Count, 1];
            var f = this._cam.f;

            for (int i = 0; i < this._data.Count; i++)
            {
                var l = aux[0, i].Data;
                var r = aux[1, i].Data;
                double v1 = l[1, 0],
                    w1 = l[2, 0],
                    v2 = r[1, 0],
                    w2 = r[2, 0];

                res[i, 0] = -f * v1 / w1 + f * v2 / w2;
            }

            return new Matrix(res, true);
        }

        /// <summary>
        /// 计算误差系数A
        /// 系数参考书P84(5-28)，注意k1与k2和PPT不同
        /// </summary>
        /// <param name="aux">辅助空间坐标系的数值</param>
        /// <returns>n*5</returns>
        private Matrix CalcErrorA(Matrix[,] aux)
        {
            double[,] res = new double[this._data.Count, 5];
            var f = this._cam.f;

            for (int i = 0; i < this._data.Count; i++)
            {
                var l = aux[0, i].Data;
                var r = aux[1, i].Data;
                double u1 = l[0, 0],
                    v1 = l[1, 0],
                    w1 = l[2, 0],
                    u2 = r[0, 0],
                    v2 = r[1, 0],
                    w2 = r[2, 0];

                res[i, 0] = u1 * v2 / w2;
                res[i, 2] = -u2 * v1 / w1;
                res[i, 3] = f * (1 + (v1 * v2) / (w1 * w2));
                res[i, 1] = -u1;
                res[i, 4] = u2;
            }

            return new Matrix(res, true);
        }

        /// <summary>
        /// 辅助空间坐标系的数值
        /// 书：P80（5-16）下的公式
        /// PPT：4-2：P21
        /// </summary>
        /// <returns>第一维表示左和右，第二纬表示坐标</returns>
        private Matrix[,] CalcAuxCoord(Matrix[] r)
        {
            Matrix[,] res = new Matrix[2, this._data.Count];
            var f = this._cam.f;

            for (int i = 0; i < this._data.Count; i++)
            {
                Matrix
                    lData = new Matrix(new[,]
                    {
                        {_data[i]["lXa"]},
                        {_data[i]["lYa"]},
                        {-f}
                    }, true),
                    rData = new Matrix(new[,]
                    {
                        {_data[i]["rXa"]},
                        {_data[i]["rYa"]},
                        {-f}
                    }, true);

                res[0, i] = r[0] * lData;
                res[1, i] = r[1] * rData;
            }

            return res;
        }

        /// <summary>
        /// 计算旋转矩阵R
        /// PPT:2-2.P31（P32为展开后的结果）
        /// </summary>
        /// <returns>R阵</returns>
        private Matrix[] MatrixR()
        {
            double[,]
                Rp =
                {
                    {Cos(this.p1), 0, -Sin(this.p1)},
                    {0, 1, 0},
                    {Sin(this.p1), 0, Cos(this.p1)}
                },
                Rw =
                {
                    {1, 0, 0},
                    {0, Cos(this.w1), -Sin(this.w1)},
                    {0, Sin(this.w1), Cos(this.w1)}
                },
                Rk =
                {
                    {Cos(this.k1), -Sin(this.k1), 0},
                    {Sin(this.k1), Cos(this.k1), 0},
                    {0, 0, 1}
                },
                Rp1 =
                {
                    {Cos(this.p2), 0, -Sin(this.p2)},
                    {0, 1, 0},
                    {Sin(this.p2), 0, Cos(this.p2)}
                },
                Rw1 =
                {
                    {1, 0, 0},
                    {0, Cos(this.w2), -Sin(this.w2)},
                    {0, Sin(this.w2), Cos(this.w2)}
                },
                Rk1 =
                {
                    {Cos(this.k2), -Sin(this.k2), 0},
                    {Sin(this.k2), Cos(this.k2), 0},
                    {0, 0, 1}
                };

            Matrix
                mp = new Matrix(Rp, true),
                mw = new Matrix(Rw, true),
                mk = new Matrix(Rk, true),
                mp1 = new Matrix(Rp1, true),
                mw1 = new Matrix(Rw1, true),
                mk1 = new Matrix(Rk1, true);

            return new[] { mp * mw * mk, mp1 * mw1 * mk1 };
        }
    }
}

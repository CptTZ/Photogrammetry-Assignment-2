
namespace XDDX.DataStruct
{
    /// <summary>
    /// 数据表
    /// </summary>
    public class DataList
    {
        /// <summary>
        /// 点号
        /// </summary>
        public int PointNumber { get; private set; }

        /// <summary>
        /// 左影像列号
        /// </summary>
        public double LeftColNumber { get; private set; }

        /// <summary>
        /// 右影像列号
        /// </summary>
        public double RightColNumber { get; private set; }

        /// <summary>
        /// 左影像行号
        /// </summary>
        public double LeftRowNumber { get; private set; }

        /// <summary>
        /// 右影像行号
        /// </summary>
        public double RightRowNumber { get; private set; }

        /// <summary>
        /// X坐标右
        /// </summary>
        public double rX { get; private set; }

        /// <summary>
        /// Y坐标右
        /// </summary>
        public double rY { get; private set; }

        /// <summary>
        /// Y坐标左
        /// </summary>
        public double lY { get; private set; }

        /// <summary>
        /// X坐标左
        /// </summary>
        public double lX { get; private set; }

        /// <summary>
        /// 初始化数据表
        /// </summary>
        /// <param name="num">点号</param>
        /// <param name="lc">左影像列号</param>
        /// <param name="lr">左影像行号</param>
        /// <param name="rc">右影像列号</param>
        /// <param name="rr">右影像行号</param>
        public DataList(int num, double lc, double lr, double rc, double rr)
        {
            this.PointNumber = num;
            this.LeftColNumber = lc;
            this.RightColNumber = rc;
            this.LeftRowNumber = lr;
            this.RightRowNumber = rr;
        }

        /// <summary>
        /// 设置X坐标左
        /// </summary>
        /// <param name="val">设置值</param>
        public void SetlX(double val)
        {
            this.lX = val;
        }

        /// <summary>
        /// 设置Y坐标左
        /// </summary>
        /// <param name="val">设置值</param>
        public void SetlY(double val)
        {
            this.lY = val;
        }

        /// <summary>
        /// 设置X坐标右
        /// </summary>
        /// <param name="val">设置值</param>
        public void SetrX(double val)
        {
            this.rX = val;
        }

        /// <summary>
        /// 设置Y坐标右
        /// </summary>
        /// <param name="val">设置值</param>
        public void SetrY(double val)
        {
            this.rY = val;
        }

    }
}

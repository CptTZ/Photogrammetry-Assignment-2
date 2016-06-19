using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDDX.DataStruct;

namespace XDDX.Algorithm
{
    public class ImagePaneCoord
    {
        private readonly List<Dictionary<string, double>> _existMatch = new List<Dictionary<string, double>>();
        private readonly double _h0, _l0;
        private readonly CameraPara _camData;

        /// <summary>
        /// 像平面坐标转换，拷贝自作业-1
        /// </summary>        
        /// <param name="data">匹配线数据</param>
        /// <param name="cam">相机参数</param>
        public ImagePaneCoord(List<DataList> data, CameraPara cam)
        {
            this._camData = cam;
            // PPT:4-1.P9 什么鬼，怎么突然这么简单了，害我调试了10分钟……………………
            /*_l0 = (_camData.WidthPix - 1) / 2.0 + _camData.MainPosXPix;
            _h0 = (_camData.HeightPix - 1) / 2.0 + _camData.MainPosYPix;*/
            this._l0 = cam.MainPosXPix;
            this._h0 = cam.MainPosYPix;

            MakeMatchList(data);
        }

        /// <summary>
        /// 获取算好的数据字典
        /// </summary>
        /// <returns>数据字典</returns>
        public List<Dictionary<string, double>> GetDictionaryForCalculation()
        {
            return this._existMatch;
        }

        public void FillData(List<DataList> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (Math.Abs(data[i].PointNumber - _existMatch[i]["ID"]) > 0.1)
                    throw new Exception("顺序改变，错误");
                data[i].SetlX(Math.Round(_existMatch[i]["lXa"], 7));
                data[i].SetrX(Math.Round(_existMatch[i]["rXa"], 7));
                data[i].SetlY(Math.Round(_existMatch[i]["lYa"], 7));
                data[i].SetrY(Math.Round(_existMatch[i]["rYa"], 7));
            }
        }

        /// <summary>
        /// 影像上任一像点a(h行,l列)处的像平面坐标(xa, ya)
        /// </summary>
        private void RowColtoImgPaneCoord(double h, double l, out double xa, out double ya)
        {
            // PPT:4-1.P9 
            xa = (l - _l0) * _camData.PixSize;
            ya = (_h0 - h) * _camData.PixSize;
        }

        private void MakeMatchList(List<DataList> data)
        {
            foreach (var t in data)
            {
                var tmp = new Dictionary<string, double>
                {
                    {"ID", t.PointNumber},
                    {"lX", t.lX},
                    {"lY", t.lY},
                    {"rX", t.rX},
                    {"rY", t.rY}
                };
                double xa, ya;

                tmp.Add("lCol", t.LeftColNumber);
                tmp.Add("lRow", t.LeftRowNumber);
                RowColtoImgPaneCoord(t.LeftRowNumber, t.LeftColNumber, out xa, out ya);
                tmp.Add("lXa", xa);
                tmp.Add("lYa", ya);

                tmp.Add("rCol", t.RightColNumber);
                tmp.Add("rRow", t.RightRowNumber);
                RowColtoImgPaneCoord(t.RightRowNumber, t.RightColNumber, out xa, out ya);
                tmp.Add("rXa", xa);
                tmp.Add("rYa", ya);

                _existMatch.Add(tmp);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XDDX.DataStruct
{
    /// <summary>
    /// 相机参数
    /// </summary>
    public class CameraPara
    {
        private readonly StreamReader _sr;

        /// <summary>
        /// 相机名
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// 图像宽度
        /// </summary>
        public int WidthPix { get; private set; }

        /// <summary>
        /// 图像高度
        /// </summary>
        public int HeightPix { get; private set; }

        /// <summary>
        /// 焦距
        /// </summary>
        public double f { get; private set; }

        /// <summary>
        /// 像元尺寸
        /// </summary>
        public double PixSize { get; private set; }

        /// <summary>
        /// 像主点位置x
        /// </summary>
        public double MainPosXPix { get; private set; }

        /// <summary>
        /// 像主点位置y
        /// </summary>
        public double MainPosYPix { get; private set; }

        /// <summary>
        /// 生成相机参数
        /// </summary>
        /// <param name="camfp">参数文件</param>
        public CameraPara(string camfp)
        {
            _sr = new StreamReader(camfp, Encoding.Default);
            Process();
            _sr.Close();
        }

        private void Process()
        {
            _sr.ReadLine();
            this.Type = "作业2相机";
            string aLine = null;
            while ((aLine = _sr.ReadLine()) != null)
            {
                if (aLine.Contains("图像宽度"))
                {
                    if (aLine.Contains("像素"))
                    {
                        this.WidthPix = int.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }
                else if (aLine.Contains("图像高度"))
                {
                    if (aLine.Contains("像素"))
                    {
                        this.HeightPix = int.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }
                else if (aLine.Contains("焦距"))
                {
                    if (aLine.Contains("毫米"))
                    {
                        this.f = double.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }
                else if (aLine.Contains("像元尺寸"))
                {
                    if (aLine.Contains("毫米"))
                    {
                        this.PixSize = double.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }
                else if (aLine.Contains("像主点位置x"))
                {
                    if (aLine.Contains("像素"))
                    {
                        this.MainPosXPix = double.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }
                else if (aLine.Contains("像主点位置y"))
                {
                    if (aLine.Contains("像素"))
                    {
                        this.MainPosYPix = double.Parse(GetNumberInLine(aLine));
                        continue;
                    }
                }

                throw new FormatException("文件格式错误！");
            }
        }

        private readonly Regex _double = new Regex("([0-9]{1,}[.][0-9]*)", RegexOptions.Compiled & RegexOptions.Singleline);
        private readonly Regex _int = new Regex("([0-9]{1,})", RegexOptions.Compiled & RegexOptions.Singleline);

        private string GetNumberInLine(string a)
        {
            var a1 = _double.Match(a).ToString();
            var a2 = _int.Match(a).ToString();

            return a1.Equals("") ? a2 : a1;
        }
    }
}

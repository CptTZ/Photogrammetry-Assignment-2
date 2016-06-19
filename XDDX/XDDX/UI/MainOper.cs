using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDDX.Algorithm;
using XDDX.DataStruct;
using XDDX.Properties;

namespace XDDX.UI
{
    public partial class MainForm
    {
        private CameraPara _camPara;
        private ImagePaneCoord _imgPane;
        private RelativeOrientation _rO;
        private readonly List<DataList> _dataPoint = new List<DataList>();

        /// <summary>
        /// 相对定向
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this._imgPane==null)
            {
                MessageBox.Show("请先打开数据并计算像平面坐标", Resources.Prog_Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _rO = new RelativeOrientation(_imgPane.GetDictionaryForCalculation(), _camPara);
        }

        private void buttonImgPane_Click(object sender, EventArgs e)
        {
            if (_camPara == null | _dataPoint.Count == 0)
            {
                MessageBox.Show("请先打开数据", Resources.Prog_Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                _imgPane = new ImagePaneCoord(_dataPoint, _camPara);
                _imgPane.FillData(_dataPoint);
                UpdateDataGridView();

                #region 保存文件到csv的逻辑，没啥东西
                var s = MessageBox.Show("是否要保存结果？", Resources.Prog_Name, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (s != DialogResult.Yes) return;
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Title = "保存结果",
                    CheckPathExists = true,
                    InitialDirectory = @"E:\大学\大三下\摄影测量学\摄影测量学作业\Data",
                    Filter = "CSV文件(*.csv)|*.csv"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;
                using (StreamWriter sw = new StreamWriter(sfd.OpenFile(), Encoding.Default))
                {
                    sw.WriteLine("点ID,左影像行号,左影像列号,右影像行号,右影像列号,左像平面X,左像平面Y,右像平面X,右像平面Y");
                    foreach (var t in _dataPoint)
                    {
                        sw.WriteLine(t.PointNumber + "," + t.LeftRowNumber + "," + t.LeftColNumber + "," +
                                     t.RightRowNumber + "," + t.RightColNumber
                                     + "," + t.lX + "," + t.lY + "," + t.rX + "," + t.rY);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Prog_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打开数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = MyOpenFileDialog("选择目标点文件", "文本文件(*.txt)|*.txt");
            if (ofd == null) return;

            try
            {
                using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                {
                    int rowCount = int.Parse(sr.ReadLine());

                    _dataPoint.Clear();
                    for (int i = 0; i < rowCount; i++)
                    {
                        var eachData = sr.ReadLine().Split(',');
                        if (eachData.Length != 4) throw new FormatException("文件格式错误！");

                        _dataPoint.Add(
                            new DataList(i + 1,
                                double.Parse(eachData[1]),
                                double.Parse(eachData[0]),
                                double.Parse(eachData[3]),
                                double.Parse(eachData[2]))
                            );
                    }
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Prog_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonOpenCamP_Click(object sender, EventArgs e)
        {
            var ofd = MyOpenFileDialog("选择相机参数文件", "文本文件(*.txt)|*.txt");
            if (ofd == null) return;

            try
            {
                _camPara = new CameraPara(ofd.FileName);
                textBox1.Text = _camPara.Type;
                textBox2.Text = _camPara.WidthPix.ToString("##.0");
                textBox3.Text = _camPara.HeightPix.ToString("##.0");
                textBox4.Text = _camPara.f.ToString("##.00");
                textBox5.Text = _camPara.PixSize.ToString("##.00");
                textBox6.Text = _camPara.MainPosXPix.ToString("0.00");
                textBox7.Text = _camPara.MainPosYPix.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Prog_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

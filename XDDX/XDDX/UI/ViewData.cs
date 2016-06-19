using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDDX.Algorithm;
using XDDX.Properties;

namespace XDDX.UI
{
    public partial class ViewData : Form
    {
        private readonly RelativeOrientation _ro;

        public ViewData(RelativeOrientation r)
        {
            this._ro = r;
            InitializeComponent();
            this.Text = Resources.Prog_Name+" - 相对定向元素查看";

            FillData();
        }

        private void FillData()
        {
            this.textBox1.Text = _ro.p1.ToString("0.########");
            this.textBox2.Text = _ro.p2.ToString("0.########");
            this.textBox3.Text = _ro.w2.ToString("0.########");
            this.textBox4.Text = _ro.k1.ToString("0.########");
            this.textBox5.Text = _ro.k2.ToString("0.########");
            this.textBox7.Text = _ro.ItCount.ToString();
            this.textBox8.Text = _ro.GetLimit().ToString("e2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "保存A矩阵结果",
                CheckPathExists = true,
                InitialDirectory = @"E:\大学\大三下\摄影测量学\摄影测量学作业\Data",
                Filter = "txt文件(*.txt)|*.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.OpenFile(), Encoding.Default))
            {
                StringBuilder sb = new StringBuilder();
                var data = _ro.FirstA.Data;

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sb.Append(data[i, j] + "\t");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                sw.Write(sb.ToString());
            }
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "保存L矩阵结果",
                CheckPathExists = true,
                InitialDirectory = @"E:\大学\大三下\摄影测量学\摄影测量学作业\Data",
                Filter = "txt文件(*.txt)|*.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.OpenFile(), Encoding.Default))
            {
                StringBuilder sb = new StringBuilder();
                var data = _ro.FirstL.Data;

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sb.Append(data[i, j] + "\t");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                sw.Write(sb.ToString());
            }
        }
    }
}

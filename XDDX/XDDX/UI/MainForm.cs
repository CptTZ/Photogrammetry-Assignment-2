using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XDDX.Algorithm;
using XDDX.Properties;

namespace XDDX.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = Resources.Prog_Name;
        }

        private void UpdateDataGridView()
        {
            dataPoint.DataSource = _dataPoint;
            dataPoint.AutoResizeColumns();
            dataPoint.Invalidate();
        }

        private OpenFileDialog MyOpenFileDialog(string def, string filter)
        {
            var ofd = new OpenFileDialog
            {
                ValidateNames = true,
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = @"E:\大学\大三下\摄影测量学\摄影测量学作业\Data",
                Multiselect = false,
                Title = def + " - " + Resources.Prog_Name,
                Filter = filter
            };

            return ofd.ShowDialog() == DialogResult.OK ? ofd : null;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Resources.Mainform_ClosingTip, Resources.Prog_Name,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) 
            {
                e.Cancel = true;
            }
        }

    }
}

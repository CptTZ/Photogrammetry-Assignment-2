using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

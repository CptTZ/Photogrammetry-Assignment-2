namespace XDDX.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenCamP = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonImgPane = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataPoint = new System.Windows.Forms.DataGridView();
            this.lX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftRowNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftColNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightRowNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightColNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.buttonOpenCamP);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机参数";
            // 
            // buttonOpenCamP
            // 
            this.buttonOpenCamP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenCamP.Location = new System.Drawing.Point(37, 352);
            this.buttonOpenCamP.Name = "buttonOpenCamP";
            this.buttonOpenCamP.Size = new System.Drawing.Size(234, 36);
            this.buttonOpenCamP.TabIndex = 16;
            this.buttonOpenCamP.Text = "打开相机参数文件";
            this.buttonOpenCamP.UseVisualStyleBackColor = true;
            this.buttonOpenCamP.Click += new System.EventHandler(this.buttonOpenCamP_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(134, 288);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(153, 35);
            this.textBox7.TabIndex = 9;
            this.textBox7.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "相机名：";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(134, 248);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(153, 35);
            this.textBox6.TabIndex = 10;
            this.textBox6.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "宽度：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(134, 204);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(153, 35);
            this.textBox5.TabIndex = 11;
            this.textBox5.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "高度：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(134, 159);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(153, 35);
            this.textBox4.TabIndex = 12;
            this.textBox4.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "焦距：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(134, 116);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(153, 35);
            this.textBox3.TabIndex = 13;
            this.textBox3.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "像元尺寸：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 76);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(153, 35);
            this.textBox2.TabIndex = 14;
            this.textBox2.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "像主点X：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(153, 35);
            this.textBox1.TabIndex = 15;
            this.textBox1.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "像主点Y：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.buttonImgPane);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dataPoint);
            this.groupBox2.Location = new System.Drawing.Point(339, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 394);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算窗口";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(356, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 35);
            this.button3.TabIndex = 1;
            this.button3.Text = "相对定向";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonImgPane
            // 
            this.buttonImgPane.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImgPane.Location = new System.Drawing.Point(192, 352);
            this.buttonImgPane.Name = "buttonImgPane";
            this.buttonImgPane.Size = new System.Drawing.Size(153, 35);
            this.buttonImgPane.TabIndex = 1;
            this.buttonImgPane.Text = "像平面坐标";
            this.buttonImgPane.UseVisualStyleBackColor = true;
            this.buttonImgPane.Click += new System.EventHandler(this.buttonImgPane_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(20, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "打开数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataPoint
            // 
            this.dataPoint.AllowUserToAddRows = false;
            this.dataPoint.AllowUserToDeleteRows = false;
            this.dataPoint.AllowUserToOrderColumns = true;
            this.dataPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPoint.AutoGenerateColumns = false;
            this.dataPoint.ColumnHeadersHeight = 32;
            this.dataPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointNumberDataGridViewTextBoxColumn,
            this.leftRowNumberDataGridViewTextBoxColumn,
            this.leftColNumberDataGridViewTextBoxColumn,
            this.rightRowNumberDataGridViewTextBoxColumn,
            this.rightColNumberDataGridViewTextBoxColumn,
            this.lX,
            this.lY,
            this.rX,
            this.rY});
            this.dataPoint.DataSource = this.dataListBindingSource1;
            this.dataPoint.Location = new System.Drawing.Point(7, 37);
            this.dataPoint.Name = "dataPoint";
            this.dataPoint.ReadOnly = true;
            this.dataPoint.RowTemplate.Height = 37;
            this.dataPoint.Size = new System.Drawing.Size(509, 296);
            this.dataPoint.TabIndex = 0;
            // 
            // lX
            // 
            this.lX.DataPropertyName = "lX";
            this.lX.HeaderText = "左像平面X";
            this.lX.Name = "lX";
            this.lX.ReadOnly = true;
            // 
            // lY
            // 
            this.lY.DataPropertyName = "lY";
            this.lY.HeaderText = "左像平面Y";
            this.lY.Name = "lY";
            this.lY.ReadOnly = true;
            // 
            // rX
            // 
            this.rX.DataPropertyName = "rX";
            this.rX.HeaderText = "右像平面X";
            this.rX.Name = "rX";
            this.rX.ReadOnly = true;
            // 
            // rY
            // 
            this.rY.DataPropertyName = "rY";
            this.rY.HeaderText = "右像平面Y";
            this.rY.Name = "rY";
            this.rY.ReadOnly = true;
            // 
            // pointNumberDataGridViewTextBoxColumn
            // 
            this.pointNumberDataGridViewTextBoxColumn.DataPropertyName = "PointNumber";
            this.pointNumberDataGridViewTextBoxColumn.HeaderText = "点号";
            this.pointNumberDataGridViewTextBoxColumn.Name = "pointNumberDataGridViewTextBoxColumn";
            this.pointNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // leftRowNumberDataGridViewTextBoxColumn
            // 
            this.leftRowNumberDataGridViewTextBoxColumn.DataPropertyName = "LeftRowNumber";
            this.leftRowNumberDataGridViewTextBoxColumn.HeaderText = "左行号";
            this.leftRowNumberDataGridViewTextBoxColumn.Name = "leftRowNumberDataGridViewTextBoxColumn";
            this.leftRowNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // leftColNumberDataGridViewTextBoxColumn
            // 
            this.leftColNumberDataGridViewTextBoxColumn.DataPropertyName = "LeftColNumber";
            this.leftColNumberDataGridViewTextBoxColumn.HeaderText = "左列号";
            this.leftColNumberDataGridViewTextBoxColumn.Name = "leftColNumberDataGridViewTextBoxColumn";
            this.leftColNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rightRowNumberDataGridViewTextBoxColumn
            // 
            this.rightRowNumberDataGridViewTextBoxColumn.DataPropertyName = "RightRowNumber";
            this.rightRowNumberDataGridViewTextBoxColumn.HeaderText = "右行号";
            this.rightRowNumberDataGridViewTextBoxColumn.Name = "rightRowNumberDataGridViewTextBoxColumn";
            this.rightRowNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rightColNumberDataGridViewTextBoxColumn
            // 
            this.rightColNumberDataGridViewTextBoxColumn.DataPropertyName = "RightColNumber";
            this.rightColNumberDataGridViewTextBoxColumn.HeaderText = "右列号";
            this.rightColNumberDataGridViewTextBoxColumn.Name = "rightColNumberDataGridViewTextBoxColumn";
            this.rightColNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataListBindingSource1
            // 
            this.dataListBindingSource1.DataSource = typeof(XDDX.DataStruct.DataList);
            // 
            // dataListBindingSource
            // 
            this.dataListBindingSource.DataSource = typeof(XDDX.DataStruct.DataList);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(899, 489);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOpenCamP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataPoint;
        private System.Windows.Forms.BindingSource dataListBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonImgPane;
        private System.Windows.Forms.BindingSource dataListBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftRowNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftColNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightRowNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightColNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lX;
        private System.Windows.Forms.DataGridViewTextBoxColumn lY;
        private System.Windows.Forms.DataGridViewTextBoxColumn rX;
        private System.Windows.Forms.DataGridViewTextBoxColumn rY;
    }
}
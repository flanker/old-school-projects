namespace WBMDemoWinForm
{
    partial class UCBasic
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFlight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxACReg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCrew1 = new System.Windows.Forms.ComboBox();
            this.comboBoxCrew2 = new System.Windows.Forms.ComboBox();
            this.comboBoxCrew3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxMinute = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TYPE";
            this.toolTip1.SetToolTip(this.label1, "机型");
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Airbus A320"});
            this.comboBoxType.Location = new System.Drawing.Point(105, 28);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(140, 25);
            this.comboBoxType.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBoxType, "机型");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "DATE";
            this.toolTip1.SetToolTip(this.label2, "日期");
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBoxDay.Location = new System.Drawing.Point(105, 65);
            this.comboBoxDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(63, 25);
            this.comboBoxDay.TabIndex = 3;
            this.toolTip1.SetToolTip(this.comboBoxDay, "日");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "TIME";
            this.toolTip1.SetToolTip(this.label3, "时间");
            // 
            // comboBoxHour
            // 
            this.comboBoxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHour.FormattingEnabled = true;
            this.comboBoxHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.comboBoxHour.Location = new System.Drawing.Point(105, 102);
            this.comboBoxHour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxHour.Name = "comboBoxHour";
            this.comboBoxHour.Size = new System.Drawing.Size(63, 25);
            this.comboBoxHour.TabIndex = 5;
            this.toolTip1.SetToolTip(this.comboBoxHour, "时");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "FROM";
            this.toolTip1.SetToolTip(this.label4, "出发站");
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Items.AddRange(new object[] {
            "XIY",
            "PEK",
            "SHA",
            "PVG",
            "CAN",
            "SZX",
            "CTU",
            "NKG",
            "HGH",
            "XMN",
            "TAO"});
            this.comboBoxFrom.Location = new System.Drawing.Point(105, 139);
            this.comboBoxFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(63, 25);
            this.comboBoxFrom.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboBoxFrom, "出发站");
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Items.AddRange(new object[] {
            "XIY",
            "PEK",
            "SHA",
            "PVG",
            "CAN",
            "SZX",
            "CTU",
            "NKG",
            "HGH",
            "XMN",
            "TAO"});
            this.comboBoxTo.Location = new System.Drawing.Point(105, 176);
            this.comboBoxTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(63, 25);
            this.comboBoxTo.TabIndex = 8;
            this.toolTip1.SetToolTip(this.comboBoxTo, "目的地");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "TO";
            this.toolTip1.SetToolTip(this.label5, "目的地");
            // 
            // textBoxFlight
            // 
            this.textBoxFlight.Location = new System.Drawing.Point(105, 212);
            this.textBoxFlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFlight.Name = "textBoxFlight";
            this.textBoxFlight.Size = new System.Drawing.Size(116, 23);
            this.textBoxFlight.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textBoxFlight, "航班号");
            this.textBoxFlight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "FLIGHT";
            this.toolTip1.SetToolTip(this.label6, "航班号");
            // 
            // textBoxACReg
            // 
            this.textBoxACReg.Location = new System.Drawing.Point(105, 251);
            this.textBoxACReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxACReg.Name = "textBoxACReg";
            this.textBoxACReg.Size = new System.Drawing.Size(116, 23);
            this.textBoxACReg.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textBoxACReg, "飞机注册号");
            this.textBoxACReg.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "A/C REG";
            this.toolTip1.SetToolTip(this.label7, "飞机注册号");
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Location = new System.Drawing.Point(105, 289);
            this.textBoxVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(116, 23);
            this.textBoxVersion.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textBoxVersion, "客舱布局");
            this.textBoxVersion.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "VERSION";
            this.toolTip1.SetToolTip(this.label8, "客舱布局");
            // 
            // comboBoxCrew1
            // 
            this.comboBoxCrew1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrew1.FormattingEnabled = true;
            this.comboBoxCrew1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxCrew1.Location = new System.Drawing.Point(105, 327);
            this.comboBoxCrew1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCrew1.Name = "comboBoxCrew1";
            this.comboBoxCrew1.Size = new System.Drawing.Size(63, 25);
            this.comboBoxCrew1.TabIndex = 16;
            this.toolTip1.SetToolTip(this.comboBoxCrew1, "机组人员");
            // 
            // comboBoxCrew2
            // 
            this.comboBoxCrew2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrew2.FormattingEnabled = true;
            this.comboBoxCrew2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxCrew2.Location = new System.Drawing.Point(176, 327);
            this.comboBoxCrew2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCrew2.Name = "comboBoxCrew2";
            this.comboBoxCrew2.Size = new System.Drawing.Size(63, 25);
            this.comboBoxCrew2.TabIndex = 17;
            this.toolTip1.SetToolTip(this.comboBoxCrew2, "机组人员");
            // 
            // comboBoxCrew3
            // 
            this.comboBoxCrew3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrew3.FormattingEnabled = true;
            this.comboBoxCrew3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxCrew3.Location = new System.Drawing.Point(247, 327);
            this.comboBoxCrew3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCrew3.Name = "comboBoxCrew3";
            this.comboBoxCrew3.Size = new System.Drawing.Size(63, 25);
            this.comboBoxCrew3.TabIndex = 18;
            this.toolTip1.SetToolTip(this.comboBoxCrew3, "机组人员");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "CREW";
            this.toolTip1.SetToolTip(this.label9, "机组人员");
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "JAN",
            "FEB",
            "MAR",
            "APR",
            "MAY",
            "JUN",
            "JUL",
            "AUG",
            "SEP",
            "OCT",
            "NOV",
            "DEC"});
            this.comboBoxMonth.Location = new System.Drawing.Point(176, 65);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(63, 25);
            this.comboBoxMonth.TabIndex = 20;
            this.toolTip1.SetToolTip(this.comboBoxMonth, "月");
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012"});
            this.comboBoxYear.Location = new System.Drawing.Point(247, 65);
            this.comboBoxYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(63, 25);
            this.comboBoxYear.TabIndex = 21;
            this.toolTip1.SetToolTip(this.comboBoxYear, "年");
            // 
            // comboBoxMinute
            // 
            this.comboBoxMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinute.FormattingEnabled = true;
            this.comboBoxMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.comboBoxMinute.Location = new System.Drawing.Point(176, 102);
            this.comboBoxMinute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxMinute.Name = "comboBoxMinute";
            this.comboBoxMinute.Size = new System.Drawing.Size(63, 25);
            this.comboBoxMinute.TabIndex = 22;
            this.toolTip1.SetToolTip(this.comboBoxMinute, "分");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UCBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxMinute);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxCrew3);
            this.Controls.Add(this.comboBoxCrew2);
            this.Controls.Add(this.comboBoxCrew1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxACReg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFlight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxTo);
            this.Controls.Add(this.comboBoxFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCBasic";
            this.Size = new System.Drawing.Size(350, 380);
            this.Load += new System.EventHandler(this.UCBasic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFlight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxACReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCrew1;
        private System.Windows.Forms.ComboBox comboBoxCrew2;
        private System.Windows.Forms.ComboBox comboBoxCrew3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxMinute;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WBMDemoModel;

namespace WBMDemoWinForm
{
    public partial class UCBasic : UserControl
    {
        #region 属性 -- 获取/设置控件值

        private string Type { get { return comboBoxType.Text; } }
        private string Day { get { return comboBoxDay.Text; } }
        private string Month { get { return comboBoxMonth.Text; } }
        private string Year { get { return comboBoxYear.Text; } }
        private string Hour { get { return comboBoxHour.Text; } }
        private string Minute { get { return comboBoxMinute.Text; } }
        private string From { get { return comboBoxFrom.Text; } }
        private string To { get { return comboBoxTo.Text; } }
        private string Flight { get { return textBoxFlight.Text; } }
        private string ACReg { get { return textBoxACReg.Text; } }
        private string Version { get { return textBoxVersion.Text; } }
        internal int Crew1 { get { return int.Parse(comboBoxCrew1.Text); } }
        internal int Crew2 { get { return int.Parse(comboBoxCrew2.Text); } }
        internal int Crew3 { get { return int.Parse(comboBoxCrew3.Text); } }

        #endregion

        #region 构造方法 和 控件加载事件处理

        public UCBasic()
        {
            InitializeComponent();
        }

        private void UCBasic_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            comboBoxType.SelectedIndex = 0;

            DateTime dt = DateTime.Now;

            comboBoxDay.SelectedIndex = dt.Day - 1;
            comboBoxMonth.SelectedIndex = dt.Month - 1;
            comboBoxYear.SelectedIndex = dt.Year - 2005;
            comboBoxHour.SelectedIndex = dt.Hour;
            comboBoxMinute.SelectedIndex = dt.Minute;

            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 1;

            textBoxFlight.Text = "MU2123";
            textBoxACReg.Text = "B60295";
            textBoxVersion.Text = "F8Y150";

            comboBoxCrew1.SelectedIndex = 3;
            comboBoxCrew2.SelectedIndex = 7;
            comboBoxCrew3.SelectedIndex = 0;
        }

        #endregion

        #region 校验

        public bool Check()
        {
            bool flag = true;

            if (string.IsNullOrEmpty(this.textBoxFlight.Text))
            {
                this.errorProvider1.SetError(this.textBoxFlight, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxACReg.Text))
            {
                this.errorProvider1.SetError(this.textBoxACReg, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxVersion.Text))
            {
                this.errorProvider1.SetError(this.textBoxVersion, "Field can not be empty");
                flag = false;
            }

            return flag;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    errorProvider1.SetError(textBox, "Field can not be empty");
                }
                else
                {
                    errorProvider1.SetError(textBox, null);
                }
            }
        }

        #endregion

        public BasicData GetBasicData()
        {
            BasicData basicData = new BasicData();
            basicData.Flight = this.Flight;
            basicData.Day = this.Day;
            basicData.Month = this.Month;
            basicData.Year = this.Year;
            basicData.Hour = this.Hour;
            basicData.Minute = this.Minute;
            basicData.FromAirport = this.From;
            basicData.ToAirport = this.To;
            basicData.ACReg = this.ACReg;
            basicData.Version = this.Version;
            basicData.Crew1 = this.Crew1;
            basicData.Crew2 = this.Crew2;
            basicData.Crew3 = this.Crew3;

            return basicData;
        }
    }
}

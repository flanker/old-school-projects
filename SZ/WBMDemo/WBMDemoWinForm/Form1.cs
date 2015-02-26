using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WBMDemoModel;

namespace WBMDemoWinForm
{
    public partial class FormMain : Form
    {
        #region 属性

        /// <summary>
        /// 当前状态(基本页/高级页)
        /// </summary>
        public PageState CurrentState { get; set; }

        #endregion

        #region 构造方法及加载事件处理

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载时: 设置默认值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            ucBasic1.Visible = true;
            ucAdvanced1.Visible = false;
            CurrentState = PageState.Basic;

            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }


        #endregion

        #region 事件处理

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            if (CurrentState == PageState.Advanced)
            {
                ucBasic1.Visible = true;
                ucAdvanced1.Visible = false;
                CurrentState = PageState.Basic;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            if (CurrentState == PageState.Basic)
            {
                UCBasic_Add();
            }
            else if (CurrentState == PageState.Advanced)
            {
                this.UCAdvanced_Add();
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxReset_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            if (CurrentState == PageState.Basic)
            {
                ucBasic1.Visible = false;
                ucAdvanced1.Visible = true;
                ucAdvanced1.Crew1 = ucBasic1.Crew1;
                ucAdvanced1.Crew2 = ucBasic1.Crew2;
                ucAdvanced1.Crew3 = ucBasic1.Crew3;

                CurrentState = PageState.Advanced;
            }
        }

        /// <summary>
        /// 处理基本页的添加
        /// </summary>
        private void UCBasic_Add()
        {
            if (this.ucBasic1.Check())
            {
                BasicData basicData = ucBasic1.GetBasicData();
                richTextBox1.AppendText(basicData.Output());
            }
        }

        /// <summary>
        /// 处理高级页的添加
        /// </summary>
        private void UCAdvanced_Add()
        {
            if (this.ucAdvanced1.Check())
            {
                AirbusA320 a320 = ucAdvanced1.GetAdvancedData();
                richTextBox1.AppendText(a320.OutputAll());

            }
        }

        private void pictureBoxOK_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (this.ucBasic1.Check() && this.ucAdvanced1.Check())
            {
                BasicData basicData = ucBasic1.GetBasicData();
                richTextBox1.AppendText(basicData.Output());

                AirbusA320 a320 = ucAdvanced1.GetAdvancedData();
                richTextBox1.AppendText(a320.OutputAll());
            }
        }

        #endregion

        #region 菜单栏事件处理

        private void toolStripMenuItemPrintSetting_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 打印

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings = this.printDialog1.PrinterSettings;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Courier New", 12), Brushes.Black, 50, 50);

        }

        #endregion



    }
}

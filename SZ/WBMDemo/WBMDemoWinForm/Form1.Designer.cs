namespace WBMDemoWinForm
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
            this.pictureBoxReset = new System.Windows.Forms.PictureBox();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPrint = new System.Windows.Forms.PictureBox();
            this.pictureBoxOK = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPrintSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ucAdvanced1 = new WBMDemoWinForm.UCAdvanced();
            this.ucBasic1 = new WBMDemoWinForm.UCBasic();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBack.Image")));
            this.pictureBoxBack.InitialImage = null;
            this.pictureBoxBack.Location = new System.Drawing.Point(71, 574);
            this.pictureBoxBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBack.TabIndex = 1;
            this.pictureBoxBack.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBack, "Back");
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            // 
            // pictureBoxAdd
            // 
            this.pictureBoxAdd.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAdd.Image")));
            this.pictureBoxAdd.InitialImage = null;
            this.pictureBoxAdd.Location = new System.Drawing.Point(147, 574);
            this.pictureBoxAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxAdd.Name = "pictureBoxAdd";
            this.pictureBoxAdd.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAdd.TabIndex = 2;
            this.pictureBoxAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxAdd, "Add");
            this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
            // 
            // pictureBoxReset
            // 
            this.pictureBoxReset.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxReset.Image")));
            this.pictureBoxReset.InitialImage = null;
            this.pictureBoxReset.Location = new System.Drawing.Point(223, 574);
            this.pictureBoxReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxReset.Name = "pictureBoxReset";
            this.pictureBoxReset.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxReset.TabIndex = 3;
            this.pictureBoxReset.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxReset, "Reset");
            this.pictureBoxReset.Click += new System.EventHandler(this.pictureBoxReset_Click);
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNext.Image")));
            this.pictureBoxNext.InitialImage = null;
            this.pictureBoxNext.Location = new System.Drawing.Point(299, 574);
            this.pictureBoxNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNext.TabIndex = 4;
            this.pictureBoxNext.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxNext, "Next");
            this.pictureBoxNext.Click += new System.EventHandler(this.pictureBoxNext_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(450, 100);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(500, 450);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // pictureBoxPrint
            // 
            this.pictureBoxPrint.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPrint.Image")));
            this.pictureBoxPrint.InitialImage = null;
            this.pictureBoxPrint.Location = new System.Drawing.Point(830, 574);
            this.pictureBoxPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxPrint.Name = "pictureBoxPrint";
            this.pictureBoxPrint.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPrint.TabIndex = 6;
            this.pictureBoxPrint.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxPrint, "Print");
            this.pictureBoxPrint.Click += new System.EventHandler(this.pictureBoxPrint_Click);
            // 
            // pictureBoxOK
            // 
            this.pictureBoxOK.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOK.Image")));
            this.pictureBoxOK.InitialImage = null;
            this.pictureBoxOK.Location = new System.Drawing.Point(754, 574);
            this.pictureBoxOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxOK.Name = "pictureBoxOK";
            this.pictureBoxOK.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOK.TabIndex = 7;
            this.pictureBoxOK.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxOK, "OK");
            this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 27);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPrintSetting,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(53, 21);
            this.toolStripMenuItemFile.Text = "File(&F)";
            // 
            // toolStripMenuItemPrintSetting
            // 
            this.toolStripMenuItemPrintSetting.Name = "toolStripMenuItemPrintSetting";
            this.toolStripMenuItemPrintSetting.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemPrintSetting.Text = "PrinterSetting(&S)...";
            this.toolStripMenuItemPrintSetting.Click += new System.EventHandler(this.toolStripMenuItemPrintSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemExit.Text = "Exit(&X)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(64, 21);
            this.toolStripMenuItemHelp.Text = "Help(&H)";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItemAbout.Text = "About(&A)";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 762);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "陕西华奕科技工程有限公司";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 706);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "陕西华奕科技工程有限公司";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(927, 706);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "demo v0.1";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ucAdvanced1
            // 
            this.ucAdvanced1.Crew1 = 0;
            this.ucAdvanced1.Crew2 = 0;
            this.ucAdvanced1.Crew3 = 0;
            this.ucAdvanced1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucAdvanced1.Location = new System.Drawing.Point(30, 100);
            this.ucAdvanced1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ucAdvanced1.Name = "ucAdvanced1";
            this.ucAdvanced1.Size = new System.Drawing.Size(350, 380);
            this.ucAdvanced1.TabIndex = 0;
            // 
            // ucBasic1
            // 
            this.ucBasic1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBasic1.Location = new System.Drawing.Point(30, 100);
            this.ucBasic1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucBasic1.Name = "ucBasic1";
            this.ucBasic1.Size = new System.Drawing.Size(350, 380);
            this.ucBasic1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucAdvanced1);
            this.Controls.Add(this.ucBasic1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxOK);
            this.Controls.Add(this.pictureBoxPrint);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBoxNext);
            this.Controls.Add(this.pictureBoxReset);
            this.Controls.Add(this.pictureBoxAdd);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "东航载重平衡软件Demo";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.PictureBox pictureBoxAdd;
        private System.Windows.Forms.PictureBox pictureBoxReset;
        private System.Windows.Forms.PictureBox pictureBoxNext;
        private UCBasic ucBasic1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBoxPrint;
        private System.Windows.Forms.PictureBox pictureBoxOK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Label label1;
        private UCAdvanced ucAdvanced1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPrintSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}


namespace WBMDemoWinForm
{
    partial class UCAdvanced
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBasicWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDOI = new System.Windows.Forms.TextBox();
            this.textBoxCorrection = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTakeoffFuel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTripFuel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCargo1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCargo3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCargo4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCargo5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPsgOA = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPsgOB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPsgOC = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "BASIC OPTG WT";
            this.toolTip1.SetToolTip(this.label2, "基本使用重量");
            // 
            // textBoxBasicWeight
            // 
            this.textBoxBasicWeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBasicWeight.Location = new System.Drawing.Point(133, 39);
            this.textBoxBasicWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBasicWeight.Name = "textBoxBasicWeight";
            this.textBoxBasicWeight.Size = new System.Drawing.Size(75, 23);
            this.textBoxBasicWeight.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxBasicWeight, "基本使用重量");
            this.textBoxBasicWeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(214, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "DOI";
            this.toolTip1.SetToolTip(this.label3, "干使用系数");
            // 
            // textBoxDOI
            // 
            this.textBoxDOI.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDOI.Location = new System.Drawing.Point(251, 39);
            this.textBoxDOI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDOI.Name = "textBoxDOI";
            this.textBoxDOI.Size = new System.Drawing.Size(75, 23);
            this.textBoxDOI.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxDOI, "干使用系数");
            this.textBoxDOI.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBoxCorrection
            // 
            this.textBoxCorrection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCorrection.Location = new System.Drawing.Point(133, 70);
            this.textBoxCorrection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCorrection.Name = "textBoxCorrection";
            this.textBoxCorrection.Size = new System.Drawing.Size(75, 23);
            this.textBoxCorrection.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBoxCorrection, "修正值");
            this.textBoxCorrection.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(39, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "CORRECTION";
            this.toolTip1.SetToolTip(this.label4, "修正值");
            // 
            // textBoxTakeoffFuel
            // 
            this.textBoxTakeoffFuel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTakeoffFuel.Location = new System.Drawing.Point(133, 132);
            this.textBoxTakeoffFuel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTakeoffFuel.Name = "textBoxTakeoffFuel";
            this.textBoxTakeoffFuel.Size = new System.Drawing.Size(75, 23);
            this.textBoxTakeoffFuel.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBoxTakeoffFuel, "起飞油量");
            this.textBoxTakeoffFuel.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(35, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "TAKEOFF FUEL";
            this.toolTip1.SetToolTip(this.label5, "起飞油量");
            // 
            // textBoxTripFuel
            // 
            this.textBoxTripFuel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTripFuel.Location = new System.Drawing.Point(133, 163);
            this.textBoxTripFuel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTripFuel.Name = "textBoxTripFuel";
            this.textBoxTripFuel.Size = new System.Drawing.Size(75, 23);
            this.textBoxTripFuel.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBoxTripFuel, "航程耗油");
            this.textBoxTripFuel.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(61, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "TRIP FUEL";
            this.toolTip1.SetToolTip(this.label1, "航程耗油");
            // 
            // textBoxCargo1
            // 
            this.textBoxCargo1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCargo1.Location = new System.Drawing.Point(112, 225);
            this.textBoxCargo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCargo1.Name = "textBoxCargo1";
            this.textBoxCargo1.Size = new System.Drawing.Size(75, 23);
            this.textBoxCargo1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textBoxCargo1, "货舱1");
            this.textBoxCargo1.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(48, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "CARGO1";
            this.toolTip1.SetToolTip(this.label6, "货舱1");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(48, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "CARGO3";
            this.toolTip1.SetToolTip(this.label7, "货舱3");
            // 
            // textBoxCargo3
            // 
            this.textBoxCargo3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCargo3.Location = new System.Drawing.Point(112, 256);
            this.textBoxCargo3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCargo3.Name = "textBoxCargo3";
            this.textBoxCargo3.Size = new System.Drawing.Size(75, 23);
            this.textBoxCargo3.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textBoxCargo3, "货舱3");
            this.textBoxCargo3.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(49, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "CARGO4";
            this.toolTip1.SetToolTip(this.label8, "货舱4");
            // 
            // textBoxCargo4
            // 
            this.textBoxCargo4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCargo4.Location = new System.Drawing.Point(113, 287);
            this.textBoxCargo4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCargo4.Name = "textBoxCargo4";
            this.textBoxCargo4.Size = new System.Drawing.Size(75, 23);
            this.textBoxCargo4.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textBoxCargo4, "货舱4");
            this.textBoxCargo4.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(48, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "CARGO5";
            this.toolTip1.SetToolTip(this.label9, "货舱5");
            // 
            // textBoxCargo5
            // 
            this.textBoxCargo5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCargo5.Location = new System.Drawing.Point(113, 318);
            this.textBoxCargo5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCargo5.Name = "textBoxCargo5";
            this.textBoxCargo5.Size = new System.Drawing.Size(75, 23);
            this.textBoxCargo5.TabIndex = 17;
            this.toolTip1.SetToolTip(this.textBoxCargo5, "货舱5");
            this.textBoxCargo5.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(192, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "PSG OA";
            this.toolTip1.SetToolTip(this.label10, "客舱A");
            // 
            // textBoxPsgOA
            // 
            this.textBoxPsgOA.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPsgOA.Location = new System.Drawing.Point(251, 225);
            this.textBoxPsgOA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPsgOA.Name = "textBoxPsgOA";
            this.textBoxPsgOA.Size = new System.Drawing.Size(50, 23);
            this.textBoxPsgOA.TabIndex = 19;
            this.toolTip1.SetToolTip(this.textBoxPsgOA, "客舱A");
            this.textBoxPsgOA.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(193, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "PSG OB";
            this.toolTip1.SetToolTip(this.label11, "客舱B");
            // 
            // textBoxPsgOB
            // 
            this.textBoxPsgOB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPsgOB.Location = new System.Drawing.Point(251, 256);
            this.textBoxPsgOB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPsgOB.Name = "textBoxPsgOB";
            this.textBoxPsgOB.Size = new System.Drawing.Size(50, 23);
            this.textBoxPsgOB.TabIndex = 21;
            this.toolTip1.SetToolTip(this.textBoxPsgOB, "客舱B");
            this.textBoxPsgOB.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(193, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "PSG OC";
            this.toolTip1.SetToolTip(this.label12, "客舱C");
            // 
            // textBoxPsgOC
            // 
            this.textBoxPsgOC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPsgOC.Location = new System.Drawing.Point(251, 287);
            this.textBoxPsgOC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPsgOC.Name = "textBoxPsgOC";
            this.textBoxPsgOC.Size = new System.Drawing.Size(50, 23);
            this.textBoxPsgOC.TabIndex = 23;
            this.toolTip1.SetToolTip(this.textBoxPsgOC, "客舱C");
            this.textBoxPsgOC.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UCAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxPsgOC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPsgOB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPsgOA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCargo5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCargo4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCargo3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCargo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTripFuel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTakeoffFuel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCorrection);
            this.Controls.Add(this.textBoxDOI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBasicWeight);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCAdvanced";
            this.Size = new System.Drawing.Size(350, 380);
            this.Load += new System.EventHandler(this.UCAdvanced_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBasicWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDOI;
        private System.Windows.Forms.TextBox textBoxCorrection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTakeoffFuel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTripFuel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCargo1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCargo3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCargo4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCargo5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPsgOA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPsgOB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPsgOC;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

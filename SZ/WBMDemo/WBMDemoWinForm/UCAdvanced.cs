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
    public partial class UCAdvanced : UserControl
    {
        #region 属性 -- 获取/设置控件值

        private double BasicWeight { get { return double.Parse(textBoxBasicWeight.Text); } }
        private double DOI { get { return double.Parse(textBoxDOI.Text); } }
        private double Correction { get { return double.Parse(textBoxCorrection.Text); } }
        private double TakeoffFuel { get { return double.Parse(textBoxTakeoffFuel.Text); } }
        private double TripFuel { get { return double.Parse(textBoxTripFuel.Text); } }
        private double LandingFuel { get { return TakeoffFuel - TripFuel; } }
        private double Cargo1 { get { return double.Parse(textBoxCargo1.Text); } }
        private double Cargo3 { get { return double.Parse(textBoxCargo3.Text); } }
        private double Cargo4 { get { return double.Parse(textBoxCargo4.Text); } }
        private double Cargo5 { get { return double.Parse(textBoxCargo5.Text); } }
        private int PsgOA { get { return int.Parse(textBoxPsgOA.Text); } }
        private int PsgOB { get { return int.Parse(textBoxPsgOB.Text); } }
        private int PsgOC { get { return int.Parse(textBoxPsgOC.Text); } }

        public int Crew1 { get; set; }
        public int Crew2 { get; set; }
        public int Crew3 { get; set; }

        #endregion

        #region 构造方法 和 控件加载事件处理

        public UCAdvanced()
        {
            InitializeComponent();
        }

        private void UCAdvanced_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        #endregion

        #region 校验

        public bool Check()
        {
            bool flag = true;

            if (string.IsNullOrEmpty(this.textBoxBasicWeight.Text))
            {
                this.errorProvider1.SetError(this.textBoxBasicWeight, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxDOI.Text))
            {
                this.errorProvider1.SetError(this.textBoxDOI, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxCorrection.Text))
            {
                this.errorProvider1.SetError(this.textBoxCorrection, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxTakeoffFuel.Text))
            {
                this.errorProvider1.SetError(this.textBoxTakeoffFuel, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxTripFuel.Text))
            {
                this.errorProvider1.SetError(this.textBoxTripFuel, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxCargo1.Text))
            {
                this.errorProvider1.SetError(this.textBoxCargo1, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxCargo3.Text))
            {
                this.errorProvider1.SetError(this.textBoxCargo3, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxCargo4.Text))
            {
                this.errorProvider1.SetError(this.textBoxCargo4, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxCargo5.Text))
            {
                this.errorProvider1.SetError(this.textBoxCargo5, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxPsgOA.Text))
            {
                this.errorProvider1.SetError(this.textBoxPsgOA, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxPsgOB.Text))
            {
                this.errorProvider1.SetError(this.textBoxPsgOB, "Field can not be empty");
                flag = false;
            }
            if (string.IsNullOrEmpty(this.textBoxPsgOB.Text))
            {
                this.errorProvider1.SetError(this.textBoxPsgOB, "Field can not be empty");
                flag = false;
            }

            return flag;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                double result;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    errorProvider1.SetError(textBox, "Field can not be empty");
                }
                else if (!double.TryParse(textBox.Text, out result))
                {
                    errorProvider1.SetError(textBox, "Field must be number");
                }
                else
                {
                    errorProvider1.SetError(textBox, null);
                }
            }
        }

        #endregion

        public SelfWeight GetSelfWeight()
        {
            SelfWeight selfWeight = new SelfWeight();
            selfWeight.BasicWeight = this.BasicWeight;
            selfWeight.DryOperationIndex = this.DOI;
            selfWeight.Correction = this.Correction;
            selfWeight.Crew1 = this.Crew1;
            selfWeight.Crew2 = this.Crew2;
            selfWeight.Crew3 = this.Crew3;
            selfWeight.Calc();
            return selfWeight;
        }

        public Fuel GetTakeoffFuel()
        {
            Fuel fuel = new Fuel();
            fuel.Name = "TAKEOFF FUEL";
            fuel.Weight = this.TakeoffFuel;
            fuel.Harm = Fuel.TakeoffFuelHarm;
            fuel.Calc();
            return fuel;
        }

        public Fuel GetLandingFuel()
        {
            Fuel fuel = new Fuel();
            fuel.Name = "LANDING FUEL";
            fuel.Weight = this.LandingFuel;
            fuel.Harm = Fuel.LandingFuelHarm;
            fuel.Calc();
            return fuel;
        }

        public Cargo GetCargo1()
        {
            Cargo cargo = new Cargo();
            cargo.Name = "CARGO1";
            cargo.Weight = this.Cargo1;
            cargo.Harm = Cargo.Harm_Cargo1;
            cargo.Calc();
            return cargo;
        }

        public Cargo GetCargo3()
        {
            Cargo cargo = new Cargo();
            cargo.Name = "CARGO3";
            cargo.Weight = this.Cargo3;
            cargo.Harm = Cargo.Harm_Cargo3;
            cargo.Calc();
            return cargo;
        }

        public Cargo GetCargo4()
        {
            Cargo cargo = new Cargo();
            cargo.Name = "CARGO4";
            cargo.Weight = this.Cargo4;
            cargo.Harm = Cargo.Harm_Cargo4;
            cargo.Calc();
            return cargo;
        }

        public Cargo GetCargo5()
        {
            Cargo cargo = new Cargo();
            cargo.Name = "CARGO5";
            cargo.Weight = this.Cargo5;
            cargo.Harm = Cargo.Harm_Cargo5;
            cargo.Calc();
            return cargo;
        }

        public PSGComp GetPsgOA()
        {
            PSGComp psgComp = new PSGComp();
            psgComp.Name = "PSG OA";
            psgComp.Number = this.PsgOA;
            psgComp.Harm = PSGComp.Harm_PsgOA;
            psgComp.Calc();
            return psgComp;
        }

        public PSGComp GetPsgOB()
        {
            PSGComp psgComp = new PSGComp();
            psgComp.Name = "PSG OB";
            psgComp.Number = this.PsgOB;
            psgComp.Harm = PSGComp.Harm_PsgOB;
            psgComp.Calc();
            return psgComp;
        }

        public PSGComp GetPsgOC()
        {
            PSGComp psgComp = new PSGComp();
            psgComp.Name = "PSG OC";
            psgComp.Number = this.PsgOC;
            psgComp.Harm = PSGComp.Harm_PsgOC;
            psgComp.Calc();
            return psgComp;
        }

        public AirbusA320 GetAdvancedData()
        {
            SelfWeight selfWeight = this.GetSelfWeight();

            Fuel takeoffFuel = this.GetTakeoffFuel();

            Fuel landingFuel = this.GetLandingFuel();

            Cargo cargo1 = this.GetCargo1();

            Cargo cargo3 = this.GetCargo3();

            Cargo cargo4 = this.GetCargo4();

            Cargo cargo5 = this.GetCargo5();

            PSGComp psgOA = this.GetPsgOA();

            PSGComp psgOB = this.GetPsgOB();

            PSGComp psgOC = this.GetPsgOC();

            AirbusA320 a320 = new AirbusA320
            {
                SelfWeight = selfWeight,
                TakeoffFuel = takeoffFuel,
                LandingFuel = landingFuel,
                Cargo1 = cargo1,
                Cargo3 = cargo3,
                Cargo4 = cargo4,
                Cargo5 = cargo5,
                PsgOA = psgOA,
                PsgOB = psgOB,
                PsgOC = psgOC
            };
            a320.Calc();

            return a320;
        }

    }
}

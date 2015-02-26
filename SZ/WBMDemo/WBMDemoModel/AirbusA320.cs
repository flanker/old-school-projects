using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    public class AirbusA320
    {
        #region 存储的属性

        public SelfWeight SelfWeight { get; set; }
        public Fuel TakeoffFuel { get; set; }
        public Fuel LandingFuel { get; set; }
        public Cargo Cargo1 { get; set; }
        public Cargo Cargo3 { get; set; }
        public Cargo Cargo4 { get; set; }
        public Cargo Cargo5 { get; set; }
        public PSGComp PsgOA { get; set; }
        public PSGComp PsgOB { get; set; }
        public PSGComp PsgOC { get; set; }

        private double ZeroWeight { get; set; }
        private double ZeroQuanzhong { get; set; }
        private double ZeroRC { get; set; }

        private double TakeoffWeight { get; set; }
        private double TakeoffQuanzhong { get; set; }
        private double TakeoffRC { get; set; }

        private double LandingWeight { get; set; }
        private double LandingQuanzhong { get; set; }
        private double LandingRC { get; set; }

        #endregion

        #region 计算的属性

        private double LoadInCompartments
        {
            get { return Cargo1.Weight + Cargo3.Weight + Cargo4.Weight + Cargo5.Weight; }
        }

        private string LoadInCompartmentsDis
        {
            get
            {
                return "1/" + Cargo1.Weight.ToString()
                    + " 3/" + Cargo3.Weight.ToString()
                    + " 4/" + Cargo4.Weight.ToString()
                    + " 5/" + Cargo5.Weight.ToString();
            }
        }

        private double Passenger
        {
            get { return PsgOA.Weight + PsgOB.Weight + PsgOC.Weight; }
        }

        private string PassengerDis
        {
            get
            {
                return PsgOA.Number.ToString() + "/"
                    + PsgOB.Number.ToString() + "/"
                    + PsgOC.Number.ToString() + " "
                    + "TTL" + (PsgOA.Number + PsgOB.Number + PsgOC.Number).ToString() + " "
                    + "CAB 0";
            }
        }

        private double TripFuelWeight { get { return TakeoffFuel.Weight - LandingFuel.Weight; } }

        #endregion

        public void Calc()
        {
            #region 空油状态

            ZeroWeight = SelfWeight.DryOperationWeight
                + Cargo1.Weight
                + Cargo3.Weight
                + Cargo4.Weight
                + Cargo5.Weight
                + PsgOA.Weight
                + PsgOB.Weight
                + PsgOC.Weight;

            ZeroQuanzhong = SelfWeight.Quanzhong
                + Cargo1.Quanzhong
                + Cargo3.Quanzhong
                + Cargo4.Quanzhong
                + Cargo5.Quanzhong
                + PsgOA.Quanzhong
                + PsgOB.Quanzhong
                + PsgOC.Quanzhong;

            ZeroRC = ZeroQuanzhong / ZeroWeight;

            #endregion

            #region 起飞状态

            TakeoffWeight = SelfWeight.DryOperationWeight
                + TakeoffFuel.Weight
                + Cargo1.Weight
                + Cargo3.Weight
                + Cargo4.Weight
                + Cargo5.Weight
                + PsgOA.Weight
                + PsgOB.Weight
                + PsgOC.Weight;

            TakeoffQuanzhong = SelfWeight.Quanzhong
                + TakeoffFuel.Quanzhong
                + Cargo1.Quanzhong
                + Cargo3.Quanzhong
                + Cargo4.Quanzhong
                + Cargo5.Quanzhong
                + PsgOA.Quanzhong
                + PsgOB.Quanzhong
                + PsgOC.Quanzhong;

            TakeoffRC = TakeoffQuanzhong / TakeoffWeight;

            #endregion

            #region 降落状态

            LandingWeight = SelfWeight.DryOperationWeight
                + LandingFuel.Weight
                + Cargo1.Weight
                + Cargo3.Weight
                + Cargo4.Weight
                + Cargo5.Weight
                + PsgOA.Weight
                + PsgOB.Weight
                + PsgOC.Weight;

            LandingQuanzhong = SelfWeight.Quanzhong
                + LandingFuel.Quanzhong
                + Cargo1.Quanzhong
                + Cargo3.Quanzhong
                + Cargo4.Quanzhong
                + Cargo5.Quanzhong
                + PsgOA.Quanzhong
                + PsgOB.Quanzhong
                + PsgOC.Quanzhong;

            LandingRC = LandingQuanzhong / LandingWeight;

            #endregion
        }

        public string Output()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("TOTAL WEIGHT\tTOTAL QUANZHONG\t%RC" + Environment.NewLine);
            //sb.Append(TotalWeight.ToString("#0.000") + "\t");
            //sb.Append(TotalQuanzhong.ToString("#0.000") + "\t");
            //sb.Append(TotalRC.ToString("#0.000"));
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-10}", "");
            sb.AppendFormat("{0,-15}", "TOTAL WEIGHT");
            sb.AppendFormat("{0,-18}", "TOTAL QUANZHONG");
            sb.AppendFormat("{0,-15}", "%RC");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-10}", "ZERO");
            sb.AppendFormat("{0,-15}", ZeroWeight.ToString("#0.000"));
            sb.AppendFormat("{0,-18}", ZeroQuanzhong.ToString("#0.000"));
            sb.AppendFormat("{0,-15}", ZeroRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-10}", "TAKEOFF");
            sb.AppendFormat("{0,-15}", TakeoffWeight.ToString("#0.000"));
            sb.AppendFormat("{0,-18}", TakeoffQuanzhong.ToString("#0.000"));
            sb.AppendFormat("{0,-15}", TakeoffRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-10}", "LANDING");
            sb.AppendFormat("{0,-15}", LandingWeight.ToString("#0.000"));
            sb.AppendFormat("{0,-18}", LandingQuanzhong.ToString("#0.000"));
            sb.AppendFormat("{0,-15}", LandingRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        public string OutputAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0,-25}", "");
            sb.AppendFormat("{0,-10}", "WEIGHT");
            sb.AppendFormat("{0,-18}", "DISTRIBUTION");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "LOAD IN COMPARTMENTS");
            sb.AppendFormat("{0,-10}", LoadInCompartments.ToString());
            sb.AppendFormat("{0,-18}", LoadInCompartmentsDis);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "PASSENGER/CABIN BAG");
            sb.AppendFormat("{0,-10}", Passenger.ToString());
            sb.AppendFormat("{0,-18}", PassengerDis);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "MAX TRAFFIC PAY LOAD");
            sb.AppendFormat("{0,-10}", "15833");
            sb.AppendFormat("{0,-18}", "PAX 1/133");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "TOTAL TRAFFIC LOAD");
            sb.AppendFormat("{0,-10}", (LoadInCompartments + Passenger).ToString());
            sb.AppendFormat("{0,-18}", "BLKD 0/2");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "DRY  OPERATING  WEIGHT");
            sb.AppendFormat("{0,-10}", SelfWeight.DryOperationWeight.ToString());
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "ZERO FUEL WEIGHT ACTUAL");
            sb.AppendFormat("{0,-10}", (LoadInCompartments + Passenger + SelfWeight.DryOperationWeight).ToString());
            sb.AppendFormat("{0,-18}", "MAX 61000   ADJ");
            sb.Append(Environment.NewLine);
            sb.AppendLine("------------------------------------------------------");
            sb.AppendFormat("{0,-25}", "TAKE OFF FUEL");
            sb.AppendFormat("{0,-10}", TakeoffFuel.Weight.ToString());
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "TAKE OFF WEIGHT ACTUAL");
            sb.AppendFormat("{0,-10}", (LoadInCompartments + Passenger + SelfWeight.DryOperationWeight + TakeoffFuel.Weight).ToString());
            sb.AppendFormat("{0,-18}", "MAX 77000   ADJ");
            sb.Append(Environment.NewLine);
            sb.AppendLine("------------------------------------------------------");
            sb.AppendFormat("{0,-25}", "TRIP FUEL");
            sb.AppendFormat("{0,-10}", TripFuelWeight.ToString());
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "LANDING WEIGHT ACTUAL");
            sb.AppendFormat("{0,-10}", (LoadInCompartments + Passenger + SelfWeight.DryOperationWeight + LandingFuel.Weight).ToString());
            sb.AppendFormat("{0,-18}", "MAX 64500   ADJ");
            sb.Append(Environment.NewLine);
            sb.AppendLine("------------------------------------------------------");
            sb.AppendLine("BALANCE AND SEATING CONDITION      LAST MINUTE CHANGES");
            sb.AppendLine("DOI    " + SelfWeight.DryOperationIndex.ToString());
            sb.AppendFormat("{0,-25}", "MAC ZERO FUEL WEIGHT");
            sb.AppendFormat("{0,-10}", ZeroRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "MAC TAKE OFF WEIGHT");
            sb.AppendFormat("{0,-10}", TakeoffRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-25}", "MAC LANDING WEIGHT");
            sb.AppendFormat("{0,-10}", LandingRC.ToString("#0.000"));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }


    }
}

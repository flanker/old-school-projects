using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    /// <summary>
    /// 油料
    /// </summary>
    public class Fuel
    {
        public static double TakeoffFuelHarm = 18.503;

        public static double LandingFuelHarm = 18.503;

        /// <summary>
        /// 油料密度
        /// </summary>
        public static readonly double Density = 0.717;

        public string Name { get; set; }
        /// <summary>
        /// 油重
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 体积
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// H-arm
        /// </summary>
        public double Harm { get; set; }
        /// <summary>
        /// %RC
        /// </summary>
        public double RC { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        public double Quanzhong { get; set; }

        /// <summary>
        /// 计算数据
        /// </summary>
        public void Calc()
        {
            Volume = Weight / Density;
            RC = (Harm - 17.8015) / 0.041935;
            Quanzhong = Weight * RC;
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <returns></returns>
        public string Output()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append(Name);
            //sb.Append(Environment.NewLine);
            //sb.Append("\tWEIGHT\t\tH-arm\t%RC  \tQUANZHONG" + Environment.NewLine);
            //sb.Append("\t");
            //sb.Append(TakeoffFuel.ToString("#0.000") + "\t");
            //sb.Append(Harm.ToString("#0.000") + "\t");
            //sb.Append(RC.ToString("#0.000") + "\t");
            //sb.Append(Quanzhong.ToString("#0.000"));
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-14}", Name);
            sb.AppendFormat("{0,-10}", "WEIGHT");
            sb.AppendFormat("{0,-10}", "H-arm");
            sb.AppendFormat("{0,-10}", "%RC");
            sb.AppendFormat("{0,-10}", "QUANZHONG");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-14}", "");
            sb.AppendFormat("{0,-10}", Weight.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Harm.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", RC.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Quanzhong.ToString("#0.000"));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

    }
}

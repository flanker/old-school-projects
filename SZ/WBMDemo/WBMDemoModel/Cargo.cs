using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    /// <summary>
    /// 货舱
    /// </summary>
    public class Cargo
    {
        public static readonly double Harm_Cargo1 = (14.71 - 9.759) / 2 + 9.759;
        public static readonly double Harm_Cargo3 = (27.762 - 21.208) / 4 + 21.208;
        public static readonly double Harm_Cargo4 = 3 * (27.762 - 21.208) / 4 + 21.208;
        public static readonly double Harm_Cargo5 = (31.003 - 27.762) / 2 + 27.762;

        /// <summary>
        /// 货舱名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 货物总重
        /// </summary>
        public double Weight { get; set; }
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

            //sb.Append(Name + "\tWEIGHT\t\tH-arm\t%RC  \tQUANZHONG" + Environment.NewLine);
            //sb.Append("\t");
            //sb.Append(Weight.ToString("#0.000") + "\t");
            //sb.Append(Harm.ToString("#0.000") + "\t");
            //sb.Append(RC.ToString("#0.000") + "\t");
            //sb.Append(Quanzhong.ToString("#0.000"));
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-9}", Name);
            sb.AppendFormat("{0,-10}", "WEIGHT");
            sb.AppendFormat("{0,-10}", "H-arm");
            sb.AppendFormat("{0,-10}", "%RC");
            sb.AppendFormat("{0,-10}", "QUANZHONG");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-9}", "");
            sb.AppendFormat("{0,-10}", Weight.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Harm.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", RC.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Quanzhong.ToString("#0.000"));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

    }
}

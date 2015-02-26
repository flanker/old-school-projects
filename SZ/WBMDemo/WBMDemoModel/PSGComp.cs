using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    /// <summary>
    /// 乘客舱
    /// </summary>
    public class PSGComp
    {
        public static readonly double Harm_PsgOA = 9.318;
        public static readonly double Harm_PsgOB = 15.8;
        public static readonly double Harm_PsgOC = 24.6;

        /// <summary>
        /// 乘客平均体重
        /// </summary>
        private static readonly double BodyWeight = 75;

        /// <summary>
        /// 乘客舱名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 总重
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
        /// 计算
        /// </summary>
        public void Calc()
        {
            Weight = Number * BodyWeight;
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

            //sb.Append(Name + "\tNR\tWEIGHT\t\tH-arm\t%RC\tQUANZHONG" + Environment.NewLine);
            //sb.Append("\t" + Number.ToString() + "\t");
            //sb.Append(Weight.ToString() + "\t");
            //sb.Append(Harm.ToString("#0.000") + "\t");
            //sb.Append(RC.ToString("#0.000") + "\t");
            //sb.Append(Quanzhong.ToString("#0.000"));
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-9}", Name);
            sb.AppendFormat("{0,-5}", "NR");
            sb.AppendFormat("{0,-10}", "WEIGHT");
            sb.AppendFormat("{0,-10}", "H-arm");
            sb.AppendFormat("{0,-10}", "%RC");
            sb.AppendFormat("{0,-10}", "QUANZHONG");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-9}", "");
            sb.AppendFormat("{0,-5}", Number.ToString());
            sb.AppendFormat("{0,-10}", Weight.ToString());
            sb.AppendFormat("{0,-10}", Harm.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", RC.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Quanzhong.ToString("#0.000"));
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }

    }
}

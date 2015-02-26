using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    /// <summary>
    /// 飞机自重
    /// </summary>
    public class SelfWeight
    {
        /// <summary>
        /// 基本空重
        /// </summary>
        public double BasicWeight { get; set; }
        /// <summary>
        /// 修正值
        /// </summary>
        public double Correction { get; set; }
        /// <summary>
        /// 机组人数1
        /// </summary>
        public int Crew1 { get; set; }
        /// <summary>
        /// 机组人数2
        /// </summary>
        public int Crew2 { get; set; }
        /// <summary>
        /// 机组人数3
        /// </summary>
        public int Crew3 { get; set; }
        /// <summary>
        /// DOW
        /// </summary>
        public double DryOperationWeight { get; set; }
        /// <summary>
        /// DOI
        /// </summary>
        public double DryOperationIndex { get; set; }
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
            //int Crew = Crew1 + Crew2 + Crew3;
            //Correction = Correction + (Crew - 10) * 80;

            DryOperationWeight = BasicWeight + Correction;

            Harm = ((DryOperationIndex - 50) * 1000) / DryOperationWeight + 18.8499;
            RC = (Harm - 17.8015) / 0.041935;
            Quanzhong = DryOperationWeight * RC;
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <returns></returns>
        public string Output()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("DOW\t\tDOI\tH-arm\t%RC  \tQUANZHONG" + Environment.NewLine);
            //sb.Append(DryOperationWeight.ToString("#0.000") + "\t");
            //sb.Append(DryOperationIndex.ToString("#0.000") + "\t");
            //sb.Append(Harm.ToString("#0.000") + "\t");
            //sb.Append(RC.ToString("#0.000") + "\t");
            //sb.Append(Quanzhong.ToString("#0.000"));
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-12}", "DOW");
            sb.AppendFormat("{0,-10}", "DOI");
            sb.AppendFormat("{0,-10}", "H-arm");
            sb.AppendFormat("{0,-10}", "%RC");
            sb.AppendFormat("{0,-10}", "QUANZHONG");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-12}", DryOperationWeight.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", DryOperationIndex.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Harm.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", RC.ToString("#0.000"));
            sb.AppendFormat("{0,-10}", Quanzhong.ToString("#0.000"));
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }
    }
}

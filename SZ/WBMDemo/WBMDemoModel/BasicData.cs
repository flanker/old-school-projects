using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBMDemoModel
{
    /// <summary>
    /// 基本数据
    /// </summary>
    public class BasicData
    {
        /// <summary>
        /// 起飞机场
        /// </summary>
        public string FromAirport { get; set; }
        /// <summary>
        /// 到达机场
        /// </summary>
        public string ToAirport { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string Flight { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 时
        /// </summary>
        public string Hour { get; set; }
        /// <summary>
        /// 分
        /// </summary>
        public string Minute { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string ACReg { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }
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
        /// 输出
        /// </summary>
        /// <returns></returns>
        public string Output()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("DATE/TIME\tFROM/TO\tFLIGHT\tA/C REG\tVERSION\tCREW" + Environment.NewLine);
            //sb.Append(Day + Month + Year.Substring(2) + "/" + Hour + Minute + "\t");
            //sb.Append(FromAirport + "/" + ToAirport + "\t");
            //sb.Append(Flight + "\t");
            //sb.Append(ACReg + "\t");
            //sb.Append(Version + "\t");
            //sb.Append(Crew1.ToString() + "/" + Crew2.ToString() + "/" + Crew3.ToString());
            //sb.Append(Environment.NewLine);

            sb.AppendFormat("{0,-10}", "FROM/TO");
            sb.AppendFormat("{0,-10}", "FLIGHT");
            sb.AppendFormat("{0,-10}", "A/C REG");
            sb.AppendFormat("{0,-10}", "VERSION");
            sb.AppendFormat("{0,-8}", "CREW");
            sb.AppendFormat("{0,-10}", "DATE");
            sb.AppendFormat("{0,-10}", "TIME");
            sb.Append(Environment.NewLine);
            sb.AppendFormat("{0,-10}", FromAirport + "/" + ToAirport);
            sb.AppendFormat("{0,-10}", Flight);
            sb.AppendFormat("{0,-10}", ACReg);
            sb.AppendFormat("{0,-10}", Version);
            sb.AppendFormat("{0,-8}", Crew1.ToString() + "/" + Crew2.ToString() + "/" + Crew3.ToString());
            sb.AppendFormat("{0,-10}", Day + Month + Year.Substring(2));
            sb.AppendFormat("{0,-10}", Hour + Minute);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}

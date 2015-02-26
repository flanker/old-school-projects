using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class RuleTypeEnum
    {
        // None,
        // Week,
        // Month,
        // Year,
        // Date

        public static RuleTypeEnum Week
        {
            get { return new RuleTypeEnum("Week"); }
        }
        public static RuleTypeEnum Month
        {
            get { return new RuleTypeEnum("Month"); }
        }
        public static RuleTypeEnum Year
        {
            get { return new RuleTypeEnum("Year"); }
        }
        public static RuleTypeEnum Date
        {
            get { return new RuleTypeEnum("Date"); }
        }

        public string Name { get; set; }
        public int Value { get; set; }

        public RuleTypeEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = 0;
                    break;
                case "Week":
                    Value = 1;
                    break;
                case "Month":
                    Value = 2;
                    break;
                case "Year":
                    Value = 3;
                    break;
                case "Date":
                    Value = 4;
                    break;
            }
        }

        public RuleTypeEnum(int Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Week";
                    break;
                case 2:
                    Name = "Month";
                    break;
                case 3:
                    Name = "Year";
                    break;
                case 4:
                    Name = "Date";
                    break;
            }
        }

        public RuleTypeEnum(int? Value)
        {
            this.Value = Value.HasValue ? Value.GetValueOrDefault() : 0;
            switch (this.Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Week";
                    break;
                case 2:
                    Name = "Month";
                    break;
                case 3:
                    Name = "Year";
                    break;
                case 4:
                    Name = "Date";
                    break;
            }
        }
    }
}

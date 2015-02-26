using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class IsWorkDayEnum
    {
        // Null,
        // True,
        // False

        public static IsWorkDayEnum True
        {
            get { return new IsWorkDayEnum("True"); }
        }

        public static IsWorkDayEnum False
        {
            get { return new IsWorkDayEnum("False"); }
        }

        public string Name { get; set; }
        public bool Value { get; set; }

        public IsWorkDayEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = false; ;
                    break;
                case "True":
                    Value = true;
                    break;
                case "False":
                    Value = false;
                    break;
            }
        }

        public IsWorkDayEnum(bool Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case true:
                    Name = "True";
                    break;
                case false:
                    Name = "False";
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class ShiftTypeEnum
    {
        //None,
        //Normal,
        //Other
        public string Name { get; set; }
        public int Value { get; set; }

        public ShiftTypeEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = 0;
                    break;
                case "Normal":
                    Value = 1;
                    break;
                case "Other":
                    Value = 2;
                    break;
            }
        }

        public ShiftTypeEnum(int Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Normal";
                    break;
                case 2:
                    Name = "Other";
                    break;
            }
        }

        public ShiftTypeEnum(int? Value)
        {
            this.Value = Value.HasValue ? Value.GetValueOrDefault() : 0;
            switch (this.Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Normal";
                    break;
                case 2:
                    Name = "Other";
                    break;
            }
        }
    }

}

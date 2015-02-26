using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class PointTypeEnum
    {
        //None,
        //In,
        //Out

        public string Name { get; set; }
        public int Value { get; set; }

        public PointTypeEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = 0;
                    break;
                case "In":
                    Value = 1;
                    break;
                case "Out":
                    Value = 2;
                    break;
            }
        }

        public PointTypeEnum(int Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "In";
                    break;
                case 2:
                    Name = "Out";
                    break;
            }
        }

        public PointTypeEnum(int? Value)
        {
            this.Value = Value.HasValue ? Value.GetValueOrDefault() : 0;
            switch (this.Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "In";
                    break;
                case 2:
                    Name = "Out";
                    break;
            }
        }
    }
}

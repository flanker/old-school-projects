using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class WeekEnum
    {
        //Null,
        //Monday,
        //Tuesday,
        //Wednesday,
        //Thursday
        //Friday
        //Saturday
        //Sunday

        public string Name { get; set; }
        public int Value { get; set; }

        public WeekEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = 0;
                    break;
                case "Monday":
                    Value = 1;
                    break;
                case "Tuesday":
                    Value = 2;
                    break;
                case "Wednesday":
                    Value = 3;
                    break;
                case "Thursday":
                    Value = 4;
                    break;
                case "Friday":
                    Value = 5;
                    break;
                case "Saturday":
                    Value = 6;
                    break;
                case "Sunday":
                    Value = 7;
                    break;
            }
        }

        public WeekEnum(int Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Monday";
                    break;
                case 2:
                    Name = "Tuesday";
                    break;
                case 3:
                    Name = "Wednesday";
                    break;
                case 4:
                    Name = "Thursday";
                    break;
                case 5:
                    Name = "Friday";
                    break;
                case 6:
                    Name = "Saturday";
                    break;
                case 7:
                    Name = "Sunday";
                    break;
            }
        }

        public WeekEnum(int? Value)
        {
            this.Value = Value.HasValue ? Value.GetValueOrDefault() : 0;
            switch (this.Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "Monday";
                    break;
                case 2:
                    Name = "Tuesday";
                    break;
                case 3:
                    Name = "Wednesday";
                    break;
                case 4:
                    Name = "Thursday";
                    break;
                case 5:
                    Name = "Friday";
                    break;
                case 6:
                    Name = "Saturday";
                    break;
                case 7:
                    Name = "Sunday";
                    break;
            }
        }
    }
}

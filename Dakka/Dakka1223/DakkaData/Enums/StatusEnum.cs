using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData.Enums
{
    public class StatusEnum
    {
        //Null,
        //OK,

        public static StatusEnum Null
        {
            get { return new StatusEnum("Null"); }
        }
        public static StatusEnum OK
        {
            get { return new StatusEnum("OK"); }
        }
        public static StatusEnum Exception
        {
            get { return new StatusEnum("Exception"); }
        }

        public string Name { get; set; }
        public int Value { get; set; }

        public StatusEnum(string Name)
        {
            this.Name = Name;
            switch (Name)
            {
                case "Null":
                    Value = 0;
                    break;
                case "OK":
                    Value = 1;
                    break;
                case "Exception":
                    Value = 2;
                    break;
            }
        }

        public StatusEnum(int Value)
        {
            this.Value = Value;
            switch (Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "OK";
                    break;
                case 2:
                    Name = "Exception";
                    break;
            }
        }

        public StatusEnum(int? Value)
        {
            this.Value = Value.HasValue ? Value.GetValueOrDefault() : 0;
            switch (this.Value)
            {
                case 0:
                    Name = "Null";
                    break;
                case 1:
                    Name = "OK";
                    break;
                case 2:
                    Name = "Exception";
                    break;
            }
        }
    }
}

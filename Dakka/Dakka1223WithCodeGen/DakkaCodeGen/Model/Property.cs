using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaCodeGen.Model
{
    public class Property
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ValidateType Validate { get; set; }

        public Property(string Code, string Name, ValidateType Validate)
        {
            this.Code = Code;
            this.Name = Name;
            this.Validate = Validate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    partial class WorkCalendarRule
    {

        public class DTO
        {
            public string RuleType { get; set; }
            public string IsWorkDay { get; set; }
            public string Week { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string Day { get; set; }
            public string Number { get; set; }
            public string ShiftDef { get; set; }
        }
    }
}

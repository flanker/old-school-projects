using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace HappyTogether.Helper
{
    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }

        public RuleViolation(string ErrorMessage, string PropertyName)
        {
            this.ErrorMessage = ErrorMessage;
            this.PropertyName = PropertyName;
        }
    }
}

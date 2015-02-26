using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using flankerbase2.Helpers;
using System.Data.Linq;

namespace flankerbase2.Models
{
    public partial class Comment
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Name))
                yield return new RuleViolation("Name required", "Name");
            if (String.IsNullOrEmpty(Email))
                yield return new RuleViolation("Email required", "Email");
            if (String.IsNullOrEmpty(Content))
                yield return new RuleViolation("Content required", "Content");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using flankerbase2.Helpers;
using System.Data.Linq;

namespace flankerbase2.Models
{
    public partial class Blog
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Code))
                yield return new RuleViolation("代码不能为空", "Code");
            if (String.IsNullOrEmpty(Title))
                yield return new RuleViolation("标题不能为空", "Title");
            if (String.IsNullOrEmpty(Content))
                yield return new RuleViolation("内容不能为空", "Content");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }

    }
}

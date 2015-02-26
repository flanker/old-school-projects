using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using HappyTogether.Helper;

namespace HappyTogether.Models
{
    public partial class Post
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(PostBy))
                yield return new RuleViolation("用户不能为空", "PostBy");
            if (String.IsNullOrEmpty(UserName))
                yield return new RuleViolation("用户姓名不能为空", "UserName");
            if (String.IsNullOrEmpty(TinyURL))
                yield return new RuleViolation("用户头像不能为空", "TinyURL");
            if (String.IsNullOrEmpty(PostContent))
                yield return new RuleViolation("留言内容不能为空", "PostContent");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using HappyTogether.Helper;
using System.Web.Mvc;

namespace HappyTogether.Models
{
    public partial class Together
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Title))
                yield return new RuleViolation("标题不能为空", "Title");
            if (String.IsNullOrEmpty(Description))
                yield return new RuleViolation("描述不能为空", "Description");
            if (String.IsNullOrEmpty(HostedBy))
                yield return new RuleViolation("创建人不能为空", "HostedBy");
            if (String.IsNullOrEmpty(UserName))
                yield return new RuleViolation("创建人姓名不能为空", "UserName");
            if (String.IsNullOrEmpty(TinyURL))
                yield return new RuleViolation("创建人头像不能为空", "TinyURL");
            if (String.IsNullOrEmpty(Address))
                yield return new RuleViolation("地址不能为空", "Address");
            if (String.IsNullOrEmpty(ContactPhone))
                yield return new RuleViolation("联系电话不能为空", "ContactPhone");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }

        public bool IsHostedBy(string userID)
        {
            return HostedBy.Equals(userID, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsUserRegistered(string userID)
        {
            return this.Attendees.Any(a => a.AttendeeBy.Equals(userID, StringComparison.InvariantCultureIgnoreCase));
        }

        partial void OnTogetherTypeChanging(global::HappyTogether.Models.TogetherTypeEnum value)
        {
            PicURL = "/Content/Images/Logo/" + ((int)value).ToString() + ".png";
        }

        public string TogetherTypeString
        {
            get
            {
                return Together.GetStringFromTogetherType(TogetherType);
            }
        }

        public string FeeTypeString
        {
            get
            {
                return Together.GetStringFromFeeType(FeeType);
            }
        }

        public static string GetStringFromTogetherType(TogetherTypeEnum value)
        {
            switch (value)
            {
                case TogetherTypeEnum.Normal:
                    return "聚会";
                case TogetherTypeEnum.Sports:
                    return "体育活动";
                case TogetherTypeEnum.Lecture:
                    return "讲座";
                case TogetherTypeEnum.Game:
                    return "游戏娱乐";
                case TogetherTypeEnum.Music:
                    return "影音娱乐";
                case TogetherTypeEnum.Travel:
                    return "旅游";
                case TogetherTypeEnum.Online:
                    return "线上聚会";
                case TogetherTypeEnum.Public:
                    return "公益活动";
                case TogetherTypeEnum.Other:
                    return "其他";
                default:
                    return "聚会";
            }
        }

        public static string GetStringFromFeeType(FeeTypeEnum value)
        {
            switch (value)
            {
                case FeeTypeEnum.Free:
                    return "免费";
                case FeeTypeEnum.LT50:
                    return "50元内";
                case FeeTypeEnum.LT100:
                    return "100元内";
                case FeeTypeEnum.LT500:
                    return "500元内";
                case FeeTypeEnum.LT1000:
                    return "1000元内";
                case FeeTypeEnum.NoLimit:
                    return "很多钱";
                default:
                    return "免费";
            }
        }
    }
}

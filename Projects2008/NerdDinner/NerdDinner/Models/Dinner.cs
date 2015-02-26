using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Text.RegularExpressions;
using NerdDinner.Helper;
using System.Web.Mvc;

namespace NerdDinner.Models
{
    [Bind(Include = "Title,Description,EventDate,Address,Country,ContactPhone,Latitude,Longitude")]
    public partial class Dinner
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Title))
                yield return new RuleViolation("Title required", "Title");
            if (String.IsNullOrEmpty(Description))
                yield return new RuleViolation("Description required", "Description");
            if (String.IsNullOrEmpty(HostedBy))
                yield return new RuleViolation("HostedBy required", "HostedBy");
            if (String.IsNullOrEmpty(Address))
                yield return new RuleViolation("Address required", "Address");
            if (String.IsNullOrEmpty(Country))
                yield return new RuleViolation("Country required", "Country");
            if (String.IsNullOrEmpty(ContactPhone))
                yield return new RuleViolation("Phone# required", "ContactPhone");
            //if (!PhoneValidator.IsValidNumber(ContactPhone, Country))
            //yield return new RuleViolation("Phone# does not

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }

        public bool IsHostedBy(string userName)
        {
            return HostedBy.Equals(userName, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsUserRegistered(string userName)
        {
            return this.RSVPs.Any(r => r.AttendeeName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

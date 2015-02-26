using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using World_TimeSpace.Module;

namespace MvcTimeSpace.Models
{
    public class WCultureRepository
    {
        private readonly XPQuery<WorldCulture> _xpQuery = new XPQuery<WorldCulture>(Session.DefaultSession);

        public List<WorldCulture> GetAll()
        {
            return _xpQuery.ToList();
        }
        public WorldCulture GetWTime(string code)
        {
            return _xpQuery.Where(p => p.Id == code).FirstOrDefault();
        } 
    }
}
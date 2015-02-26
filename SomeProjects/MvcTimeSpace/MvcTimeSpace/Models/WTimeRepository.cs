using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using World_TimeSpace.Module;

namespace MvcTimeSpace.Models
{
    public class WTimeRepository
    {
        private readonly XPQuery<WorldTime> _xpQuery = new XPQuery<WorldTime>(Session.DefaultSession);

        public List<WorldTime> GetAll()
        {
            return _xpQuery.ToList();
        }

        public WorldTime GetByCode(string code)
        {
            return _xpQuery.Where(p => p.Id == code).FirstOrDefault();
        } 
    }
}
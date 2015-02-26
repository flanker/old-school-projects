using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using World_TimeSpace.Module;

namespace MvcTimeSpace.Models
{
    public class WRegionRepository
    {
        private readonly XPQuery<WorldRegion> _xpQuery = new XPQuery<WorldRegion>(Session.DefaultSession);

        public List<WorldRegion> GetAll()
        {
            return _xpQuery.ToList();
        }

        public WorldRegion GetByCode(string code)
        {
            return _xpQuery.Where(p => p.Id == code).FirstOrDefault();
        }    
    }
}
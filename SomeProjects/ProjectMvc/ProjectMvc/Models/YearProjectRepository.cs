using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using ProjectXAF.Module;
using System.Linq;

namespace ProjectMvc.Models
{
    public class YearProjectRepository
    {
        public List<YearProject> GetYearProjects(string projectCode)
        {
            var xpQuery = new XPQuery<YearProject>(Session.DefaultSession);
            return xpQuery.Where(y => y.Project.Code == projectCode).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using ProjectXAF.Module;

namespace ProjectMvc.Models
{
    public class ProjectRepository
    {
        private readonly XPQuery<Project> _xpQuery = new XPQuery<Project>(Session.DefaultSession);

        public List<Project> GetAll()
        {
            return _xpQuery.ToList();
        }

        public Project GetByCode(string code)
        {
            return _xpQuery.Where(p => p.Code == code).FirstOrDefault();
        }
    }
}
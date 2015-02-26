using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using kaogu_0730.Module;

namespace MvcWeb.Models
{
    public class ProjectRepository
    {
        private readonly XPQuery<Project> _query = new XPQuery<Project>(Session.DefaultSession);

        public List<Project> GetAll()
        {
            return _query.ToList();
        }

        public void Add(Project project)
        {
            project.Save();
        }

        public Project FindById(string id)
        {
            var guid = new Guid(id);
            return _query.SingleOrDefault(p => p.Oid == guid);
        }

        public void Update(Project project)
        {
            project.Save();
        }

        public void Delete(string id)
        {
            var project = FindById(id);
            project.Delete();
        }
    }
}
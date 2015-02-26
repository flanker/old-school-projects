using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Xpo;
using kaogu_0730.Module;

namespace MvcWeb.Helpers
{
    public class ProjectModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var id = controllerContext.HttpContext.Request["Oid"];
            if(!string.IsNullOrEmpty(id))
            {
                Guid guid;
                if (Guid.TryParse(id, out guid))
                {
                    var project = new XPQuery<Project>(Session.DefaultSession).SingleOrDefault(p => p.Oid == guid);
                    return project;
                }
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}
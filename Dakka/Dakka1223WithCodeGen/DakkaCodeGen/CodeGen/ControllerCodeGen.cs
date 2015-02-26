using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DakkaCodeGen.Model;

namespace DakkaCodeGen.CodeGen
{
    public class ControllerCodeGen
    {
        #region 字段属性

        public string Path { get; set; }            // 生成路径

        public string FileName { get { return Path + "//Helloworld.cs"; } }         // 生成文件名

        private StreamWriter writer;            // IO流

        public Entity MainEntity { get; set; }            // 控制器的名称

        #endregion

        #region 辅助方法

        private void WL()
        {
            writer.WriteLine();
        }

        private void WL(string Content)
        {
            writer.WriteLine(Content);
        }

        private void WL(string Format, params object[] args)
        {
            writer.WriteLine(string.Format(Format, args));
        }

        #endregion

        // WL("");

        public void CodeGen()
        {
            writer = new StreamWriter(FileName, false, Encoding.GetEncoding("gb2312"));

            this.GenHead();         // 生成控制器头部

            this.GenList();

            this.GenGetSome();

            this.GenNew();

            this.GenAddNew();

            this.GenFoot();         // 生成控制器尾部

            writer.Close();
            writer.Dispose();
        }

        private void GenHead()
        {
            WL("using System;");
            WL("using System.Collections.Generic;");
            WL("using System.Linq;");
            WL("using System.Web;");
            WL("using System.Web.Mvc;");
            WL("using System.Web.Mvc.Ajax;");
            WL("using DakkaData;");
            WL("using DakkaWeb.Filters;");
            WL();
            WL("namespace DakkaWeb.Controllers");
            WL("{");
            WL("    public class {0}Controller : Controller", this.MainEntity.Name);
            WL("    {");
        }

        private void GenFoot()
        {
            WL("    }");
            WL("}");
        }

        private void GenList()
        {
            WL();
            WL("        [Authorize]");
            WL("        [ExceptionToViewFilter]");
            WL("        public ActionResult List()");
            WL("        {");
            WL("            ViewData[\"Title\"] = \"{0}\";", this.MainEntity.Name);
            WL("            return View();");
            WL("        }");
        }

        private void GenGetSome()
        {
            WL();
            WL("        [Authorize]");
            WL("        public JsonResult GetSome()");
            WL("        {");
            WL("            int start = int.Parse(this.Request[\"start\"]);");
            WL("            int limit = int.Parse(this.Request[\"limit\"]);");
            WL("            int {0}Count = {0}.GetAllCount();", this.MainEntity.Name);
            WL("            List<{0}.DTO> {0}Some = {0}.GetSome(start, limit);", this.MainEntity.Name);
            WL("            var result = new {{ totalProperty = {0}Count, root = {0}Some }};", this.MainEntity.Name);
            WL("            return Json(result);");
            WL("        }");
        }

        private void GenNew()
        {
            WL();
            WL("        [Authorize]");
            WL("        [ExceptionToViewFilter]");
            WL("        public ActionResult New()");
            WL("        {");
            WL("            ViewData[\"Title\"] = \"Add New {0}\";", this.MainEntity.Name);
            WL("            return View();");
            WL("        }");
        }

        private void GenAddNew()
        {
            WL();
            WL("        [Authorize]");
            WL("        [AcceptVerbs(HttpVerbs.Post)]");
            WL("        [ExceptionToJsonFilter]");
            WL("        public JsonResult AddNew()");
            WL("        {");
            WL("            #region 接受Request");
            foreach (Property p in this.MainEntity.DefaultDTO.PropertyList)
            {
                WL("            string {0} = this.Request[\"{0}\"];", p.Name);
            }
            if (MainEntity.DefaultDTO.HasSub)
            {
                WL("            string {0} = this.Request[\"{0}\"];", MainEntity.DefaultDTO.SubDTO.Name);
            }
            WL("            #endregion");
            WL();
            WL("            #region 校验Request");
            foreach (Property p in this.MainEntity.DefaultDTO.PropertyList)
            {
                GenValidateRequest(p);
            }
            WL("            #endregion");
            WL();
            WL("            #region 解析子DTO");
            if (MainEntity.DefaultDTO.HasSub)
            {
                GenParseSubDTO(MainEntity.DefaultDTO.SubDTO);
            }
            WL("            #endregion");
            WL();
            WL("            #region 组装DTO");
            if (MainEntity.DefaultDTO.HasSub)
            {
            }
            WL("            #endregion");
            WL("");
            WL("        }");
        }

        private void GenValidateRequest(Property item)
        {
            if (item.Validate == ValidateType.None)
            {
                return;
            }
            if (item.Validate == ValidateType.NotNull)
            {
                WL("            if (string.IsNullOrEmpty({0}))", item.Name);
                WL("            {");
                WL("                throw new BaseException(\"{0} can not be empty!\");", item.Name);
                WL("            }");
            }
        }

        private void GenParseSubDTO(DTO subDTO)
        {
            WL("            JObject json = JObject.Parse({0});", subDTO.Name);
            WL("            var lines = from one in json[\"data\"].Children()");
            WL("                         select new {0}.DTO", subDTO.Name);
            WL("                         {");
            foreach (Property p in subDTO.PropertyList)
            {
                WL("                             {0} = one.Value<string>(\"{0}\"),", p.Name);
            }
            WL("                         };");

        }

    }

}

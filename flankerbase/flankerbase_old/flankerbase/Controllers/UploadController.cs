using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using flankerbase.Libs;

namespace flankerbase.Controllers
{
    public class UploadController : AppControllerBase
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Upload(HttpPostedFileBase fileToUpload)
        {
            if (fileToUpload != null)
            {
                string path = Server.MapPath("/Files/");
                DateTime today = DateTime.Today;
                string dirname = string.Format("/Files/{0}/{1}/", today.Year, today.Month);
                string dir = string.Format("{0}{1}\\{2}", path, today.Year, today.Month);
                Directory.CreateDirectory(dir);
                string ext = Path.GetExtension(fileToUpload.FileName);
                int i = 1;
                string filename;
                string fname;
                do
                {
                    fname = string.Format("{0}{1}", i++, ext);
                    filename = Path.Combine(dir, fname);
                }
                while (System.IO.File.Exists(filename));
                fileToUpload.SaveAs(filename);
                string response = string.Format("{0}{1}", dirname, fname);
                if (fileToUpload.ContentType.ToLower().StartsWith("image/"))
                {
                    response = string.Format("<img src=\"{0}\"/>", response);
                }
                else
                {
                    response = string.Format("<a href=\"{0}\">{1}</a>", response, fileToUpload.FileName);
                }
                return Render(0, response);
            }
            return Render(1, "No any file uploaded.");
        }

        [Authorize]
        private ActionResult Render(int status, string message)
        {
            const string fmt = "<script language='javascript'> window.parent.uploadFileResponse('{{ status:{0},message:\\\'{1}\\\'}}'); </script>";
            return new PlainResult(string.Format(fmt, status, message));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace flankerbase.Controllers
{
    public class ClientCodeController : ControllerBase
    {
        //
        // GET: /demo/javascript-simple-3d-tag-cloud/

        public ActionResult Javascript_Simple_3D_Tag_Cloud()
        {
            return View("~/Views/Demo/Javascript-Simple-3D-Tag-Cloud/Javascript-Simple-3D-Tag-Cloud.aspx");
        }

        //
        // GET: /demo/javascript-snake-game/

        public ActionResult Javascript_Snake_Game()
        {
            return View("~/Views/Demo/Javascript-Snake-Game/Javascript-Snake-Game.aspx");
        }

        //
        // GET: /snake/

        public ActionResult Redirect_Javascript_Snake_Game()
        {
            return PermanentRedirect("Javascript_Snake_Game");
        }

        //
        // GET: /demo/pacific-war-timeline-map/

        public ActionResult Pacific_War_Timeline_Map()
        {
            return View("~/Views/Demo/Pacific-War-Timeline-Map/Pacific-War-Timeline-Map.aspx");
        }

        //
        // GET: /pacificwar/

        public ActionResult Redirect_Pacific_War_Timeline_Map()
        {
            return PermanentRedirect("Pacific_War_Timeline_Map");
        }

        //
        // GET: /google-chrome-extension/

        public ActionResult Google_Chrome_Extension()
        {
            return View("~/Views/Demo/Google-Chrome-Extension/Google-Chrome-Extension.aspx");
        }
    }
}

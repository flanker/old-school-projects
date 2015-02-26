using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using flankerbase.Models;
using flankerbase.Models.Music;

namespace flankerbase.Controllers
{
    [HandleError]
    [Title("music")]
    public class MusicController : AppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Playlist(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/Music.aspx/Playlist/Pop");
            }

            PlaylistModel pl = PlaylistModelFactory.CreatePlaylistModel(id);

            return View(pl);
        }

        // return: xml
        public ActionResult GetList(string id)
        {
            string serverPath = Server.MapPath("/Content/Music/" + id);

            if (!Directory.Exists(serverPath))
            {
                return null;
            }

            string[] files = Directory.GetFiles(serverPath);

            playlist list = new playlist();
            list.title = "flanker music playlist";
            list.info = "http://fengzhichao.cn";
            list.trackList = new List<track>();

            foreach (string s in files)
            {
                if (s.ToLower().EndsWith(".mp3"))
                {
                    MP3 m = new MP3();
                    m.fileComplete = s;
                    MP3Helper.readMP3Tag(ref m);

                    track t = new track();
                    t.annotation = m.ArtistTitle;
                    int index = m.fileComplete.IndexOf("\\Content\\Music");
                    t.location = m.fileComplete.Substring(index).Replace('\\', '/');
                    t.info = "";
                    t.image = "";
                    list.trackList.Add(t);
                }
            }

            return new XmlResult(list, list.GetType());
        }

    }
}

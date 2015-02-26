using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase.Models.Music
{
    public class PlaylistModel
    {
        public string LinkName { get; set; }
        public string LinkTitle { get; set; }
        public PlayerType PlayerType { get; set; }
        public string ListName { get; set; }

    }

    public enum PlayerType
    {
        Local,
        Online
    }

    public class PlaylistModelFactory
    {
        public static PlaylistModel CreatePlaylistModel(string id)
        {
            PlaylistModel pl = new PlaylistModel();

            switch (id)
            {
                case "Pop":
                    pl.LinkName = "Pop";
                    pl.LinkTitle = "欧美流行";
                    pl.PlayerType = PlayerType.Local;
                    pl.ListName = "Pop";
                    break;
                case "Jay":
                    pl.LinkName = "Jay";
                    pl.LinkTitle = "周杰伦";
                    pl.PlayerType = PlayerType.Local;
                    pl.ListName = "Jay";
                    break;
                case "8mile":
                    pl.LinkName = "8mile";
                    pl.LinkTitle = "8mile";
                    pl.PlayerType = PlayerType.Local;
                    pl.ListName = "8mile";
                    break;
                case "PopOnline":
                    pl.LinkName = "PopOnline";
                    pl.LinkTitle = "Pop radio online";
                    pl.PlayerType = PlayerType.Online;
                    pl.ListName = "http://www.100hitz.com/playlists/Top40.asx";
                    break;
                case "HiphopOnline":
                    pl.LinkName = "HiphopOnline";
                    pl.LinkTitle = "Hip-Hop radio online";
                    pl.PlayerType = PlayerType.Online;
                    pl.ListName = "http://www.100hitz.com/playlists/HipHop.asx";
                    break;
                default:
                    pl.LinkName = "Pop";
                    pl.LinkTitle = "欧美流行";
                    pl.PlayerType = PlayerType.Local;
                    pl.ListName = "Pop";
                    break;
            }

            return pl;
        }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace flankerbase
{
    public class MP3Helper
    {
        public static void readMP3Tag(ref   MP3 paramMP3)
        {
            //   Read   the   128   byte   ID3   tag   into   a   byte   array  
            FileStream oFileStream;
            oFileStream = new FileStream(paramMP3.fileComplete, FileMode.Open);
            byte[] bBuffer = new byte[128];
            oFileStream.Seek(-128, SeekOrigin.End);
            oFileStream.Read(bBuffer, 0, 128);
            oFileStream.Close();

            //   Convert   the   Byte   Array   to   a   String  
            Encoding instEncoding = Encoding.GetEncoding("gb2312");      //   NB:   Encoding   is   an   Abstract   class  
            string id3Tag = instEncoding.GetString(bBuffer, 0 ,3);

            //   If   there   is   an   attched   ID3   v1.x   TAG   then   read   it    
            if (id3Tag == "TAG")
            {
                //paramMP3.id3Title = id3Tag.Substring(3, 30).Trim();
                //paramMP3.id3Artist = id3Tag.Substring(33, 30).Trim();
                //paramMP3.id3Album = id3Tag.Substring(63, 30).Trim();
                //paramMP3.id3Year = id3Tag.Substring(93, 4).Trim();
                //paramMP3.id3Comment = id3Tag.Substring(97, 28).Trim();

                ////   Get   the   track   number   if   TAG   conforms   to   ID3   v1.1  
                //if (id3Tag[125] == 0)
                //    paramMP3.id3TrackNumber = bBuffer[126];
                //else
                //    paramMP3.id3TrackNumber = 0;
                //paramMP3.id3Genre = bBuffer[127];
                //paramMP3.hasID3Tag = true;

                paramMP3.id3Title = instEncoding.GetString(bBuffer, 3, 30).Trim();
                paramMP3.id3Artist = instEncoding.GetString(bBuffer, 33, 30).Trim();
                paramMP3.id3Album = instEncoding.GetString(bBuffer, 63, 30).Trim();
                paramMP3.id3Year = instEncoding.GetString(bBuffer, 93, 4).Trim();
                paramMP3.id3Comment = instEncoding.GetString(bBuffer, 97, 28).Trim();

                //   Get   the   track   number   if   TAG   conforms   to   ID3   v1.1  
                if (bBuffer[125] == 0)
                    paramMP3.id3TrackNumber = bBuffer[126];
                else
                    paramMP3.id3TrackNumber = 0;
                paramMP3.id3Genre = bBuffer[127];
                paramMP3.hasID3Tag = true;
                //   *********   IF   USED   IN   ANGER:   ENSURE   to   test   for   non-numeric   year  
            }
            else
            {
                //   ID3   Tag   not   found   so   create   an   empty   TAG   in   case   the   user   saces   later  
                paramMP3.id3Title = "";
                paramMP3.id3Artist = "";
                paramMP3.id3Album = "";
                paramMP3.id3Year = "";
                paramMP3.id3Comment = "";
                paramMP3.id3TrackNumber = 0;
                paramMP3.id3Genre = 0;
                paramMP3.hasID3Tag = false;
            }
        }
    }

    public class MP3
    {
        public string filePath;
        public string fileFileName;
        public string fileComplete;
        public bool hasID3Tag;
        public string id3Title;
        public string id3Artist;
        public string id3Album;
        public string id3Year;
        public string id3Comment;
        public byte id3TrackNumber;
        public byte id3Genre;

        public string id3Artist2
        {
            get
            {
                int index = id3Artist.IndexOf('\0');
                if (index > 0)
                {
                    return id3Artist.Substring(0, id3Artist.IndexOf('\0'));
                }
                else
                {
                    return id3Artist;
                }
            }
        }
        public string id3Title2
        {
            get
            {
                int index = id3Title.IndexOf('\0');
                if (index > 0)
                {
                    return id3Title.Substring(0, id3Title.IndexOf('\0'));
                }
                else
                {
                    return id3Title;
                }
            }
        }

        public string ArtistTitle { get { return id3Artist2 + " - " + id3Title2; } }
    }
}

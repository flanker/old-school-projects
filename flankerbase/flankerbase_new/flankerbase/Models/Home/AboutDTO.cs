using System;
using System.Collections.Generic;

namespace flankerbase.Models
{
    public class AboutDTO
    {
        public List<string> Tags { get; set; }

        public AboutDTO()
        {
            Tags = new List<string>();
        }

        public static AboutDTO GetAboutDTO()
        {
            AboutDTO data = new AboutDTO();
            data.Tags.AddRange(new string[] { 
                "flanker", 
                "侧卫",
                "北京",
                "西安",
                "处女座",
                "程序员",
                "XJTUer",
                "准Geek",
                "伪军迷",
                "tee",
                "圣斗士",
                "《兵器》",
                "Android",
                "Call of Duty",
                "可乐",
                "葵花籽"});
            return data;
        }
    }
}

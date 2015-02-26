using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaCodeGen.Model
{
    public class DTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Property> PropertyList { get; set; }
        public bool HasSub { get; set; }
        public DTO SubDTO { get; set; }

        public DTO()
        {
            PropertyList = new List<Property>();
        }

        public void Add(Property item)
        {
            this.PropertyList.Add(item);
        }
    }
}

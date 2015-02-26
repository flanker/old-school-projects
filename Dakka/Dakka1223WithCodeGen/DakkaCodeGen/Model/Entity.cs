using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaCodeGen.Model
{
    public class Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Property> PropertyList { get; set; }
        public bool HasSub { get; set; }
        public Entity SubEntity { get; set; }
        public DTO DefaultDTO { get; set; }

        public Entity()
        {
            PropertyList = new List<Property>();
        }

        public void Add(Property item)
        {
            this.PropertyList.Add(item);
        }
    }
}

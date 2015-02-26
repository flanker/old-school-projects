using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    public partial class ShiftPoint
    {

        public struct DTO
        {
            public int IndexNumber { get; set; }
            public string Name { get; set; }
            public string PointTime { get; set; }
            public int PointType { get; set; }
            public string Description { get; set; }
        }
        
    }
}

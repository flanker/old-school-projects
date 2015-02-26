using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase.Models
{
    public class TodoDTO
    {
        public ProcessDTO Process { get; set; }

        public IList<Todo> Todos { get; set; }
    }

    public class ProcessDTO
    {
        public int AllCount { get; set; }

        public int AllFinishCount { get; set; }

        public string Percent { get; set; }
    }
}

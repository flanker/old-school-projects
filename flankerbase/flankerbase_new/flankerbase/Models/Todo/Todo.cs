using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase.Models
{
    public class Todo
    {
        public Todo()
        {

        }

        public Todo(int ID)
        {
            this.ID = ID;
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? FinishedAt { get; set; }

        public void DoValid()
        {
            if (String.IsNullOrEmpty(this.Description))
            {
                throw new Exception("内容不能为空");
            }
        }
    }
}

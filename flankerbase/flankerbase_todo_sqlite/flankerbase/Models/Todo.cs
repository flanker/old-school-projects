﻿using System;
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

        public int ID { get; private set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public void DoValid()
        {
            if (String.IsNullOrEmpty(this.Description))
            {
                throw new Exception("内容不能为空");
            }
        }
    }
}

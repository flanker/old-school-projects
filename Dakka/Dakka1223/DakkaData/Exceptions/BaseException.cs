using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    public class BaseException : ApplicationException
    {
        public new string Message { get; set; }

        public BaseException(string Message)
        {
            this.Message = Message;
        }

    }
}

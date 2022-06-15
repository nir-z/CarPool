using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models.Exceptions
{
    public class AppException: Exception
    {

        public int StatusCode { get; set; }

        public string PayloadMsg { get; set; }

        public AppException()
        {
        }

        public AppException(string message)
        : base(message)
        {
        }

        public AppException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}

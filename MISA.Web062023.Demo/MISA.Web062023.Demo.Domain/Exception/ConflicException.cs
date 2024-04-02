using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web062023.Demo.Domain
{
    public class ConflicException : Exception
    {
        public int ErrorCode { get; set; }
        public ConflicException() { }
        public ConflicException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        public ConflicException(string message) : base(message) { }
        public ConflicException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }


}

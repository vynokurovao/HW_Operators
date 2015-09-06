using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Operators
{
    public class VendorMismatchException : Exception
    {
        public VendorMismatchException(string message)
            : base(message)
        {

        }
    }
}

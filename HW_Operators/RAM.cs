using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Operators
{
    public class RAM
    {
        public RAM(string vendor, double value)
        {
            Vendor = vendor;
            Value = value;
        }

        public string Vendor { get; set; }
        public double Value { get; set; }

        public static RAM operator+(RAM ram1, RAM ram2)
        {
            if (!ram1.Vendor.Equals(ram2.Vendor))
            {
                throw new VendorMismatchException("The vendors are different.");
            }

            return new RAM(ram1.Vendor, ram1.Value + ram2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RAM ram = obj as RAM;
            if (ram == null)
            {
                return false;
            }

            return this.Vendor.Equals(ram.Vendor) && this.Value.Equals(ram.Value);
        }

        public override int GetHashCode()
        {
            return this.Vendor.GetHashCode() ^ this.Value.GetHashCode();
        }
    }
}

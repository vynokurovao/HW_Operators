using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Operators
{
    public class HDD
    {
        public HDD(string vendor, double value)
        {
            Vendor = vendor;
            Value = value;
        }

        public string Vendor { get; set; }
        public double Value { get; set; }

        public static HDD operator+(HDD hdd1, HDD hdd2)
        {
            if (!hdd1.Vendor.Equals(hdd2.Vendor))
            {
                throw new VendorMismatchException("The vendors are different.");
            }

            return new HDD(hdd1.Vendor, hdd1.Value + hdd2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            HDD hdd = obj as HDD;
            if (hdd == null)
            {
                return false;
            }

            return this.Vendor.Equals(hdd.Vendor) && this.Value.Equals(hdd.Value);
        }

        public override int GetHashCode()
        {
            return this.Vendor.GetHashCode() ^ this.Value.GetHashCode();
        }
    }
}

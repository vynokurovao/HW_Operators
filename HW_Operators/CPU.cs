using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Operators
{
    public class CPU
    {
        public CPU (string vendor, double value)
        {
            Vendor = vendor;
            Value = value;
        }

        public string Vendor { get; set; }
        public double Value { get; set; }

        public static CPU operator+(CPU cpu1, CPU cpu2)
        {
            if (!cpu1.Vendor.Equals(cpu2.Vendor))
            {
                throw new VendorMismatchException("The vendors are different.");
            }
            
            return new CPU(cpu1.Vendor, cpu1.Value + cpu2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            CPU cpu = obj as CPU;
            if (cpu == null)
            {
                return false;
            }

            return this.Vendor.Equals(cpu.Vendor) && this.Value.Equals(cpu.Value);
        }

        public override int GetHashCode()
        {
            return this.Vendor.GetHashCode() ^ this.Value.GetHashCode();
        }

    }
}

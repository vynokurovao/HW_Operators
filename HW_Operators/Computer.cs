using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Operators
{
    public class Computer
    {
        public Computer(string hostName, string description, RAM ram, HDD hdd, CPU cpu)
        {
            HostName = hostName;
            Description = description;
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
        }

        public string HostName { get; set; }
        public string Description { get; set; }
        public RAM Ram { get; set; }
        public HDD Hdd { get; set; }
        public CPU Cpu { get; set; }

        public Computer Clone()
        {
            return new Computer(HostName, Description, Ram, Hdd, Cpu);
        }

        public Computer DeepClone()
        {
            return new Computer(String.Copy(HostName),
                String.Copy(Description),
                new RAM(Ram.Vendor, Ram.Value),
                new HDD(Hdd.Vendor, Hdd.Value),
                new CPU(Hdd.Vendor, Hdd.Value));
        }

        public static Computer operator+(Computer computer1, Computer computer2)
        {
            return new Computer(computer1.HostName, computer1.Description,
                computer1.Ram + computer2.Ram,
                computer1.Hdd + computer2.Hdd,
                computer1.Cpu + computer2.Cpu);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Computer comp = obj as Computer;
            if (comp == null)
            {
                return false;
            }

            return this.HostName.Equals(comp.HostName)
                && this.Description.Equals(comp.Description)
                && this.Hdd.Equals(comp.Hdd)
                && this.Ram.Equals(comp.Ram)
                && this.Cpu.Equals(comp.Cpu);
        }

        public override int GetHashCode()
        {
            return this.HostName.GetHashCode()
                ^ this.Description.GetHashCode()
                ^ this.Hdd.GetHashCode()
                ^ this.Ram.GetHashCode()
                ^ this.Cpu.GetHashCode();
        }
    }
}
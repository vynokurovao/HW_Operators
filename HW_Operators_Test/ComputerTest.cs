
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW_Operators;

namespace HW_Operators_Test
{            
    [TestClass]
    public class ComputerTest
    {
        Computer comp1 = new Computer("first", "notebook", 
            new RAM("Samsung", 3),
            new HDD("Dell", 320),
            new CPU("HP", 2.0));
        Computer comp2 = new Computer("second", "notebook",
            new RAM("Samsung", 2),
            new HDD("Dell", 220),
            new CPU("HP", 3.0));
        Computer comp3 = new Computer("third", "notebook",
            new RAM("Dell", 3),
            new HDD("Dell", 320),
            new CPU("HP", 2.0));

        [TestMethod]
        public void AddComputersWithSameVendors()
        {
            Computer actual = comp1 + comp2;
            Computer expected = new Computer("first", "notebook", 
                new RAM("Samsung", 5),
                new HDD("Dell", 540),
                new CPU("HP", 5.0));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(VendorMismatchException), "The vendors are different.")]
        public void AddComputersWithDifferentVendors()
        {
            Computer actual = comp1 + comp3;
        }

        [TestMethod]
        public void CloneMethod()
        {
            Computer comp1Clone = comp1.Clone();
            Assert.IsTrue(comp1.Hdd == comp1Clone.Hdd
                && comp1.Ram == comp1Clone.Ram
                && comp1.Cpu == comp1Clone.Cpu);
        }

        [TestMethod]
        public void DeepCloneMethod()
        {
            Computer comp1Clone = comp1.DeepClone();
            Assert.IsTrue(comp1.Hdd != comp1Clone.Hdd
                && comp1.Ram != comp1Clone.Ram
                && comp1.Cpu != comp1Clone.Cpu);
        }
    }
}

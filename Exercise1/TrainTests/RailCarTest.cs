using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainSystem;

namespace TrainTests
{
    [TestClass]
    public class RailCarTest
    {
        [TestMethod]
        [DataRow("18172", 38800, 130000, 130200, RailCarType.COAL_CAR, true)]
        public void CreateRailCar_GoodRailCars_RailCarsMade(string serialnumber, int lightweight, int capacity, int loadlimit, RailCarType type, bool inservice)
        {
            try
            {
                RailCar theRailCar = new RailCar(serialnumber, lightweight, capacity, loadlimit, type, inservice);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }
        [TestMethod]
        [DataRow("null", "", 38800, 130000, 130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", -38800, 130000, 130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 3880, 130000, 130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 38800, 130000, -130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 38800, 130000, 13020, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 38800, -130000, 130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 38800, 130010, 130200, RailCarType.COAL_CAR, true)]
        [DataRow("OutOfRange", "18172", 38800, 138000, 130200, RailCarType.COAL_CAR, true)]
        public void CreateEngine_BadEngines_ExceptionThrown(string testType, string serialnumber, int lightweight, int capacity, int loadlimit, RailCarType type, bool inservice)
        {
            try
            {
                RailCar theRailCar = new RailCar(serialnumber, lightweight, capacity, loadlimit, type, inservice);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentNullException)
            {
                if (testType != "null")
                {
                    Assert.Fail($"Incorrect type of exception thrown. Arguement null thrown when {testType} expected.");
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                if (testType != "OutOfRange")
                {
                    Assert.Fail($"Incorrect type of exception thrown. Arguement out of range thrown when {testType} expected.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught: {ex.Message}");
            }
        }

        [TestMethod]
        public void WeightsCheck_GoodRecordScaleWeight_FullTrue()
        {
            try
            {
                RailCar theRailCar = new RailCar("18172", 38800, 130000, 130200, RailCarType.COAL_CAR, true);
                theRailCar.RecordScaleWeight(164900);
                Assert.AreEqual(theRailCar.GrossWeight, 164900);
                Assert.AreEqual(theRailCar.NetWeight, 126100);
                Assert.IsTrue(theRailCar.IsFull);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
        [TestMethod]
        public void WeightsCheck_GoodRecordScaleWeight_FullFalse()
        {
            try
            {
                RailCar theRailCar = new RailCar("18172", 38800, 130000, 130200, RailCarType.COAL_CAR, true);
                theRailCar.RecordScaleWeight(144900);
                Assert.AreEqual(theRailCar.GrossWeight, 144900);
                Assert.AreEqual(theRailCar.NetWeight, 106100);
                Assert.IsFalse(theRailCar.IsFull);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        public void RecordWeight_GrossWeightNegative_ErrorMsg()
        {
            int grossWeight = -144900;
            try
            {
                RailCar theRailCar = new RailCar("18172", 38800, 130000, 130200, RailCarType.COAL_CAR, true);
                theRailCar.RecordScaleWeight(grossWeight);
                Assert.Fail("ArgumentOutOfRangeException expected and was not thrown. Gross Weight must be positive.");
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Assert.AreEqual<string>($"Gross weight {grossWeight} must be positive", aor.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
}

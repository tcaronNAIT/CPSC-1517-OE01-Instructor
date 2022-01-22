using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainSystem;

namespace TrainTests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        [DataRow("CP 8002", "48807", 147700, 4400)]
        public void CreateEngine_GoodEngines_EnginesMade(string model, string serialNumber, int weight, int hp)
        {
            try
            {
                Engine theEngine = new Engine(model, serialNumber, weight, hp);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
            
        }
        [TestMethod]
        [DataRow("null","", "48807", 147700, 4400)]
        [DataRow("null","CP 8002", "", 147700, 4400)]
        [DataRow("OutOfRange","CP 8002", "48807", -147700, 4400)]
        [DataRow("OutOfRange","CP 8002", "48807", 147770, 4400)]
        [DataRow("OutOfRange","CP 8002", "48807", 147700, -4400)]
        [DataRow("OutOfRange","CP 8002", "48807", 147700, 4440)]
        public void CreateEngine_BadEngines_ExceptionThrown(string type, string model, string serialNumber, int weight, int hp)
        {
            try
            {
                Engine theEngine = new Engine(model, serialNumber, weight, hp);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentNullException)
            {
                if (type != "null")
                {
                    Assert.Fail($"Incorrect type of exception thrown. Arguement null thrown when {type} expected.");
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                if (type != "OutOfRange")
                {
                    Assert.Fail($"Incorrect type of exception thrown. Arguement out of range thrown when {type} expected.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught: {ex.Message}");
            }
        }
    }
}
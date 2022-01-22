using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car_Object_Example;
using System;

namespace TestCar
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void CreateEngine_GoodEngineWith0Cylinders_EngineMade()
        {
            try
            {
                Engine engine = new Engine(1.6, 120, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
        [TestMethod]
        public void CreateEngine_GoodEngineWith6Cylinders_EngineMade()
        {
            Engine engine = null!;
            try
            {
                engine = new Engine(1.6, 120, 6);
            }
            catch
            {
                Assert.IsNotNull(engine, "Engine with 6 cylinders failed.");
            }
        }
        [TestMethod]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(9)]
        public void CreateEngine_OddValues_ErrorThrown(int value)
        {
            Engine engine;
            Action newEngine = () => engine = new Engine(1.6, 120, value);
            Assert.ThrowsException<ArgumentOutOfRangeException>(newEngine);
        }
    }
}
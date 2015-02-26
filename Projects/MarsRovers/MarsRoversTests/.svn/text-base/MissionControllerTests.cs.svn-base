using System;
using NUnit.Framework;
using MarsRovers;
using System.Text;

namespace MarsRoversTests
{
    [TestFixture]
    public class MissionControllerTests
    {
        [Test]
        public void TestMissionStart()
        {
            string demoInput = 
                    "5 5" + Environment.NewLine
                    + "1 2 N" + Environment.NewLine
                    + "LMLMLMLMM" + Environment.NewLine
                    + "3 3 E" + Environment.NewLine
                    + "MMRMMRMRRM" + Environment.NewLine;
            StringBuilder sb = new StringBuilder();

            new MockMissionController(demoInput, sb).MissionStart();

            Assert.AreEqual("1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine, 
                    sb.ToString());
        }

        // mock MissionController using string as I/O
        private class MockMissionController : MissionController
        {
            public MockMissionController(string input, StringBuilder sb)
            {
                Rreader = new System.IO.StringReader(input);
                Writer = new System.IO.StringWriter(sb);
            }
        }
    }
}

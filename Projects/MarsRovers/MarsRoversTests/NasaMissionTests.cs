using System;
using NUnit.Framework;
using MarsRovers;
using System.Collections.Generic;

namespace MarsRoversTests
{
    [TestFixture]
    public class NasaMissionTests
    {
        [Test]
        public void TestNasaPlanSingleton()
        {
            NasaMission nasaPlan1 = NasaMission.Instance;
            NasaMission nasaPlan2 = NasaMission.Instance;

            Assert.IsTrue(nasaPlan1 == nasaPlan2);
        }

        [Test]
        public void TestNasaPlanRunning()
        {
            NasaMission.Instance.Clear();
            MockCommand.Result = String.Empty;

            NasaMission.Instance.AddCommand(new MockCommand(1));
            NasaMission.Instance.AddCommand(new MockCommand(2));
            NasaMission.Instance.AddCommand(new MockCommand(3));

            NasaMission.Instance.Run();

            Assert.AreEqual("123", MockCommand.Result);
        }

        // mock for testing command can run in NasaMission
        private class MockCommand : Command
        {
            private readonly int seed = -1;
            public static string Result { get; set; }

            public MockCommand(int mySeed)
            {
                seed = mySeed;
            }

            public void Execute()
            {
                Result += seed.ToString();
            }
        }
    }


}

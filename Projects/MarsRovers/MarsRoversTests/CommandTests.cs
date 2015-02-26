using System;
using NUnit.Framework;
using MarsRovers;

namespace MarsRoversTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void TestRoverTurnRight()
        {
            CommandFactory factory = new TurnRightCommandFactory();

            TestRoverCommand(0, 0, "N", factory).DirectionIs("E").PositionIs(0, 0);
            TestRoverCommand(1, 2, "W", factory).DirectionIs("N").PositionIs(1, 2);
            TestRoverCommand(2, 1, "S", factory).DirectionIs("W").PositionIs(2, 1);
            TestRoverCommand(3, 3, "E", factory).DirectionIs("S").PositionIs(3, 3);
        }

        [Test]
        public void TestRoverTurnLeft()
        {
            CommandFactory factory = new TurnLeftCommandFactory();

            TestRoverCommand(0, 0, "N", factory).DirectionIs("W").PositionIs(0, 0);
            TestRoverCommand(1, 2, "W", factory).DirectionIs("S").PositionIs(1, 2);
            TestRoverCommand(2, 1, "S", factory).DirectionIs("E").PositionIs(2, 1);
            TestRoverCommand(3, 3, "E", factory).DirectionIs("N").PositionIs(3, 3);
        }

        [Test]
        public void TestRoverMoveForward()
        {
            CommandFactory factory = new MoveForwardCommandFactory();

            TestRoverCommand(0, 0, "N", factory).DirectionIs("N").PositionIs(0, 1);
            TestRoverCommand(1, 2, "W", factory).DirectionIs("W").PositionIs(0, 2);
            TestRoverCommand(2, 1, "S", factory).DirectionIs("S").PositionIs(2, 0);
            TestRoverCommand(3, 3, "E", factory).DirectionIs("E").PositionIs(4, 3);
        }

        // create rover and execute command
        private static CommandTestHelper TestRoverCommand(int beginX, int beginY, string beginDirection, CommandFactory factory)
        {
            Rover rover = new Rover(beginX, beginY, beginDirection);

            Command command = factory.Create(rover);
            command.Execute();

            return new CommandTestHelper(rover.X, rover.Y, rover.Direction);
        }
    }
}

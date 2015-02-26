using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MarsRovers;

namespace MarsRoversTests
{
    // simplify the assert and make method call chaining
    internal class CommandTestHelper
    {
        private int X { get; set; }
        private int Y { get; set; }
        private string Direction { get; set; }

        internal CommandTestHelper(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        internal CommandTestHelper DirectionIs(string expectedDirection)
        {
            Assert.AreEqual(expectedDirection, Direction);

            return this;
        }

        internal CommandTestHelper PositionIs(int expectedX, int expectedY)
        {
            Assert.AreEqual(expectedX, X);
            Assert.AreEqual(expectedY, Y);

            return this;
        }
    }

    // used in CommandTests to create command
    interface CommandFactory
    {
        Command Create(Rover rover);
    }

    internal class TurnLeftCommandFactory : CommandFactory
    {
        public Command Create(Rover rover)
        {
            return new TurnLeftCommand(rover);
        }
    }

    internal class TurnRightCommandFactory : CommandFactory
    {
        public Command Create(Rover rover)
        {
            return new TurnRightCommand(rover);
        }
    }

    internal class MoveForwardCommandFactory : CommandFactory
    {
        public Command Create(Rover rover)
        {
            return new MoveForwardCommand(rover);
        }
    }
}

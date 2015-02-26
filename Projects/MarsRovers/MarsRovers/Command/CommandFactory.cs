using System;

namespace MarsRovers
{
    public sealed class CommandFactory
    {
        public static Command Create(char cmd, Rover rover)
        {
            switch (cmd)
            {
                case 'L':
                    return new TurnLeftCommand(rover);
                case 'R':
                    return new TurnRightCommand(rover);
                case 'M':
                    return new MoveForwardCommand(rover);
                default:
                    return null;
            }
        }
    }
}

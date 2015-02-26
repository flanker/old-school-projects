using System;

namespace MarsRovers
{
    public class MoveForwardCommand : Command
    {
        private readonly Rover rover;

        public MoveForwardCommand(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute()
        {
            switch (rover.Direction)
            {
                case "N":
                    rover.Y++;
                    break;
                case "E":
                    rover.X++;
                    break;
                case "S":
                    rover.Y--;
                    break;
                case "W":
                    rover.X--;
                    break;
            }
        }
    }
}

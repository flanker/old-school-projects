using System;

namespace MarsRovers
{
    public class TurnLeftCommand : Command
    {
        private readonly Rover rover;

        public TurnLeftCommand(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute()
        {
            switch (rover.Direction)
            {
                case "N":
                    rover.Direction = "W";
                    break;
                case "W":
                    rover.Direction = "S";
                    break;
                case "S":
                    rover.Direction = "E";
                    break;
                case "E":
                    rover.Direction = "N";
                    break;
            }
        }
    }
}

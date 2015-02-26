using System;

namespace MarsRovers
{
    public class TurnRightCommand : Command
    {
        private readonly Rover rover;

        public TurnRightCommand(Rover rover)
        {
            this.rover = rover;
        }

        public void Execute()
        {
            switch (rover.Direction)
            {
                case "N":
                    rover.Direction = "E";
                    break;
                case "E":
                    rover.Direction = "S";
                    break;
                case "S":
                    rover.Direction = "W";
                    break;
                case "W":
                    rover.Direction = "N";
                    break;
            }
        }
    }
}

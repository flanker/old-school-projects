using System;
using System.Collections.Generic;

namespace MarsRovers
{
    public class NasaMission
    {
        private static readonly NasaMission plan = new NasaMission();

        public int MaxX { get; set; }
        public int MaxY { get; set; }

        // so the client can enumerate the rovers but cannot edit the list directly
        private List<Rover> rovers = new List<Rover>();
        public IEnumerable<Rover> Rovers { get { return rovers; } }

        private List<Command> commands = new List<Command>();

        private NasaMission()
        {
        }

        public static NasaMission Instance
        {
            get { return plan; }
        }

        public void AddRover(Rover rover)
        {
            rovers.Add(rover);
            rover.OnMoved = Rover_Moved;
        }

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public void Run()
        {
            foreach (Command cmd in commands)
            {
                cmd.Execute();
            }
        }

        public void Clear()
        {
            rovers.Clear();
            commands.Clear();
        }

        private void Rover_Moved(Rover rover)
        {
            if (rover.X < 0 || rover.Y < 0
                || rover.X > this.MaxX || rover.Y > this.MaxY)
            {
                throw new Exception("Rover crashed because of falling off the plateau.");
            }
        }
    }
}

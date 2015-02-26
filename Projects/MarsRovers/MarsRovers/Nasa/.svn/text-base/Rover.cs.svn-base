using System;

namespace MarsRovers
{
    public class Rover
    {
        private int x;
        public int X 
        {
            get { return x; }
            set
            {
                x = value;
                Move();
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                Move();
            }
        }
        public string Direction { get; set; }

        // fire moved event
        public RoverMovedHandler OnMoved { get; set; }
        private void Move()
        {
            if (OnMoved != null)
            {
                OnMoved(this);
            }
        }

        public Rover(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }

    public delegate void RoverMovedHandler(Rover rover);
}

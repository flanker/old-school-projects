using System;
using System.IO;

namespace MarsRovers
{
    public abstract class MissionController
    {
        protected TextReader Rreader { get; set; }
        protected TextWriter Writer { get; set; }

        public void MissionStart()
        {
            InitNasaPlan();

            NasaMission.Instance.Run();

            ProcessResult();
        }

        private void InitNasaPlan()
        {
            NasaMission.Instance.Clear();

            string[] strs = Rreader.ReadLine().Split(' ');
            NasaMission.Instance.MaxX = int.Parse(strs[0]);
            NasaMission.Instance.MaxY = int.Parse(strs[1]);

            AddRoverAndCommands();
        }

        private void AddRoverAndCommands()
        {
            while (true)
            {
                string line = Rreader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                else
                {
                    Rover r = AddRover(line);
                    AddCommands(r);
                }
            }
        }

        private Rover AddRover(string line)
        {
            string[] roverLine = line.Split(' ');
            Rover r = new Rover(int.Parse(roverLine[0]), int.Parse(roverLine[1]), roverLine[2]);
            NasaMission.Instance.AddRover(r);
            return r;
        }

        private void AddCommands(Rover rover)
        {
            string commandsLine = Rreader.ReadLine();
            foreach (char cmd in commandsLine)
            {
                NasaMission.Instance.AddCommand(CommandFactory.Create(cmd, rover));
            }
        }

        private void ProcessResult()
        {
            foreach (Rover rover in NasaMission.Instance.Rovers)
            {
                Writer.WriteLine("{0} {1} {2}", rover.X, rover.Y, rover.Direction);
            }
        }
    }
}

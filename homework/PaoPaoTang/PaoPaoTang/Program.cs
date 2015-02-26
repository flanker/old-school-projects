using System;

namespace Bomb
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (OurGame game = new OurGame())
            {
                game.Run();
            }
        }
    }
}
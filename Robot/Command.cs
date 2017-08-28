using System;
namespace Program
{
    public class Command
    {
        Location Landing { get; set; }
        string Instructions { get; set; }

        public Command(Location Landing, string Instructions)
        {
            this.Landing = Landing;
            this.Instructions = Instructions;
        }
    }

}

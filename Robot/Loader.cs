using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Program
{
    public class Command{
        Location Landing { get; set; }
        string Instruction { get; set; }
    }


    public class Loader
    {
        public string Raw;
        public string Dimensions;
        public Queue<String> Robots;


        public Loader(string FilePath)
        {
            var Root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            TextReader input = new StreamReader(Path.Combine(Root,FilePath));
			this.Raw = input.ReadToEnd();

            // Separate in lines
            var Lines = this.Raw.Split('\n');

            // Take the first line
            this.Dimensions = Lines[0];

            // Shift the rest
            Array.Copy(Lines, 1, Lines, 0, Lines.GetLength(0) - 1);

            // Load the robots commands
            this.Robots = this.GetRobots(Lines);

		}

  
        private Queue<string> GetRobots(Array Lines)
        {
            Queue<string> Result = new Queue<string>();
            bool alternate = true;
            string temp = string.Empty;

            foreach (string Line in Lines)
            {
                if (alternate)
                {
                    // First Line = Landing
                    temp = Line;
                }
                else
                {
                    // Second line = Instructions
                    Result.Enqueue(string.Concat(temp, " ", Line));
                }
                alternate = !alternate;

            }

            return Result;
        }

    }
}

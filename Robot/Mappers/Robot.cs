using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Program
{
    public class Robots_Mapping
    {
        // Properties
        public Queue<Robot> Mapped { get; set; }

        // Constructor
        public Robots_Mapping(Queue<string> Robots)
        {
            Queue<Robot> Result = new Queue<Robot>();
            while(Robots.Count>0){
                
                string[] RobotLine = Robots.Dequeue().Trim().Split(' '); // Perhaps before this I can do a Regex

                // Check if the line has the expected elements
                if (RobotLine.Length != 5) throw new Exception("Invalid Line");

                try
                {
                    // Map the fields;
                    int x = Convert.ToInt16(RobotLine[0]);
                    int y = Convert.ToInt16(RobotLine[1]);
                    char orientation = Convert.ToChar(RobotLine[2]);
                    string instructions = RobotLine[4];



                    // Check if orientation is among the valid commands
                    if (orientation !='N' && orientation != 'S' && orientation != 'E' && orientation != 'W'){
                        throw new Exception("Orientation invalid");
                    }

					// Check if the instructions make sense
                    if (!FormatValid(instructions)){
                        throw new Exception("Some robot command are not valid.");
                    }

					// Check than less that 100 chars.
					if (instructions.Length > 100)
					{
						throw new Exception("Instructions for the Robot are too long");
					}


                    // Create the robot and add it to a queue
					Robot Robot = new Robot(x, y, orientation, instructions);
					Result.Enqueue(Robot);


                }catch(Exception ex){
                    throw ex;
                }

              
            }

            // Map to a Queue of robot objects
            this.Mapped = Result;
        }


		private bool FormatValid(string format)
		{
			string allowableLetters = "FRL";

			foreach (char c in format)
			{
				if (!allowableLetters.Contains(c.ToString()))
					return false;
			}

			return true;
		}
    }
};

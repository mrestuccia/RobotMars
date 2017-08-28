using System;
using System.Collections.Generic;

namespace Program
{
    public class Robot
    {
        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public char Orientation { get; set; }
        public string Command { get; set; }
        public bool IsLost { get; set; }
		public int PreviousX { get; set; } // Memory
		public int PreviousY { get; set; }


		// Private
		private IDictionary<char, char> _left { get; set; }
        private IDictionary<char, char> _right { get; set; }


        // Constructor
        public Robot(int x, int y, char orientation, string command)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.Command = command;

			// Internal programming 
			_left =  new Dictionary<char, char>();
            this._left.Add('N', 'W');
			this._left.Add('W', 'S');
            this._left.Add('S', 'E');
            this._left.Add('E', 'N');

			_right = new Dictionary<char, char>();
			this._right.Add('N', 'E');
			this._right.Add('E', 'S');
			this._right.Add('S', 'W');
			this._right.Add('W', 'N');

		}

        // Methods
        public void Rotate(char direction)
        {
            switch (direction){
                case 'L':
                    this.Orientation = this._left[this.Orientation];
                    break;
                case 'R':
                    this.Orientation = this._right[this.Orientation];
                    break;
            }
        }

        public void Forward(){
            switch (this.Orientation){
                case 'N':
                    this.Y++;
                    break;
                case 'S':
                    this.Y--;
                    break;
                case 'E':
                    this.X++;
                    break;
                case 'W':
                    this.X--;
                    break;
            }
        }


        public void ExecuteRobot(World world)
        {


            this.IsLost = false;

            foreach (char command in this.Command)
            {

                if (!world.OutOfRange(this))
                {
                    // Previous
                    this.PreviousX = this.X;
                    this.PreviousY = this.Y;

                    // Move or Rotate 
                    if (command == 'F')
                    {
                        var current = new Location(this.X, this.Y, this.Orientation);
                        if (!world.IsSpreayed(current))
                        {
                            this.Forward();
                        }
                    }
                    else
                    {
                        this.Rotate(command);
                    }
                }
                else
                {
                    world.Spray(new Location(this.PreviousX, this.PreviousY, this.Orientation));
                    this.IsLost = true;
                }
            }
        }

    }
}
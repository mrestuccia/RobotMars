using System;

namespace Program
{
    public class Location
    {
		public int X { get; set; }
		public int Y { get; set; }
		public char Orientation { get; set; }


        // Contructor
        public Location(int x, int y, char orientation)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
        }


        // Overwite for comparison of locations object
		public override bool Equals(object obj)
		{
			if (obj is Location)
			{
				return (obj as Location).X == X && (obj as Location).Y == Y && (obj as Location).Orientation == Orientation;
			}
			return false;
		}
    }
}

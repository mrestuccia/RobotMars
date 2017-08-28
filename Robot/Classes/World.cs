using System;
using System.Collections.Generic;

namespace Program
{
	public class World
	{
        // Properties
        public int width { get; set; }
        public int height { get; set; }
        public Queue<Location> scents { get; set; } 

        // Constructor
        public World(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.scents = new Queue<Location>();
        }

        // Methods
        public bool OutOfRange(Robot robot){
            return ((robot.X < 0) || (robot.Y < 0) || (robot.X > this.width) || (robot.Y > this.height));
        }

        public void Spray(Location scent){
            this.scents.Enqueue(scent);
        }

        public bool IsSpreayed(Location input)
        {
            return this.scents.Contains(input);  
        }

	}
}

using System;
namespace Program
{
    public class World_Mapping
    {
        // Properties
        int width { get; set; }
        int height { get; set; }

        // Contructor
        public World_Mapping(string line)
        {
            //Init variables
            width = 0;
            height = 0;

            try
            {
                width = Convert.ToInt16(line.Trim().Split(' ')[0]);
                height = Convert.ToInt16(line.Trim().Split(' ')[1]);
            }catch{
                throw new Exception("Issue mapping the planet dimensions."); 
            }


            // Check if positive
            if(width<=0 || height<=0){
                throw new Exception("World need positive numbers greater than 0");
            }

			// Check if less than 50
			if (width > 50 || height > 50)
			{
				throw new Exception("World cannot be larger than 50x50");
			}

        }

        // Create the world
        public World Create(){
			return new World(width, height);
        }
    }
}

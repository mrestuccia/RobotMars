using System;

namespace Program
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            var input = (args.Length == 0) ? "input.txt": args[0].ToString();

            // Load from the file
            var Load = new Loader("input/" + input);

            // Map to the object World and Robot
            var Dimensions = Load.Dimensions;

            // Create the world = Welcome to Mars :]
            var MyWorld = new World_Mapping(Dimensions).Create();

            // Loop for the robots
            var MyRobots = new Robots_Mapping(Load.Robots);

            while(MyRobots.Mapped.Count > 0){
                // Get one robot
                var MyRobot = MyRobots.Mapped.Dequeue();

                // Run the robot
                MyRobot.ExecuteRobot(MyWorld);

                // Print the output
                if (MyRobot.IsLost){
					Console.WriteLine("{0} {1} {2} LOST", MyRobot.PreviousX,MyRobot.PreviousY, MyRobot.Orientation);

				}else{
					Console.WriteLine("{0} {1} {2} ", MyRobot.X, MyRobot.Y, MyRobot.Orientation);
				}
               

            }

            Console.ReadKey();
        }
    }
}

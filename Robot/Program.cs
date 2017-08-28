using System;

namespace Program
{
    class MainClass
    {

        public static void ExecuteRobot(Robot robot, World world)
        {


            robot.IsLost = false;

            foreach (char command in robot.Command)
            {

                if (!world.OutOfRange(robot))
                {
                    // Previous
					robot.PreviousX = robot.X;
					robot.PreviousY = robot.Y;

                    // Move or Rotate 
                    if (command == 'F')
                    {
                        var current = new Location(robot.X, robot.Y, robot.Orientation);
                        if (!world.IsSpreayed(current))
                        {
                            robot.Forward();
                        }
                    }
                    else
                    {
                        robot.Rotate(command);
                    }
                }
                else
                {
                    world.Spray(new Location(robot.PreviousX, robot.PreviousY, robot.Orientation));
                    robot.IsLost = true;
                }
            }
        }


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
                ExecuteRobot(MyRobot, MyWorld);

                // Print the output
                if (MyRobot.IsLost){
					Console.WriteLine("{0} {1} {2} LOST", MyRobot.PreviousX,MyRobot.PreviousY, MyRobot.Orientation);

				}else{
					Console.WriteLine("{0} {1} {2} ", MyRobot.X, MyRobot.Y, MyRobot.Orientation);
				}
               

            }
        }
    }
}

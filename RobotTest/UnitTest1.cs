using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

namespace RobotTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Dimensions()
        {
            World myWorld;

            // Check Dimension of the world should exit
            try
            {
                myWorld = new World_Mapping(" ").Create();
            }catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Issue mapping the planet dimensions");
            }

            // Check empty worlds are not created
            try
            {
                myWorld = new World_Mapping("0 0").Create();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "World need numbers greater than 0");
            }

            // Check dimensions does not exceed 50
            try
            {
                myWorld = new World_Mapping("60 60").Create();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "World cannot be larger than 50x50");
            }


        }


        [TestMethod]
        public void RobotRotation()
        {
            World myWorld = new World_Mapping("2 2").Create();

            // Robot One Right
            Robot myRobot = new Robot(0, 0, 'N', "R");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.Orientation, 'E');

            // Robot 2 right
            myRobot = new Robot(0, 0, 'N', "RR");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.Orientation, 'S');

            // Robot 3 right
            myRobot = new Robot(0, 0, 'N', "RRR");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.Orientation, 'W');

            // Robot Full Spin
            myRobot = new Robot(0, 0, 'N', "RRRR");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.Orientation, 'N');



        }


        [TestMethod]
        public void RobotMove()
        {
            World myWorld = new World_Mapping("2 2").Create();

            // Robot One Right
            Robot myRobot = new Robot(0, 0, 'N', "FFFF");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.IsLost, true);

            // The Robot left scent
            Assert.AreEqual(myWorld.scents.ToArray()[0], new Location(0,2,'N'));

            // Next robot uses scent
            myRobot = new Robot(0, 0, 'N', "FFFFFRFF");
            myRobot.ExecuteRobot(myWorld);
            Assert.AreEqual(myRobot.X, 2);

        }

    }
}

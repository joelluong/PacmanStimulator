using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PacmanStimulatorTest
{
    using PacmanSimulator;
    using PacmanSimulator.Models;

    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestPLaceMethodWhenPacmanNull()
        {
            Pacman pacman = null;
            Grid grid = new Grid(pacman);
            CommandProcessor commandProcessor;
            string userCommand;

            userCommand = "PLACE 0,1,NORTH";
            commandProcessor = new CommandProcessor(grid, userCommand);

            commandProcessor.Execute();

            Assert.AreEqual(grid.Pacman.X, 0);
            Assert.AreEqual(grid.Pacman.Y, 1);
            Assert.AreEqual(grid.Pacman.Facing, Facing.North);
        }

        [TestMethod]
        public void TestReportMethod()
        {
            Pacman pacman = null;
            Grid grid = new Grid(pacman);
            CommandProcessor commandProcessor;
            string userCommand;

            userCommand = "PLACE 0,1,NORTH";
            commandProcessor = new CommandProcessor(grid, userCommand);

            commandProcessor.Execute();

            Assert.AreEqual("Output: 0,1,NORTH\n", grid.Report());
        }

        [TestMethod]
        public void TestLeftMethod()
        {
            Pacman pacman = null;
            Grid grid = new Grid(pacman);
            CommandProcessor commandProcessor;
            string userCommand;

            userCommand = "PLACE 0,1,NORTH";
            commandProcessor = new CommandProcessor(grid, userCommand);
            commandProcessor.Execute();

            commandProcessor.UserCommand = "LEFT";
            commandProcessor.Execute();

            Assert.AreEqual("Output: 0,1,WEST\n", grid.Report());
        }

        [TestMethod]
        public void TestRightMethod()
        {
            Pacman pacman = null;
            Grid grid = new Grid(pacman);
            CommandProcessor commandProcessor;
            string userCommand;

            userCommand = "PLACE 0,1,NORTH";
            commandProcessor = new CommandProcessor(grid, userCommand);
            commandProcessor.Execute();

            commandProcessor.UserCommand = "RIGHT";
            commandProcessor.Execute();

            Assert.AreEqual("Output: 0,1,EAST\n", grid.Report());
        }

        [TestMethod]
        public void TestRightMethodWhenPacmanNull()
        {
            Pacman pacman = null;
            Grid grid = new Grid(pacman);
            CommandProcessor commandProcessor;
            string userCommand;

            userCommand = "RIGHT";
            commandProcessor = new CommandProcessor(grid, userCommand);
            commandProcessor.Execute();


            Assert.AreEqual(grid.Pacman, null);
        }
    }
}

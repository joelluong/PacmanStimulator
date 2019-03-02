using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator
{
    using PacmanSimulator.Models;

    public class CommandProcessor
    {
        private string _userCommand;

        private string[] _userCommandArray;

        private Grid _grid;

        char xInputChar, yInputChar;
        int xInputInt, yInputInt;
        Facing facingInput;

        public CommandProcessor(Grid grid, string userCommand)
        {
            this._grid = grid;
            this._userCommand = userCommand;

        }


        // write only
        public string UserCommand
        {
            set
            {
                _userCommand = value;
            }
        }

        public void Execute()
        {
            _userCommandArray = this._userCommand.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            // spit the input string into array
            // PLACE command should split into 4 elements in the array
            // the other command such as MOVE, LEFT, RIGHT should have only one element
            // invalid commands when the length of the array is greater than 4 or less than 1

            if (this._userCommandArray.Length < 1)
            {
                // in case user press "ENTER"
                Console.WriteLine("Please enter a command or enter 'STOP' to finish.");
            }
            else
            {
                if (this._grid.Pacman == null && this._userCommandArray[0].ToUpper() != "PLACE")
                {
                    Console.WriteLine("Please firstly place PACMAN by following command 'PLACE X,Y,FACING'");
                    Console.WriteLine("* X,Y is the position of Pacman on the grid of dimensions ");
                    Console.WriteLine("* FACING is the direction of Pacman");
                }
                else
                {
                    switch (_userCommandArray[0].ToUpper())
                    {
                        case "PLACE":
                            this.PlaceCommandProcessor();
                            break;
                        case "MOVE":
                            this._grid.Move();
                            break;

                        case "LEFT":
                            this._grid.Left();
                            break;

                        case "RIGHT":
                            this._grid.Right();
                            break;

                        case "REPORT":
                            Console.WriteLine(this._grid.Report());
                            break;

                        default:
                            Console.WriteLine("Invalid input! Please enter again or input 'STOP' to finish ");
                            break;
                    }
                }
            }
        }



        private void PlaceCommandProcessor()
        {
            // The place command is valid
            if (_userCommandArray.Length == 4)
            {
                if (_userCommandArray[1].Length > 1 || _userCommandArray[2].Length > 1)
                {
                    // incorrect position
                    Console.WriteLine("Please place PACMAN by following command 'PLACE X,Y,FACING'");
                    Console.WriteLine("* X,Y is the position of Pacman on the grid of dimensions ");
                    Console.WriteLine("* FACING is the direction of Pacman");
                }
                else
                {
                    xInputChar = _userCommandArray[1][0]; // convert to char
                    xInputInt = xInputChar - '0'; // then, convert to int

                    yInputChar = _userCommandArray[2][0];   // convert to char
                    yInputInt = yInputChar - '0'; // then, convert to int

                    if (xInputInt < 0 || xInputInt > 5 || yInputInt < 0 || yInputInt > 5)   // check whether Pacman is is correct position
                    {
                        Console.WriteLine("We can not put Pacman off the grid.");
                    }
                    else
                    {
                        // convert string direction to enum
                        facingInput = convertStringToFacingEnum(_userCommandArray[3]);

                        if (facingInput == Facing.None)
                        {
                            Console.WriteLine("Invalid Facing value. Please enter Place command again.");
                        }
                        else
                        {
                            if (this._grid.Pacman == null)
                            {
                                // the first place command is valid
                                _grid.Pacman = new Pacman(xInputInt, yInputInt, facingInput);
                            }
                            else
                            {
                                // the place command is valid
                                _grid.Place(xInputInt, yInputInt, facingInput);
                            }
                        }
                    }
                }
            }
            else
            {
                // incorrect PLACE command
                Console.WriteLine("Invalid input! Please enter 'PLACE X,Y,FACING'");
                Console.WriteLine("* X,Y is the position of Pacman on the grid of dimensions ");
                Console.WriteLine("* FACING is the direction of Pacman");
            }
        }


        private Facing convertStringToFacingEnum(string input)
        {
            switch (input.ToUpper())
            {
                case "NORTH":
                    return Facing.North;
                case "WEST":
                    return Facing.West;
                case "SOuTH":
                    return Facing.South;
                case "EAST":
                    return Facing.East;
                default:
                    return Facing.None;
            }
        }
    }
}

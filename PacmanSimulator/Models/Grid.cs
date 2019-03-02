using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator.Models
{
    public class Grid
    {
        private int _width = 5;

        private int _height = 5;

        private Pacman _pacman;

        public Grid(Pacman pacman)
        {
            this._pacman = pacman;
        }

        public int Width
        {
            get
            {
                return this._width;
            }
        }

        private int Height
        {
            get
            {
                return this._height;
            }
        }

        public Pacman Pacman
        {
            get
            {
                return this._pacman;
            }

            set
            {
                this._pacman = value;
            }
        }

        public void Place(int x, int y, Facing facing)
        {
            this._pacman.X = x;
            this._pacman.Y = y;
            this.Pacman.Facing = facing;

        }

        public void Move()
        {
            bool beOffGrid = true;
            switch (_pacman.Facing)
            {
                case Facing.North:
                    if (_pacman.Y == Height)
                    {
                        beOffGrid = false;
                    }
                    else
                    {

                        _pacman.Y++;
                    }
                    break;

                case Facing.West:
                    if (_pacman.X == 0)
                    {
                        beOffGrid = false;
                    }
                    else
                    {

                        _pacman.X--;
                    }
                    break;

                case Facing.South:
                    if (_pacman.Y == 0)
                    {
                        beOffGrid = false;
                    }
                    else
                    {

                        _pacman.Y--;
                    }
                    break;

                case Facing.East:
                    if (_pacman.X == Width)
                    {
                        beOffGrid = false;
                    }
                    else
                    {

                        _pacman.X++;
                    }
                    break;
            }

            if (beOffGrid == false)
            {
                Console.WriteLine("Pacman can not move off the grid!!!");
            }
        }

        public void Right()
        {
            switch (_pacman.Facing)
            {
                case Facing.North:
                    _pacman.Facing = Facing.East;
                    break;

                case Facing.East:
                    _pacman.Facing = Facing.South;
                    break;

                case Facing.South:
                    _pacman.Facing = Facing.West;
                    break;

                case Facing.West:
                    _pacman.Facing = Facing.North;
                    break;

            }
        }

        public void Left()
        {
            switch (_pacman.Facing)
            {
                case Facing.North:
                    _pacman.Facing = Facing.West;
                    break;

                case Facing.West:
                    _pacman.Facing = Facing.South;
                    break;

                case Facing.South:
                    _pacman.Facing = Facing.East;
                    break;

                case Facing.East:
                    _pacman.Facing = Facing.North;
                    break;
            }
        }

        public string Report()
        {
            return "Output: " + _pacman.X + "," + _pacman.Y + "," + _pacman.Facing.ToString().ToUpper() + "\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator.Models
{
    public class Pacman
    {
        private int _x;

        private int _y;

        private Facing _facing;

        public Pacman(int x, int y, Facing facing)
        {
            this._x = x;
            this._y = y;
            this._facing = facing;
        }

        public int X
        {
            get
            {
                return this._x;
            }

            set
            {
                this._x = value;
            }
        }

        public int Y
        {
            get
            {
                return this._y;
            }

            set
            {
                this._y = value;
            }
        }

        public Facing Facing
        {
            get
            {
                return this._facing;
            }

            set
            {
                this._facing = value;
            }
        }
    }
}

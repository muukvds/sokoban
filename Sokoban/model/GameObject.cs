using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class GameObject
    {

        public Floor CurrentLocation { get; set; }


        public bool Move(Direction direction)
        {
            bool moved = false;

            if (CurrentLocation.CanBeMovedOn)
            {
                MoveTo(direction);
            }

            return moved;
        }

        private void MoveTo(Direction direction)
        {

        }
    }
}

  
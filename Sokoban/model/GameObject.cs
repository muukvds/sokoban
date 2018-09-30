using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    abstract class GameObject
    {

        public Floor CurrentLocation { get; set; }


        public abstract bool Move(Direction direction);

        protected void MoveTo(Direction direction, Floor targetFloor)
        {
            targetFloor.GameObject = this;
            CurrentLocation.GameObject = null;
            CurrentLocation = targetFloor;
        }
    }
}

  
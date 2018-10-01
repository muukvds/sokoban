using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{

    class Player : GameObject
    {
        public int Steps { get; set; }


        public Player()
        {
            Steps = 0;
        }

        public override bool Move(Direction direction)
        {
            bool moved = false;

            if (CurrentLocation.NeighbourTile(direction).CanBeMovedOn)
            {   if (this.Moveble)
                {
                    if (CurrentLocation.NeighbourTile(direction) is Floor targetFloor)
                    {
                        if (targetFloor.GameObject == null)
                        {
                            MoveTo(direction, targetFloor);
                            moved = true;
                        }
                        else if (targetFloor.GameObject.Move(direction))
                        {

                            MoveTo(direction, targetFloor);
                            moved = true;

                        }
                    }
                }
            }

            Steps++;
            return moved;
        }
    }
}

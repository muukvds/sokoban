using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Worker : GameObject
    {

        public bool Sleeping { get; set; }

        public override bool Move(Direction direction)
        {
            bool moved = false;
            if (!Sleeping)
            {
                if (CurrentLocation.NeighbourTile(direction).CanBeMovedOn)
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
                Sleep();
            }
            else {
                Wake();
            }

            return moved;
        }


        private void Wake()
        {

            Sleeping = false;
        }

        private void Sleep()
        {

            Sleeping = true;
        }

    }
}

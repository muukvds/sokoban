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

        public Worker()
        {
            Moveble = false;
        }

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
                        else if (targetFloor.GameObject.Moveble)
                        {
                            if (targetFloor.GameObject.Move(direction))
                            {
                                MoveTo(direction, targetFloor);
                                moved = true;
                            }
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
            Random rnd = new Random();
            int i = rnd.Next(0, 100);

            if (i < 15)
            {
                Sleeping = false;
            }
        }

        private void Sleep()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 100);

            if (i < 15)
            {
                Sleeping = true;
            }
        }

    }
}

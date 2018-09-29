using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Wall : Tile
    {
        
        public Wall()
        {
            this.CanBeMovedOn = false;
        }

    }
}

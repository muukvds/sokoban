using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Destination : Floor
    {
              public override GameObject GameObject { get { return base.GameObject; } set{ base.GameObject = value; } }
    }
}

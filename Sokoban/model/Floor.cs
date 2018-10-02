using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Floor : Tile
    {
        private GameObject _gameObject;
        public virtual GameObject GameObject { get { return _gameObject; } set{ _gameObject = value; } }

        public Floor()
        {
            this.CanBeMovedOn = true;
        }

        public Floor(GameObject gameObject)
        {
            GameObject = gameObject;
            this.CanBeMovedOn = true;
        }

    }
}

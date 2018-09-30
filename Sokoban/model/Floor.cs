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
        public GameObject GameObject { get { return _gameObject; } set { _gameObject = value; } }

        public bool Destination { get; set; }

        public Floor(bool destination = false)
        {
            this.Destination = destination;
            this.CanBeMovedOn = true;
        }

        public Floor(GameObject gameObject)
        {
            _gameObject = gameObject;
            this.CanBeMovedOn = true;
        }

    }
}

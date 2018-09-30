using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Pit : Floor
    {
        private int _Durebillety;
        private bool _Broken;

        public Pit()
        {
            _Durebillety = 3;
            _Broken = false;
        }

        public void MovedOn()
        {
            _Durebillety--;

            if (_Durebillety <= 0)
            {
                _Broken = true;
            }
        }

        public bool Broken { get { return _Broken; } }

    }
}

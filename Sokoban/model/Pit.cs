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
        public bool Broken { get; private set; }

        public override GameObject GameObject { get { return base.GameObject; }
            set
            {
                if (value != null)
                {
                    if (Broken && value is Chest)
                    {
                        base.GameObject = null;
                        base._gameModel.RemoveChest();
                    }
                    else
                    {
                        base.GameObject = value;
                    }
                    if (_Durebillety <= 0)
                    {
                        Broken = true;
                    }
                    _Durebillety--;
                }
                else
                {
                    base.GameObject = value;
                }
            }
        }

        public Pit(GameModel gameModel)
        {
            _Durebillety = 3;
            Broken = false;
            base._gameModel = gameModel;
        }


    }
}

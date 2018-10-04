using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class Destination : Floor
    {

        private bool _chestSet;

        public Destination(GameModel gameModel)
        {
            base._gameModel = gameModel;
            base._gameModel.AddDestination();
            _chestSet = false;
        }

        public override GameObject GameObject
        {

            get { return base.GameObject; }
            set
            {
                base.GameObject = value;

                if (value != null)
                {
                    if (value is Chest)
                    {
                        base._gameModel.ChestPlacedOnDestination();
                        _chestSet = true;
                    }
                }
                else
                {
                    if (_chestSet)
                    {
                        base._gameModel.ChestRemovedFromDestination();
                        _chestSet = false;
                    }
                }
            }
        }
    }
}

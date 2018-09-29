using Sokoban.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    abstract class Tile
    {
        private Tile _topTile = null;
        private Tile _rightTile = null;
        private Tile _leftTile = null;
        private Tile _bottomTile = null;

        private bool _canBeMovedOn;

        public bool CanBeMovedOn { get { return _canBeMovedOn; } set { _canBeMovedOn = value; } }

        public void SetTile(Tile newTile,Direction direction)
        {
            switch (direction)
            {
  
                case Direction.DOWN:
                        if (_bottomTile == null)
                        {
                        _bottomTile = newTile;
                        newTile._topTile = this;
                        }
                        else
                        {
                        _bottomTile.SetTile(newTile, Direction.DOWN);
                        }
                    
                    break;

                case Direction.RIGHT:
                    if (_bottomTile == null)
                    {
                        if (_rightTile == null)
                        {
                            _rightTile = newTile;
                            if (this._topTile != null)
                            {
                                newTile._topTile = this._topTile._rightTile.SetBottemTile(newTile);
                            }
                            newTile._leftTile = this;
                        }
                        else
                        {
                            _rightTile.SetTile(newTile, Direction.RIGHT);
                        }
                    }
                    else {
                        _bottomTile.SetTile(newTile, Direction.RIGHT);
                    }
                        break;
            }
        }

        public Tile SetBottemTile(Tile bottemTile)
        {
            _bottomTile = bottemTile;

            return this;
        }
        public bool Move(Direction direction)
        {
            bool moved = false;
            switch (direction)
            {
                case Direction.UP:
                    if (_topTile.CanBeMovedOn)
                    {

                    }
                    break;
                case Direction.DOWN:
                    if (_bottomTile.CanBeMovedOn)
                    {

                    }
                    break;
                case Direction.LEFT:
                    if (_leftTile.CanBeMovedOn)
                    {

                    }
                    break;
                case Direction.RIGHT:
                    if (_rightTile.CanBeMovedOn)
                    {

                    }
                    break;

            }
            return moved;
        }
    }
}

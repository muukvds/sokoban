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

        public bool CanBeMovedOn { get; set; }


        public Tile NeighbourTile(Direction direction)
        {
            Tile NeighbourTile = null;
            switch (direction)
            {
                case Direction.UP:
                    NeighbourTile = _topTile;
                    break;
                case Direction.DOWN:
                    NeighbourTile = _bottomTile;
                    break;
                case Direction.LEFT:
                    NeighbourTile = _leftTile;
                    break;
                case Direction.RIGHT:
                    NeighbourTile = _rightTile;
                    break;
            }
            return NeighbourTile;
        }

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
 
    }
}

using Sokoban.controller;
using Sokoban.enums;
using Sokoban.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.helper
{
    class BoardHelper
    {
        private string _baseUrl;
        private GameController _Controller;

        public BoardHelper(string baseUrl, GameController controller)
        {
            _baseUrl = baseUrl;
            _Controller = controller;
        }

        public Tile getBoard(string boardNumber)
        {
            List<List<Char>> lBoard = new List<List<char>>();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + _baseUrl + "doolhof" + boardNumber + ".txt";
                string[] aBoard = File.ReadAllLines(path);

                foreach (String s in aBoard)
                {
                    List<Char> tileRowList = new List<char>();
                    foreach (Char tile in s.ToCharArray())
                    {
                        tileRowList.Add(tile);
                    }
                    lBoard.Add(tileRowList);
                }
            }
            catch(Exception)
            {
                _Controller.ShowStartMenu();
            }
            return generateTiles(lBoard);
        }

        private Tile generateTiles(List<List<Char>> lBoard)
        {
            Tile firstTile = null;

            foreach (List<Char> tileRow in lBoard)
            {
                bool firstOfRow = true;
                foreach (Char tile in tileRow)
                {
                    Tile newTile;

                    switch (tile)
                    {
                        case '#':
                            newTile = new Wall();
                        break;

                        case '@':
                            Player player = new Player();
                            newTile = new Floor(player);
                            player.CurrentLocation = (Floor)newTile;
                            _Controller.SetPlayer(player);
                            break;

                        case '.':
                            newTile = new Floor();
                            break;

                        case 'o':
                            Chest chest = new Chest();
                            newTile = new Floor(chest);
                            chest.CurrentLocation = (Floor)newTile;
                            break;

                        case 'x':
                            newTile = new Destination();
                            break;

                        case ' ':
                            newTile = new Empty();
                            break;
                        case '$':
                            Worker worker = new Worker();
                            newTile = new Floor(worker);
                            worker.CurrentLocation = (Floor)newTile;
                            _Controller.AddWorker(worker);
                            break;
                        case '~':
                            newTile = new Pit();
                            break;
                        default:
                            newTile = new Floor();
                            break;

                    }

                    if (firstTile != null)
                    {
                        if (firstOfRow)
                        {
                            firstTile.SetTile(newTile, Direction.DOWN);
                            firstOfRow = false;
                        }
                        else
                        {
                            firstTile.SetTile(newTile, Direction.RIGHT);
                        }
                    }
                    else {
                        firstTile = newTile;
                        firstOfRow = false;
                    }
                    
                }
            }
  
            return firstTile;
        }

    }
}

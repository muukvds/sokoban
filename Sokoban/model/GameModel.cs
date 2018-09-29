using Sokoban.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.model
{
    class GameModel
    {
        private GameController _controller;

        private Tile _firstTile;

        private int _Destinations;
        private int _ChestOnDestinations;


        public Player Player { get; set; }

        public GameModel(GameController controller)
        {
            _controller = controller;
        }

        public void Start()
        {
            _controller.ShowStartMenu();
        }

        public void Play(Tile firstTile)
        {
            _firstTile = firstTile;

            Console.WriteLine("game playing");
            Console.ReadLine();
        }


    }
}

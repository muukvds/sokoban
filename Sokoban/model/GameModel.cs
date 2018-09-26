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

        public GameModel(GameController controller)
        {
            _controller = controller;
        }

        public void Start()
        {
            _controller.ShowStartMenu();
        }

        public void Play(Tile tile)
        {
            Console.WriteLine("game playing");
            Console.ReadLine();
        }
    }
}

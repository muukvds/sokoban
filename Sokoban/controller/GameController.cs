using Sokoban.enums;
using Sokoban.helper;
using Sokoban.model;
using Sokoban.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.controller
{

    class GameController
    {
        private GameModel _Model;
        private GameView _View;

        public GameController()
        {
            _Model = new GameModel(this);
            _View = new GameView(this);
        }

        public void Start()
        {
            _Model.Start();
        }

        public void ShowStartMenu()
        {
            _View.PrintMenu();
        }

        public void ShowGame(Tile firstTile)
        {
            _View.PrintGame(firstTile);
        }

        public void PlayGame(string boardNumber)
        {
            _Model.Play(new BoardHelper("boards/", this).getBoard(boardNumber));
        }

        public void SetPlayer(Player player)
        {
            _Model.Player = player;
        }

        public void AddWorker(Worker worker)
        {
            _Model.AddWorker(worker);
        }

        public void MovePlayer(Direction direction)
        {
            _Model.MovePlayer(direction);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}

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
        private GameModel _model;
        private GameView _view;

        public GameController()
        {
            _model = new GameModel(this);
            _view = new GameView(this);
        }

  public void Start()
    {
            _model.Start();
    }

        public void ShowStartMenu()
        {
            _view.PrintMenu();
        }

        public void PlayGame(int boardNumber)
        {
            _model.Play(new BoardHelper("boards/").getBoard(boardNumber));
        }

        public void Quit()
        {

        }


    }

  
}

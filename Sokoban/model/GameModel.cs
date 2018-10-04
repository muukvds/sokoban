using Sokoban.controller;
using Sokoban.enums;
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
        private List<Worker> _workers = new List<Worker>();

        private int _chests;
        private int _destinations;
        private int _chestOnDestinations;


        public Player Player { get; set; }

        public GameModel(GameController controller)
        {
            _controller = controller;
        }

        public void Start()
        {
            _controller.ShowStartMenu();
        }

        public void ChestPlacedOnDestination()
        {
            _chestOnDestinations++;
            if (_chestOnDestinations >= _destinations)
            {
                _controller.EindGame(Player.Steps);
            }
        }

        public void ChestRemovedFromDestination()
        {
            _chestOnDestinations--;
        }

        public void MovePlayer(Direction direction)
        {
            Player.Move(direction);
            foreach (Worker worker in _workers)
            {
                worker.Move(RandomDirection());
            }
            Update();
        }

        public void Play(Tile firstTile)
        {
            _firstTile = firstTile;
            _controller.ShowGame(_firstTile);
        }

        private void Update()
        {
            _controller.ShowGame(_firstTile);
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public void AddDestination()
        {
            _destinations++;
        }

        public void AddChest()
        {
            _chests++;
        }

        public void RemoveChest()
        {
            _chests--;

            if (_destinations > _chests)
            {
                _controller.LostGame();
            }
        }
       

        private Direction RandomDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));

            return randomDirection;
        }
    }
}

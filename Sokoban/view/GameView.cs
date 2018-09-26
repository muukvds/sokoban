using Sokoban.controller;
using Sokoban.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.view
{
    class GameView
    {

        private GameController _controller;

        public GameView(GameController controller)
        {
            _controller = controller;
        }

        public void PrintMenu()
        {
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("| Welkom bij sokoban                                 |");
            Console.WriteLine("| betekenis van de symbolen   | doel van het spel    |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         | duw met de truck     |");
            Console.WriteLine("|     █ : muur                | de krat(ten)         |");
            Console.WriteLine("|     . : vloer               | de krat(ten)         |");
            Console.WriteLine("|     O : krat                | de krat(ten)         |");
            Console.WriteLine("|     0 : krat op bestemming  | de krat(ten)         |");
            Console.WriteLine("|     x : bestemming          | de krat(ten)         |");
            Console.WriteLine("|     @ : truck               | de krat(ten)         |");
            Console.WriteLine("|____________________________________________________|");
            Console.WriteLine("");
            Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");
            Console.ReadLine();

            string sInput = Console.ReadLine();

            if (sInput == "s")
            {
                _controller.Quit();
            }
            else
            {
                switch (sInput)
                    {
                    case "1":
                        _controller.PlayGame(int.Parse(sInput));
                        break;
                    case "2":
                        _controller.PlayGame(int.Parse(sInput));
                        break;
                    case "3":
                        _controller.PlayGame(int.Parse(sInput));
                        break;
                    case "4":
                        _controller.PlayGame(int.Parse(sInput));
                        break;
                    default:
                        Console.WriteLine("Geen geldige invoer");
                        PrintMenu();
                        break;
                }
            }
        }

        public void PrintGame(Player player)
        {

        }

    }
}

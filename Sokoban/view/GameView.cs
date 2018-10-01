﻿using Sokoban.controller;
using Sokoban.enums;
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
            Console.Clear();

            Console.WriteLine("______________________________________________________");
            Console.WriteLine("| Welkom bij sokoban                                 |");
            Console.WriteLine("| betekenis van de symbolen   | doel van het spel    |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         | duw met de truck     |");
            Console.WriteLine("|     █ : muur                | de krat(ten)         |");
            Console.WriteLine("|     . : vloer               | de krat(ten)         |");
            Console.WriteLine("|     O : krat                | de krat(ten)         |");
            Console.WriteLine("|     0 : krat op bestemming  | de krat(ten)         |");
            Console.WriteLine("|     X : bestemming          | de krat(ten)         |");
            Console.WriteLine("|     @ : truck               | de krat(ten)         |");
            Console.WriteLine("|____________________________________________________|");
            Console.WriteLine("");
            Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");

            string sInput = Console.ReadLine();

            if (sInput == "s")
            {
                _controller.Quit();
            }
            else
            {
                _controller.PlayGame(sInput);
               
            }
        }

        public void PrintGame(Tile FirstTile)
        {
            Console.Clear();
            Tile CurrentTile = FirstTile;
            Tile FirstLineTile = FirstTile;

            while (CurrentTile != null)
            {
                if (CurrentTile.NeighbourTile(Direction.RIGHT) != null)
                {
                    Console.Write(GetIcon(CurrentTile));
                    CurrentTile = CurrentTile.NeighbourTile(Direction.RIGHT);
                }
                else
                {
                    FirstLineTile = FirstLineTile.NeighbourTile(Direction.DOWN);
                    Console.WriteLine(GetIcon(CurrentTile));

                    if (FirstLineTile == null) { break; }
                    CurrentTile = FirstLineTile;
                }
            }
            _controller.MovePlayer(WaitForInput());
        }

        private string GetIcon(Tile tile)
        { 
            string Icon="";
     
            switch (tile.GetType().Name)
            {
                case "Wall":
                    Icon = "█";
                    break;

                case "Floor":
                    Floor floor = (Floor)tile;
                    if (floor.GameObject == null)
                    {
                        Icon = ".";
                    }
                    else
                    {
                        switch (floor.GameObject.GetType().Name)
                        {
                            case "Player":
                                Icon = "@";
                                break;

                            case "Worker":
                                if (((Worker)floor.GameObject).Sleeping)
                                {
                                    Icon = "Z";
                                }
                                else
                                {
                                    Icon = "$";
                                }
                                break;

                            case "Chest":
                                Icon = "O";
                                break;
                        }
                    }
                    break;

                case "Destination":
                    if (((Destination)tile).GameObject == null)
                    {
                        Icon = "X";
                    }
                    else if (((Destination)tile).GameObject.GetType().Name == "Chest")
                    {
                        Icon = "0";
                    }
                    else if (((Destination)tile).GameObject.GetType().Name == "Player")
                    {
                        Icon = "@";
                    }
                    break;

                case "Empty":
                    Icon = " ";
                    break;

                case "Pit":
                    if (((Pit)tile).Broken)
                    {
                        Icon = " ";
                    }
                    else { Icon = "~"; }
                    break;
            }
            return Icon;
        }

        private Direction WaitForInput()
        {
            Direction direction = Direction.UP;
            bool arroKeyPressed = false;
            while (!arroKeyPressed)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Direction.UP;
                            arroKeyPressed = true;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Direction.DOWN;
                            arroKeyPressed = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Direction.LEFT;
                            arroKeyPressed = true;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Direction.RIGHT;
                            arroKeyPressed = true;
                            break;
                        case ConsoleKey.Escape:
                            _controller.Quit();
                            break;
                    }
                }
            }
            return direction;
        }

    }
}

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

        public BoardHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Tile getBoard(int boardNumber)
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @""+ _baseUrl + "doolhof"+ boardNumber + ".txt");
            string[] aBoard = File.ReadAllLines(path);

            List<List<Char>> lBoard = new List<List<char>>();

            foreach (String s in aBoard)
            {
                List<Char> tileRowList = new List<char>();
                foreach (Char tile in s.ToCharArray())
                {
                    tileRowList.Add(tile);
                }
                lBoard.Add(tileRowList);
            }
            return generateTiles(lBoard);
        }

        private Tile generateTiles(List<List<Char>> lBoard)
        {
            Tile t = new Tile();

            return t;
        }

    }
}

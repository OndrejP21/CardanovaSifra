using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanovaSifra
{

    struct Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    internal class Cardan
    {
        private char[,] _chars;
        List<Coord> _coords;

        public Cardan(string plainText)
        {
            int column = 10;
            int row = (int)Math.Ceiling((double)(plainText.Length / 2));

            _chars = new char[column, row];
            _coords = new List<Coord>();
            Init();
            Encode(plainText);
        }

        private void Init()
        {
            Random rnd = new Random();

            for (int i = 0; i < _chars.GetLength(0); i++)
            {
                for (int j = 0; j < _chars.GetLength(1); j++)
                {
                    _chars[i, j] = (char)rnd.Next(97, 123);
                }
            }
        }

        private void Encode(string plainText)
        {

            Random rnd = new Random();
            int index = 0;
            for (int i = 0; i < _chars.GetLength(1); i++)
            {


                int a = rnd.Next(0, 5);
                int b = rnd.Next(5, 10);
                _chars[i,a] = plainText[index++];
                _coords.Add(new Coord(i,a));
                if (index == plainText.Length - 1)
                {
                    _chars[i, b] = plainText[index];
                    _coords.Add(new Coord(i,b));
                    break;
                }
                _chars[i, b] = plainText[index++];
                _coords.Add(new Coord(i, b));

            }

        }

        public void Print()
        {
            for (int i = 0; i < _chars.GetLength(0); i++)
            {
                for (int j = 0; j < _chars.GetLength(1); j++)
                {
                    if (_coords.Contains(new Coord(i, j)))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(_chars[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}

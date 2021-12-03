using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardanovaSifra
{

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class CardanLinked
    {
        private string _plainText;
        private char[,] _chars;
        List<Point> _points;
        public CardanLinked(string plainText)
        {
            _plainText = plainText;
            _chars = new char[5, _plainText.Length];
            _points = new List<Point>();
            Fill();
            Encrypt();
        }

        public void Encrypt()
        {
            int index = 0;
            bool down = true;
            for (int i = 0; i < _chars.GetLength(1); i++)
            {
                if (down)
                {
                    _chars[index, i] = _plainText[i];
                    _points.Add(new Point(i, index));
                    index++;

                    if (index == _chars.GetLength(0))
                    {
                        down = false;
                        index -= 2;
                    }
                } else
                {
                    _chars[index, i] = _plainText[i];
                    _points.Add(new Point(i, index));
                    index--;

                    if (index == -1)
                    {
                        down = true;
                        index += 2;
                    }
                }

            }
        }

        public void Fill()
        {
            Random random = new Random();

            for (int i = 0; i < _chars.GetLength(0); i++)
            {
                for (int j = 0; j < _chars.GetLength(1); j++)
                {
                    _chars[i, j] = (char) random.Next(97, 123);
                }
            }
        }

        public void Print()
        {
            
            for (int i = 0; i < _chars.GetLength(0); i++)
            {
                for (int j = 0; j < _chars.GetLength(1); j++)
                {

                    if (IsPointThis(j, i))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }


                    Console.Write(_chars[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private bool IsPointThis(int x, int y)
        {
            foreach (Point point in _points)
            {
                if (point.X == x && point.Y == y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

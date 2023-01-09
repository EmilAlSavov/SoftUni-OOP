using SnakeGame.Core;
using SnakeGame.Models;
using System;
using System.Threading;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Start();
        }
    }
}

using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame.Core
{
    public class Engine
    {
        public void Start()
        {
            OneGame();
        }
        public void OneGame()
        {
            Console.CursorVisible = false;
            Field field = new Field();

            Console.ForegroundColor = ConsoleColor.Yellow;

            field.RenderField();

            Snake snake = new Snake();

            Food food = new Food();

            food.RandomSpawn(field.Width, field.Length, snake.Body);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    snake.ChangeDirection();
                }
                snake.Eat(food, field);

                Thread.Sleep(100);

                snake.OutOfBorder(field);

                snake.Move(field);

                if (snake.Die())
                {
                    break;
                }

            }

            OnDeath(snake, field, food);
        }

        public void OnDeath(Snake snake, Field field, Food food)
        {
            Console.SetCursorPosition(0, field.Length += 3);
            Console.WriteLine("Do you want to play again?");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                food.Despawn();
                snake.Despawn();

                OneGame();
            }
        }
    }
}

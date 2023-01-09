using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Snake
    {
        const int startLength = 3;
        const string startDirection = "right";
        const int startHeadLeft = 15;
        const int startHeadTop = 7;
        const char defSym = '$';

        public Snake()
        {
            this.direction = startDirection;
            this.length = startLength;
            this.headLeft = startHeadLeft;
            this.headTop = startHeadTop;
            this.symbol = defSym;

            this.Body = new List<Point>();

            for (int i = 0; i < this.length; i++)
            {
                Point p = new Point(this.headLeft - i, this.headTop, "snake");
                this.Body.Add(p);
            }
        }

        private string direction;
        private int length;
        private int headLeft;
        private int headTop;
        private char symbol;
        public List<Point> Body { get; set; }

        public void Move(Field field)
        {

            Drawer drawer = new Drawer();
            int lastTop = 0;
            int lastLeft = 0;

            Point head = Body[0];
            if (direction == "left")
            {
                drawer.DrawPoint(head.Left - 1, head.Top, this.symbol);
                lastLeft = head.Left;
                lastTop = head.Top;

                head.Left--;
                headLeft--;
            }
            else if (direction == "right")
            {
                drawer.DrawPoint(head.Left + 1, head.Top, this.symbol);
                lastLeft = head.Left;
                lastTop = head.Top;

                head.Left++;
                headLeft++;
            }
            else if (direction == "up")
            {
                drawer.DrawPoint(head.Left, head.Top - 1, this.symbol);
                lastLeft = head.Left;
                lastTop = head.Top;

                head.Top--;
                headTop--;
            }
            else if (direction == "down")
            {
                drawer.DrawPoint(head.Left, head.Top + 1, this.symbol);
                lastLeft = head.Left;
                lastTop = head.Top;

                head.Top++;
                headTop++;
            }

            var counter = 0;
            foreach (var bodyPoint in Body)
            {
                if(counter == 0)
                {
                    counter++;
                    continue;
                }

                var currLastLeft = bodyPoint.Left;
                var currLastTop = bodyPoint.Top;

                bodyPoint.Left = lastLeft;
                bodyPoint.Top = lastTop;

                drawer.DrawPoint(lastLeft, lastTop, this.symbol);

                lastLeft = currLastLeft;
                lastTop = currLastTop;
                counter++;
            }

            if(lastLeft == 0 || lastLeft == field.Width || lastTop == 0 || lastTop == field.Length)
            {
                drawer.DrawPoint(lastLeft, lastTop);
            }
            else
            {
                drawer.DrawPoint(lastLeft, lastTop, ' ');
            }
            
        }

        public void ChangeDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            if(userInput.Key == ConsoleKey.W)
            {  if (this.direction != "down")
                {
                    this.direction = "up";
                }
            } else if(userInput.Key == ConsoleKey.S)
            {
                if (this.direction != "up")
                {
                    this.direction = "down";
                }
            } else if(userInput.Key == ConsoleKey.A)
            {
                if (this.direction != "right")
                {
                    this.direction = "left";
                }
            } else if(userInput.Key == ConsoleKey.D)
            {
                if (this.direction != "left")
                {
                    this.direction = "right";
                }
            }
        }

        public void Eat(Food food, Field field)
        {
            if(this.headTop == food.Top && this.headLeft == food.Left)
            {
                Thread.Sleep(130);

                Grow(direction);
                food.RandomSpawn(field.Width, field.Length, this.Body);
            }
        }

        public bool Die()
        {
            int Bodycounter = 0;
            foreach (var point in this.Body)
            {
                if(Bodycounter == 0)
                {
                    Bodycounter++;
                    continue;
                }

                if(point.Top == headTop && point.Left == headLeft)
                {
                    
                    return true;
                }

                Bodycounter++;

            }

            return false;
        }

        private void Grow(string direction)
        {
            this.length++;

            if(direction == "up")
            {
                Body.Add(new Point(headTop + length, headLeft, "snake"));
            } else if(direction == "down")
            {
                Body.Add(new Point(headTop - length, headLeft, "snake"));
            } else if(direction == "left")
            {
                Body.Add(new Point(headTop, headLeft + length, "snake"));
            } else if(direction == "right")
            {
                Body.Add(new Point(headTop, headLeft - length, "snake"));
            }
        }

        public void OutOfBorder(Field field)
        {
            Point head = Body[0];
            Drawer drawer = new Drawer();
            if (this.direction == "left")
            {
                if(headLeft <= 1)
                {
                    head.Left = field.Width;
                    headLeft = head.Left;

                    drawer.DrawPoint(1, head.Top, ' ');
                }

            } else if(this.direction == "right")
            {
                if (headLeft >= field.Width -1)
                {
                    head.Left = 0;
                    headLeft = head.Left;

                    drawer.DrawPoint(field.Width - 1, head.Top, ' ');
                }
            } else if(this.direction == "up")
            {
                if(headTop <= 1)
                {
                    head.Top = field.Length;
                    headTop = head.Top;

                    drawer.DrawPoint(head.Left, 1, ' ');
                }
            } else if(this.direction == "down")
            {
                if (headTop >= field.Length -1)
                {
                    head.Top = 0;
                    headTop = head.Top;

                    drawer.DrawPoint(head.Left, field.Length - 1, ' ');
                }
            }
        }

        public void Despawn()
        {
            Drawer drawer = new Drawer();
            this.Body.ForEach(p => drawer.DrawPoint(p.Left, p.Top, ' '));
        }
    }
}

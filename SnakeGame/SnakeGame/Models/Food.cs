using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Food
    {
        const char DefSym = 'O';

        public Food()
        {
            this.symbol = DefSym;
        }
        public int Top { get; set; }

        public int Left { get; set; }

        private char symbol;
        public void RandomSpawn(int num1, int num2, List<Point> snakeBody)
        {
            Random rnd = new Random();

            this.Left = rnd.Next(1, num1 - 1);
            this.Top = rnd.Next(1, num2 - 1);

            if(snakeBody.Any(p => p.Left == this.Left) && snakeBody.Any(p => p.Top == this.Top)){
                RandomSpawn(num1, num2, snakeBody);
            }
            Drawer drawer = new Drawer();

            drawer.DrawPoint(Left, Top, this.symbol);
        }

        public void Despawn()
        {
            Drawer drawer = new Drawer();

            drawer.DrawPoint(Left, Top, ' ');
        }
    }
}

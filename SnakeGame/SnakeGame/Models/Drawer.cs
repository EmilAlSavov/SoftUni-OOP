using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Drawer
    {
        const char symbol = '\u25A0';

        public void DrawPoint(int leftX, int rightY, char sym = symbol)
        {
            Console.SetCursorPosition(leftX, rightY);
            Console.Write(sym);
        }
        public void DrawField(Field field)
        {

            
            for (int left = 0; left <= field.Width; left++)
            {
                DrawPoint(left, 0);
            }

            for (int left = 0; left <= field.Width; left++)
            {
                DrawPoint(left, field.Length);
            }

            for (int top = 0; top <= field.Length; top++)
            {
                DrawPoint(0, top);
            }

            for (int top = 0; top <= field.Length; top++)
            {
                DrawPoint(field.Width, top);
            }
        }
    }
}

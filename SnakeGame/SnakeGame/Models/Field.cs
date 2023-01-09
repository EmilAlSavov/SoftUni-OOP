using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Field
    {
        const int fieldLength = 15;
        const int fieldWidth = 30;

        public Field()
        {
            this.Length = fieldLength;
            this.Width = fieldWidth;
        }

        public int Length { get; set; }

        public int Width { get; set; }

        public void RenderField()
        {
            Drawer drawer = new Drawer();

            drawer.DrawField(this);
        }
    }
}

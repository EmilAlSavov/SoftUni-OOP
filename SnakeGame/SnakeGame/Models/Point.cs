using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Point
    {
        public Point(int left, int top, string status)
        {
            this.Left = left;
            this.Top = top;
            this.Status = status;
        }
        private int left;
        private int top;

        public int Left{ get => left;
            set
            {
                if (value < 0)
                { value = 1; }
                left = value;
            }
        }

        public int Top { get => top; 
            set
            {
                if(value < 0)
                {
                    value = 1;
                }
                top = value;
             }
        }


        public string Status { get; set; }
    }
}

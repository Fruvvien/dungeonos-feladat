using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class JatekElem
    {
        public int X {  get; set; }
        public int Y { get; set; }


        public JatekElem(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Kirajzol()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine('?');
        }
    }
}

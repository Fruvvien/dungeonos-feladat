using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Fegyver : JatekElem
    {
        public int sebzes {  get; set; }

        public Fegyver(int x, int y ) : base (x , y) 
        {
            this.sebzes = 20;
        }

        public override void Kirajzol(char nev)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(nev);
        }

    }
}

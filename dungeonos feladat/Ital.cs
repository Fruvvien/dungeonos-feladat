using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Ital : JatekElem
    {
        public int EletValtozas {  get; set; }

        public Ital (int x, int y, int eletValtozas) : base(x, y)
        {
            EletValtozas = eletValtozas;
        }

        public override void Kirajzol()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(EletValtozas > 0 ? '+' : '-');
        }
    }
}

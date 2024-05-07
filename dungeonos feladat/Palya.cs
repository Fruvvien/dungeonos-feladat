using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Palya
    {
        public char[,] Terkep {  get; set; }
        public int Szelesseg { get; set; }
        public int Magassag {  get; set; }

        public Palya(int szelesseg, int magassag)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            Terkep = new char[magassag, szelesseg];
            TerkepGeneralas();
        }

        public void TerkepGeneralas()
        {
            for (int y = 0; y < Magassag; y++)
            {
                for(int x = 0; x < Szelesseg; x++)
                {
                    if(x == 0 || y == 0 || x == Szelesseg-1 || y == Magassag - 1)
                    {
                        Terkep[y, x] = '#';
                    }
                    else
                    {
                        Terkep[y, x] = ' ';
                    }
                }
            }
        }
        
        public void Kirajzol()
        {
            

            for (int y = 0;y < Magassag; y++)
            {
                for(int x = 0; x < Szelesseg; x++)
                {
                    Console.Write(Terkep[x,y]);
                }
                Console.WriteLine();

            }

        }
    }
}

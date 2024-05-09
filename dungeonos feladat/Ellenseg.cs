using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Ellenseg : JatekElem
    {
        public int Elet {  get; set; }
        public Random rdn;
        public Ellenseg(int x , int y): base(x, y) 
        {
            Elet = 50;
            rdn = new Random();
        }

        public override void Kirajzol(char nev)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(nev);
        }

        public void EllensegMozgas(ConsoleKey irany, Palya palya, int szam)
        {   
           
            if(irany == ConsoleKey.UpArrow || irany == ConsoleKey.DownArrow || irany == ConsoleKey.LeftArrow || irany == ConsoleKey.RightArrow)
            {
                switch (szam)
                {
                    case 1:
                        if (Y > 0 && palya.Terkep[Y - 1, X] == ' ')
                        {
                            Y--;
                        }
                        break;
                    case 2:
                        if (Y < palya.Magassag - 1 && palya.Terkep[Y + 1, X] == ' ')
                        {
                            Y++;
                        }
                        break;
                    case 3:
                        if (X > 0 && palya.Terkep[Y, X - 1] == ' ')
                        {
                            X--;
                        }
                        break;
                    case 4:
                        if (X < palya.Szelesseg - 1 && palya.Terkep[Y, X + 1] == ' ')
                        {
                            X++;
                        }
                        break;
                }
            }
        }


    }
}

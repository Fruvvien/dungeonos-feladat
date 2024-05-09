using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Jatekos : JatekElem
    {
        public int Elet {  get; set; }


        public Jatekos(int x, int y): base(x, y)
        {
            Elet = 100; //Alapértelmezett életpontok
        }

        public override void Kirajzol(char nev)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(nev);

        }

        public void Mozgas(ConsoleKey irany, Palya palya)
        {
            switch(irany)
            {
                case ConsoleKey.UpArrow:
                    if(Y > 0 && palya.Terkep[Y-1, X] == ' ')
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(Y < palya.Magassag - 1 && palya.Terkep[Y + 1, X] == ' ')
                    {
                        Y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(X > 0 && palya.Terkep[Y, X - 1]  == ' ')
                    {
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(X < palya.Szelesseg - 1 && palya.Terkep[Y, X + 1] == ' ')
                    {
                        X++;
                    }
                    break;
                default:
                    Console.WriteLine("Csak a nyilak működnek!");
                    break;
            }
        }


    }
}

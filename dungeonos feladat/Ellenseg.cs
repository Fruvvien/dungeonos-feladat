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

        public Ellenseg(int x , int y): base(x, y) 
        {
            Elet = 50;
        }

        public override void Kirajzol()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('E');
        }

        public void EllensegMozgas(ConsoleKey irany, Palya palya)
        {
            switch(irany)
            {
                case ConsoleKey.UpArrow:
                    if(Y > 0 && palya.Terkep[Y+1, X] == ' ')
                    {
                        Y++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(Y < palya.Magassag - 1 && palya.Terkep[Y - 1, X] == ' ')
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(X > 0 && palya.Terkep[Y, X + 1]  == ' ')
                    {
                        X++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(X < palya.Szelesseg - 1 && palya.Terkep[Y, X - 1] == ' ')
                    {
                        X--;
                    }
                    break;
                default:
                    Console.WriteLine("Csak a nyilak működnek!");
                    break;
            }
        }


    }
}

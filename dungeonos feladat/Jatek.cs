using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class Jatek
    {
        public Palya palya;
        public Jatekos jatekos;
        public Ellenseg ellenseg;
        public List<Ital> italok = new List<Ital>();
        public Random rnd = new Random();
        
        public Jatek()
        {
            palya = new Palya(15, 15);
            jatekos = new Jatekos(1, 3);
            ellenseg = new Ellenseg(9, 5);
            ItalokGeneralasa();
        }

        public void ItalokGeneralasa()
        {
            for (int i = 0; i < 5; i++)
            {
                int x = rnd.Next(5, palya.Szelesseg - 1);
                int y = rnd.Next(5, palya.Magassag - 1);
                int eletValtozas = rnd.Next(100) > 50 ? 10 : -10;
                italok.Add(new Ital(x, y, eletValtozas));
            }
        }
        public void Inditas()
        {
            bool fut = true;
            do
            {
                Console.Clear();
                palya.Kirajzol();
                Console.WriteLine($"Játékos aktuális életereje: {jatekos.Elet}\nEllenség aktuális életereje: {ellenseg.Elet}");

                foreach (var ital in italok)
                {
                    ital.Kirajzol();
                }
               
                jatekos.Kirajzol();
                ellenseg.Kirajzol();
                ConsoleKey irany = Console.ReadKey(true).Key;
                jatekos.Mozgas(irany, palya);
                //TODO: ellenség mozgatás
                ellenseg.EllensegMozgas(irany, palya);
                ItalFelvetelAktivalas();

                //TODO: ellenség harc, ha ugyan azon a helyen van
                Harc();
                //TODO: ital felvétel (aktiválás)
                



            }
            while ( fut && jatekos.Elet > 0 && ellenseg.Elet > 0);
            if(jatekos.Elet <= 0) 
            {
                Console.WriteLine("A játék véget ért, a játékos meghalt");
            }
            if(ellenseg.Elet <= 0)
            {
                Console.WriteLine("A játék véget ért, az ellenség meghalt");
            }
        }
        public void Harc()
        {
            int jatekosX = jatekos.X;
            int jatekosY = jatekos.Y;
            int ellensegX = ellenseg.X;
            int ellensegY = ellenseg.Y;
            if (jatekosX == ellensegX && jatekosY == ellensegY)
            {
                jatekos.Elet -= rnd.Next(1, 15);
                ellenseg.Elet -= rnd.Next(1, 15);
                
            }
        }

        public void ItalFelvetelAktivalas()
        {
            foreach (var ital in italok)
            {
                if(ital.X == jatekos.X && ital.Y == jatekos.Y)
                {
                    if(ital.EletValtozas > 0)
                    {
                        jatekos.Elet += 10;
                    }
                    if(ital.EletValtozas < 0)
                    {
                        jatekos.Elet -= 10;
                    }
                    italok.Remove(ital);
                    return;
                }
            }


        }
        
    }
}

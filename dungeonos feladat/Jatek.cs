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
        public Ellenseg ellenseg1;
        public Ellenseg ellenseg2;
        public Ellenseg ellenseg3;
        public Ellenseg ellenseg4;
        public Fegyver fegyver;
        public List<Ital> italok = new List<Ital>();
        public Random rnd = new Random();
        public bool felvette = false;
        public int jatekTerSzelesseg = 25;
        public int jatekTerHosszusag = 25;
        public bool ellenseg1Halott = false;
        public bool ellenseg2Halott = false;
        public bool ellenseg3Halott = false;
        public bool ellenseg4Halott = false;


        public Jatek()
        {
            palya = new Palya(jatekTerSzelesseg, jatekTerHosszusag);
            jatekos = new Jatekos(1, 3);
            ellenseg1 = new Ellenseg(6, 17);
            ellenseg2 = new Ellenseg(5, 13);
            ellenseg3 = new Ellenseg(10, 20);
            ellenseg4 = new Ellenseg(15, 8);

            fegyver = new Fegyver(rnd.Next(1, jatekTerHosszusag-1), rnd.Next(1, jatekTerHosszusag-1));
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
            //TODO: szörnyek droppoljanak
            //TODO: több item a mappon
            //TODO: játék mentése és betöltése
            //TODO: map felfedezése

            bool fut = true;
          
            do
            {
                Console.Clear();
                palya.Kirajzol();
                Console.WriteLine($"Játékos aktuális életereje: {jatekos.Elet}");
                Console.WriteLine($"Ellenség 1 aktuális életereje: {ellenseg1.Elet}");
                Console.WriteLine($"Ellenség 2 aktuális életereje: {ellenseg2.Elet}");
                Console.WriteLine($"Ellenség 3 aktuális életereje: {ellenseg3.Elet}");
                Console.WriteLine($"Ellenség 4 aktuális életereje: {ellenseg4.Elet}");

                foreach (var ital in italok)
                {
                    ital.Kirajzol(' ');
                }
               
                jatekos.Kirajzol('P');
                if (!ellenseg1Halott)
                {
                    ellenseg1.Kirajzol('1');
                }
                if (!ellenseg2Halott)
                {
                    ellenseg2.Kirajzol('2');
                }
                if (!ellenseg3Halott)
                {
                    ellenseg3.Kirajzol('3');
                }
                if (!ellenseg4Halott)
                {
                    ellenseg4.Kirajzol('4');
                }
                
                if(jatekos.X == fegyver.X && jatekos.Y == fegyver.Y)
                {
                    felvette = true;
                }
                if (!felvette)
                {
                    fegyver.Kirajzol('|');
                }
                ConsoleKey irany = Console.ReadKey(true).Key;
                jatekos.Mozgas(irany, palya);
                
                ellenseg1.EllensegMozgas(irany, palya, rnd.Next(1, 5));
                ellenseg2.EllensegMozgas(irany, palya, rnd.Next(1, 5));
                ellenseg3.EllensegMozgas(irany, palya, rnd.Next(1, 5));
                ellenseg4.EllensegMozgas(irany, palya, rnd.Next(1, 5));
                ItalFelvetelAktivalas();
                Harc();



                if (ellenseg1.Elet <= 0)
                {
                    ellenseg1Halott = true;
                }
                if (ellenseg2.Elet <= 0)
                {
                    ellenseg2Halott = true;
                }
                if (ellenseg3.Elet <= 0)
                {
                    ellenseg3Halott = true;
                }
                if (ellenseg4.Elet <= 0)
                {
                    ellenseg4Halott = true;
                }

            }
            while ( fut && jatekos.Elet > 0 && ellenseg1.Elet > 0 || fut && jatekos.Elet > 0 && ellenseg2.Elet > 0 || fut && jatekos.Elet > 0 && ellenseg3.Elet > 0 || fut && jatekos.Elet > 0 && ellenseg4.Elet > 0);
            if(jatekos.Elet <= 0) 
            {
                Console.WriteLine("A játék véget ért, a játékos meghalt");
            }
            if(ellenseg1.Elet <= 0 && ellenseg2.Elet <= 0 && ellenseg3.Elet <= 0 && ellenseg4.Elet <= 0)
            {
                Console.WriteLine("A játék véget ért, az ellenségek meghaltak");
            }

           


        }
        public void Harc()
        {
        
            if (jatekos.X == ellenseg1.X && jatekos.Y == ellenseg1.Y)
            {
                if(felvette == true)
                {
                    ellenseg1.Elet -= fegyver.sebzes;
                }
                else
                {
                    ellenseg1.Elet -= rnd.Next(1, 15);
                }
                jatekos.Elet -= 5;
               
                
            }
            if (jatekos.X == ellenseg2.X && jatekos.Y == ellenseg2.Y)
            {
                if (felvette == true)
                {
                    ellenseg2.Elet -= fegyver.sebzes;
                }
                else
                {
                    ellenseg2.Elet -= rnd.Next(1, 15);
                }
                jatekos.Elet -= 10;


            }
            if (jatekos.X == ellenseg3.X && jatekos.Y == ellenseg3.Y)
            {
                if (felvette == true)
                {
                    ellenseg3.Elet -= fegyver.sebzes;
                }
                else
                {
                    ellenseg3.Elet -= rnd.Next(1, 15);
                }
                jatekos.Elet -= 15;


            }
            if (jatekos.X == ellenseg4.X && jatekos.Y == ellenseg4.Y)
            {
                if (felvette == true)
                {
                    ellenseg4.Elet -= fegyver.sebzes;
                }
                else
                {
                    ellenseg4.Elet -= rnd.Next(1, 15);
                }
                jatekos.Elet -= 20;


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

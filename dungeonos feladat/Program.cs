using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace dungeonos_feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatek jatek = new Jatek();
            jatek.Inditas();
            Console.WriteLine();

            string filepath = "saveGameFile.txt";
            GameSaveLoad.SaveGameState(jatek, filepath);

            GameSaveLoad.LoadGameState(filepath);
           

            Console.ReadLine();

            
        }

        
    }
}

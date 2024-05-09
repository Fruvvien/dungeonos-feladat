using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace dungeonos_feladat
{
    internal class GameSaveLoad
    {
        public static void SaveGameState(Jatek jatek, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, jatek);

                }
                Console.WriteLine("Játékállapot Sikeresen mentve.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt mentés közben: {ex.Message}");
            }

        }
        public static Jatek LoadGameState(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (Jatek)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
               Console.WriteLine("A mentett játékállapot fájl nem található.");
                return null;
            }
        }
    }
}

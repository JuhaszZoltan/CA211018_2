using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211018_2
{
    class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static void Main()
        {
            
            using (var sr = new StreamReader(@"..\..\res\ub2017egyeni.txt", Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }
            Console.WriteLine($"3. feladat: Egyéni indulók: {versenyzok.Count} fő");
            var cens = versenyzok.Count(x => !x.Kategoria && x.Szazalek == 100);
            Console.WriteLine($"4. feladat: Célba érkező női sportolók: {cens} fő");
            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            var nev = Console.ReadLine();
            var keresett = versenyzok.Where(x => x.Nev == nev).FirstOrDefault();
            Console.WriteLine($"\tIndult egyéniben a sportoló? {(keresett != null ? "Igen" : "Nem")}");
            Console.WriteLine($"\tTeljesítette a teljes távot? {(keresett != null && keresett.Szazalek == 100? "Igen" : "Nem")}");
            var avg = versenyzok
                .Where(x => x.Kategoria && x.Szazalek == 100)
                .Average(x => x.IdoOraban);
            Console.WriteLine($"7. feladat: Átlagos idő: {avg} óra");
            Console.WriteLine("8. feladat: Verseny győztesei");
            var n = versenyzok
                .Where(x => !x.Kategoria && x.Szazalek == 100)
                .OrderBy(x => x.Eredmeny)
                .First();
            Console.WriteLine($"\tNők: {n.Nev} ({n.RajtSzam}.) - {n.Eredmeny}");
            var d = new DateTime(2000, 05, 15);
            var f = versenyzok
                .Where(x => x.Kategoria && x.Szazalek == 100)
                .OrderBy(x => x.Eredmeny)
                .First();
            Console.WriteLine($"\tFérfiak: {f.Nev} ({f.RajtSzam}.) - {f.Eredmeny}");
            Console.ReadKey(true);
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211018_2
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public int RajtSzam { get; set; }
        public bool Kategoria { get; set; }
        public TimeSpan Eredmeny { get; set; }
        public int Szazalek { get; set; }
        public double IdoOraban => Eredmeny.TotalHours;

        public Versenyzo(string r)
        {
            var t = r.Split(';');
            Nev = t[0];
            RajtSzam = int.Parse(t[1]);
            Kategoria = t[2] == "Ferfi";
            var tst = t[3].Split(':');
            Eredmeny = new TimeSpan(
                hours: int.Parse(tst[0]),
                minutes: int.Parse(tst[1]),
                seconds: int.Parse(tst[2]));
            Szazalek = int.Parse(t[4]);
        }
    }
}

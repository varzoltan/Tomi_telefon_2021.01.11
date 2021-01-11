using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi_telefon_2021._01._11
{
    class Program
    {
        struct Adat
        {
            public int beerkezoora;
            public int beerkezoperc;
            public int beerkezomasodperc;
            public int kimenoora;
            public int kimenoperc;
            public int kimenomasodperc;
        }
        static void Main(string[] args)
        {

        }
        static int mbe(int o,int p,int mp)
        {
            int masodperc = (o * 3600) + (p * 60) + mp;
            return masodperc;
        }
    }
}

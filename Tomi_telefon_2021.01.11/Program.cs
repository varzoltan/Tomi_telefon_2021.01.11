using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            public int elteltido;
        }
        static void Main(string[] args)
        {
            //2.feladat
            Adat[] adatok = new Adat[1000];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\hivas.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string elsosor = olvas.ReadLine();
                string[] db = elsosor.Split();
                adatok[n].beerkezoora = int.Parse(db[0]);
                adatok[n].beerkezoperc = int.Parse(db[1]);
                adatok[n].beerkezomasodperc = int.Parse(db[2]);
                adatok[n].kimenoora = int.Parse(db[3]);
                adatok[n].kimenoperc = int.Parse(db[4]);
                adatok[n].kimenomasodperc = int.Parse(db[5]);
                adatok[n].elteltido = mbe(adatok[n].kimenoora, adatok[n].kimenoperc, adatok[n].kimenomasodperc) - mbe(adatok[n].beerkezoora,adatok[n].beerkezoperc,adatok[n].beerkezomasodperc);
                n++;
            }
            olvas.Close();
            //3    
            int ora;
            int szamol = 0;
            for (ora =0;ora<=23;ora++)
            {
                for (int i = 0;i<n;i++)
                {

                    if (ora == adatok[i].beerkezoora)
                    {
                        szamol++;
                    }
                    
                }
                if (szamol != 0)
                {
                    Console.WriteLine($"{ora} ora {szamol} hivas");
                    //szamol = 0;
                }
                szamol = 0;
            }

            //4.feladat

            int max = 0;
            int sor = 0;
            for (int i =0;i<n;i++)
            {
                if (max<adatok[i].elteltido)
                {
                    max = adatok[i].elteltido;
                    sor = i;
                }
            }
            Console.WriteLine($"A leghosszabb ideig vonalban levo hivo {sor}. sorban szerepel, a hivas hossza: {max} masodperc.");

            //5.feladat

            Console.Write("Adjon meg egy idopontot! {ora perc masodperc} ");
            string idobekert = Console.ReadLine();
            string[] ido = idobekert.Split();
            int idoora = int.Parse(ido[0]);
            int idoperc = int.Parse(ido[1]);
            int idomasodperc = int.Parse(ido[2]);
            int egybeido = mbe(idoora,idoperc,idomasodperc);
            int szamol1 = 0;
            int beszelo = -1;
            for (int i = n-1; i>=0; i--)
            {
                int bejovoido = mbe(adatok[i].beerkezoora, adatok[i].beerkezoperc, adatok[i].beerkezomasodperc);
                int kimenoido = mbe(adatok[i].kimenoora, adatok[i].kimenoperc, adatok[i].kimenomasodperc);
                if (egybeido>= bejovoido && egybeido <= kimenoido)
                {
                    szamol1++;
                    beszelo = i;
                }
            }
            if (beszelo > -1)
            {
                Console.WriteLine($"A várakozók száma: {szamol1 -1} a beszélő a {beszelo + 1}. hívó.");
            }
            else
            {
                Console.WriteLine("Nem volt beszélő.");
            }

            //6.feladat
            int mbefejez = mbe(12, 0, 0);
            int vegso = 0, vegsoelott = 0;
            for (int i = 0; i < n; i++)
            {
                if ((mbe(adatok[i].beerkezoora, adatok[i].beerkezoperc, adatok[i].beerkezomasodperc) < mbefejez) && (mbe(adatok[i].kimenoora, adatok[i].kimenoperc, adatok[i].kimenomasodperc) > mbe(adatok[vegso].beerkezoora, adatok[vegso].beerkezoperc, adatok[vegso].beerkezomasodperc)))
                {
                    vegsoelott = vegso;
                    vegso = i;
                }
            }
            Console.WriteLine($"6. feladat\nAz utolso telefonalo adatai a(z) {vegso+1}. sorban vannak, {mbe(adatok[vegsoelott].kimenoora, adatok[vegsoelott].kimenoperc, adatok[vegsoelott].kimenomasodperc) - mbe(adatok[vegso].beerkezoora, adatok[vegso].beerkezoperc, adatok[vegso].beerkezomasodperc)} masodpercig vart.");
            Console.ReadKey();
          
        }
        static int mbe(int o,int p,int mp)
        {
            int masodperc = (o * 3600) + (p * 60) + mp;
            return masodperc;
        }
    }
}

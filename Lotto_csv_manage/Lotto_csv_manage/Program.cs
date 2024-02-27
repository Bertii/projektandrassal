using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lotto_csv_manage
{
    class lotto
    {
        public string year, date, week, sum5, sum4, sum3, sum2, lsz1, lsz2, lsz3, lsz4, lsz5;
        public int nyertesek_szama_5, nyertesek_szama_4, nyertesek_szama_3, nyertesek_szama_2;

        public lotto(string adat)
        {
            string[] adatok = adat.Split(";");
            this.year = adatok[0];
            this.week = adatok[1];
            this.date = adatok[2];
            this.nyertesek_szama_5 = int.Parse(adatok[3]);
            this.sum5 = adatok[4];
            this.nyertesek_szama_4 = int.Parse(adatok[5]);
            this.sum4 = adatok[6];
            this.nyertesek_szama_3 = int.Parse(adatok[7]);
            this.sum3 = adatok[8];
            this.nyertesek_szama_2 = int.Parse(adatok[9]);
            this.sum2 = adatok[10];
            this.lsz1 = adatok[11];
            this.lsz2 = adatok[12];
            this.lsz3 = adatok[13];
            this.lsz4 = adatok[14];
            this.lsz5 = adatok[15];
        }
    }

    class thre
    {
        public int a, b, c;

        public thre(string adat)
        {
            string[] adatok = adat.Split(";");
            this.a = int.Parse(adatok[0]);
            this.b = int.Parse(adatok[1]);
            this.c = int.Parse(adatok[2]);

        }
    }

    class Program
    {
        static List<lotto> lista = new List<lotto>();
        static List<thre> listaaa = new List<thre>();
        static void Beolvasas()
        {
            StreamReader be = new StreamReader("lotto.csv");
            while (!be.EndOfStream)
                lista.Add(new lotto(be.ReadLine()));
            be.Close();
        }

        static void most_common()
        {
            Dictionary<string, int> gyakorisági_sorrend = new Dictionary<string, int>();
            for (int i = 0; i < lista.Count; i++)
            {

                if (gyakorisági_sorrend.ContainsKey(lista[i].lsz1))
                {
                    gyakorisági_sorrend[lista[i].lsz1]++;
                }
                else
                {
                    gyakorisági_sorrend.Add(lista[i].lsz1, 1);
                }
                if (gyakorisági_sorrend.ContainsKey(lista[i].lsz2))
                {
                    gyakorisági_sorrend[lista[i].lsz2]++;
                }
                else
                {
                    gyakorisági_sorrend.Add(lista[i].lsz2, 1);
                }
                if (gyakorisági_sorrend.ContainsKey(lista[i].lsz3))
                {
                    gyakorisági_sorrend[lista[i].lsz3]++;
                }
                else
                {
                    gyakorisági_sorrend.Add(lista[i].lsz3, 1);
                }
                if (gyakorisági_sorrend.ContainsKey(lista[i].lsz4))
                {
                    gyakorisági_sorrend[lista[i].lsz4]++;
                }
                else
                {
                    gyakorisági_sorrend.Add(lista[i].lsz4, 1);
                }
                if (gyakorisági_sorrend.ContainsKey(lista[i].lsz5))
                {
                    gyakorisági_sorrend[lista[i].lsz5]++;
                }
                else
                {
                    gyakorisági_sorrend.Add(lista[i].lsz5, 1);
                }
            }

            var sorteddict = gyakorisági_sorrend.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            List<int> list = new List<int> {0, 0, 0};

            int a = 1;
            foreach (int value in sorteddict.Values)
            {
                if (a == sorteddict.Count - 2)
                    list[2] = value;
                if (a == sorteddict.Count - 1)
                    list[1] = value;
                if (a == sorteddict.Count)
                    list[0] = value;
                a++;
            }

            foreach (KeyValuePair<string, int> pair in sorteddict)
            {
                if (pair.Value == list[2])
                    Console.WriteLine("#3: {0}-ből {1}-db", pair.Key, pair.Value);

                if (pair.Value == list[1])
                    Console.WriteLine("#2: {0}-ből {1}-db", pair.Key, pair.Value);

                if (pair.Value == list[0])
                    Console.WriteLine("#1: {0}-ből {1}-db", pair.Key, pair.Value);
            }
        }

        static void three()
        {
            
            for (int i = 0; i < lista.Count; i++)
            {
                for (int x = i + 1; x < lista.Count; x++)
                {
                    int a = 0;
                    if (lista[i].lsz1 == lista[x].lsz1)
                        a++;
                    if (lista[i].lsz1 == lista[x].lsz2)
                        a++;
                    if (lista[i].lsz1 == lista[x].lsz3)
                        a++;
                    if (lista[i].lsz1 == lista[x].lsz4)
                        a++;
                    if (lista[i].lsz1 == lista[x].lsz5)
                        a++;

                    if (lista[i].lsz2 == lista[x].lsz1)
                        a++;
                    if (lista[i].lsz2 == lista[x].lsz2)
                        a++;
                    if (lista[i].lsz2 == lista[x].lsz3)
                        a++;
                    if (lista[i].lsz2 == lista[x].lsz4)
                        a++;
                    if (lista[i].lsz2 == lista[x].lsz5)
                        a++;

                    if (lista[i].lsz3 == lista[x].lsz1)
                        a++;
                    if (lista[i].lsz3 == lista[x].lsz2)
                        a++;
                    if (lista[i].lsz3 == lista[x].lsz3)
                        a++;
                    if (lista[i].lsz3 == lista[x].lsz4)
                        a++;
                    if (lista[i].lsz3 == lista[x].lsz5)
                        a++;

                    if (lista[i].lsz4 == lista[x].lsz1)
                        a++;
                    if (lista[i].lsz4 == lista[x].lsz2)
                        a++;
                    if (lista[i].lsz4 == lista[x].lsz3)
                        a++;
                    if (lista[i].lsz4 == lista[x].lsz4)
                        a++;
                    if (lista[i].lsz4 == lista[x].lsz5)
                        a++;

                    if (lista[i].lsz5 == lista[x].lsz1)
                        a++;
                    if (lista[i].lsz5 == lista[x].lsz2)
                        a++;
                    if (lista[i].lsz5 == lista[x].lsz3)
                        a++;
                    if (lista[i].lsz5 == lista[x].lsz4)
                        a++;
                    if (lista[i].lsz5 == lista[x].lsz5)
                        a++;

                    string b = i + ";" + x + ";" + a;
                    listaaa.Add(new thre(b));
                }
            }

            int m = 0;
            for (int i = 0; i < listaaa.Count; i++)
            {
                if (listaaa[i].c > m)
                    m = listaaa[i].c;
            }

            Console.WriteLine("Leghasonlóbb számsorok: \ndate: {0}\tszámsor: {1} {2} {3} {4} {5}\ndate2: {6}\tszámsor: {7} {8} {9} {10} {11}", lista[listaaa[1172409].a].date, lista[listaaa[1172409].a].lsz1, lista[listaaa[1172409].a].lsz2, lista[listaaa[1172409].a].lsz3, lista[listaaa[1172409].a].lsz4, lista[listaaa[1172409].a].lsz5, lista[listaaa[1172409].b].date, lista[listaaa[1172409].b].lsz1, lista[listaaa[1172409].b].lsz2, lista[listaaa[1172409].b].lsz3, lista[listaaa[1172409].b].lsz4, lista[listaaa[1172409].b].lsz5);
        }
        static void Main(string[] args)
        {
            Beolvasas();
            Console.WriteLine("Előző heti sorsolás számai: {0}, {1}, {2}, {3}, {4}", lista[0].lsz1, lista[0].lsz2, lista[0].lsz3, lista[0].lsz4, lista[0].lsz5);
            most_common();
            three();
            Console.ReadKey();
        }
    }
}

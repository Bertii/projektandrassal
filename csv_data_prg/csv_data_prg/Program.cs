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
            List<int> list = new List<int> { 0, 0, 0 };

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

            Console.WriteLine("Leghasonlóbb számsorok: \ndate: {0}\tszámsor: {1} {2} {3} {4} {5}\ndate 2: {6}\tszámsor: {7} {8} {9} {10} {11}", lista[listaaa[1172409].a].date, lista[listaaa[1172409].a].lsz1, lista[listaaa[1172409].a].lsz2, lista[listaaa[1172409].a].lsz3, lista[listaaa[1172409].a].lsz4, lista[listaaa[1172409].a].lsz5, lista[listaaa[1172409].b].date, lista[listaaa[1172409].b].lsz1, lista[listaaa[1172409].b].lsz2, lista[listaaa[1172409].b].lsz3, lista[listaaa[1172409].b].lsz4, lista[listaaa[1172409].b].lsz5);
        }

        static void leghosszab_szamsorozatok()
        {
            Dictionary<string, int> huzasok_sorozat = new Dictionary<string, int>();
            for (int i = 0; i < lista.Count; i++)
            {
                int a = 0;
                int b = 0;
                int c = 0;
                int d = 0;
                if (int.Parse(lista[i].lsz1) + 1 == int.Parse(lista[i].lsz2))
                {
                    a++;
                    if (int.Parse(lista[i].lsz2) + 1 == int.Parse(lista[i].lsz3))
                    {
                        a++;
                        if (int.Parse(lista[i].lsz3) + 1 == int.Parse(lista[i].lsz4))
                        {
                            a++;
                            if (int.Parse(lista[i].lsz4) + 1 == int.Parse(lista[i].lsz5))
                                a++;
                        }
                    }
                }
                else
                {
                    if (int.Parse(lista[i].lsz2) + 1 == int.Parse(lista[i].lsz3))
                    {
                        b++;
                        if (int.Parse(lista[i].lsz3) + 1 == int.Parse(lista[i].lsz4))
                        {
                            b++;
                            if (int.Parse(lista[i].lsz4) + 1 == int.Parse(lista[i].lsz5))
                                b++;
                        }
                    }

                    else
                    {
                        if (int.Parse(lista[i].lsz3) + 1 == int.Parse(lista[i].lsz4))
                        {
                            c++;
                            if (int.Parse(lista[i].lsz4) + 1 == int.Parse(lista[i].lsz5))
                                c++;
                        }

                        else
                        {
                            if (int.Parse(lista[i].lsz4) + 1 == int.Parse(lista[i].lsz5))
                                d++;
                        }

                    }
                }
                if (a > b && a > c && a > d)
                    huzasok_sorozat.Add(lista[i].year + " " + lista[i].week, a + 1);
                if (b > a && b > c && b > d)
                    huzasok_sorozat.Add(lista[i].year + " " + lista[i].week, b + 1);
                if (c > a && c > b && c > d)
                    huzasok_sorozat.Add(lista[i].year + " " + lista[i].week, c + 1);
                if (d > a && d > b && d > c)
                    huzasok_sorozat.Add(lista[i].year + " " + lista[i].week, d + 1);
            }

            int v = 0;
            string[] n = new String[3];
            int t = 0;
            foreach (KeyValuePair<string, int> a in huzasok_sorozat)
            {
                if (a.Value > v)
                    v = a.Value;
            }

            foreach (KeyValuePair<string, int> a in huzasok_sorozat)
            {
                if (a.Value == v)
                {
                    Console.WriteLine("Leghosszab számsorozat: {0}, {1} egymást követő elem", a.Key, a.Value);
                    n[t] = a.Key;
                    t++;
                    if (t == 3)
                        break;
                }
            }
            for (int i = 0; i < lista.Count; i++)
            {
                for (int y = 0; y < t; y++)
                {
                    if (lista[i].year + " " + lista[i].week == n[y])
                        Console.WriteLine("Számok: {0}, {1}, {2}, {3}, {4}", lista[i].lsz1, lista[i].lsz2, lista[i].lsz3, lista[i].lsz4, lista[i].lsz5);
                }
            }
        }

        static void legkissebb_sum_számsorok()
        {
            Console.WriteLine("Legkissebb összegű számsorok: ");
            Dictionary<string, int> huzas_summ = new Dictionary<string, int>();

            for (int i = 0; i < lista.Count; i++)
            {
                int a = int.Parse(lista[i].lsz1) + int.Parse(lista[i].lsz2) + int.Parse(lista[i].lsz3) + int.Parse(lista[i].lsz4) + int.Parse(lista[i].lsz5);
                huzas_summ.Add(lista[i].year + " " + lista[i].week, a);
            }

            int[] max_nums = new int[3] { 300, 300, 300 };
            foreach (KeyValuePair<string, int> a in huzas_summ)
            {
                if (a.Value < max_nums[2])
                {
                    if (a.Value < max_nums[1])
                    {
                        if (a.Value < max_nums[0])
                        {
                            max_nums[2] = max_nums[1];
                            max_nums[1] = max_nums[0];
                            max_nums[0] = a.Value;
                        }
                        else
                        {
                            max_nums[2] = max_nums[1];
                            max_nums[1] = a.Value;
                        }
                    }
                    else
                    {
                        max_nums[2] = a.Value;
                    }
                }
            }
            for (int i = 0; i < max_nums.Length; i++)
            {
                foreach (KeyValuePair<string, int> a in huzas_summ)
                {
                    if (a.Value == max_nums[i])
                    {
                        Console.WriteLine("{0}, összeg: {1}", a.Key, a.Value);
                        for (int y = 0; y < lista.Count; y++)
                        {
                            if (lista[y].year + " " + lista[y].week == a.Key)
                            {
                                Console.WriteLine("Számsor: {0}, {1}, {2}, {3}, {4}", lista[y].lsz1, lista[y].lsz2, lista[y].lsz3, lista[y].lsz4, lista[y].lsz5);
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Beolvasas();
            Console.WriteLine("Előző heti sorsolás számai: {0}, {1}, {2}, {3}, {4}", lista[0].lsz1, lista[0].lsz2, lista[0].lsz3, lista[0].lsz4, lista[0].lsz5);
            most_common();

            three();
            leghosszab_szamsorozatok();
            legkissebb_sum_számsorok();
            Console.ReadKey();
        }
    }
}

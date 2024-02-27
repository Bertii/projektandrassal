﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Lotto_csv_manage
{
    class lotto
    {
        public string year, date, week, sum5, sum4, sum3, sum2;
        public int nyertesek_szama_5, nyertesek_szama_4, nyertesek_szama_3, nyertesek_szama_2, lsz1, lsz2, lsz3, lsz4, lsz5;
        public List<int> lsz;

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
            this.lsz.Add(int.Parse(adatok[11]));
            this.lsz.Add(int.Parse(adatok[12]));
            this.lsz.Add(int.Parse(adatok[13]));
            this.lsz.Add(int.Parse(adatok[14]));
            this.lsz.Add(int.Parse(adatok[15]));
        }
    }

    class summ
    {
        public int lsz, sum;
        public summ(string adat)
        {
            string[] adatok = adat.Split(";");
            this.lsz = int.Parse(adatok[0]);
            this.sum = int.Parse(adatok[1]);
        }
    }
    class Program
    {
        static List<lotto> lista = new List<lotto>();
        static List<summ> list = new List<summ>();
        static void Beolvasas()
        {
            StreamReader be = new StreamReader("lotto.csv");
            while (!be.EndOfStream)
                lista.Add(new lotto(be.ReadLine()));
            be.Close();
        }

        static void most_common()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    bool a = false;
                    for (int y = 0; y < list.Count; y++)
                    {
                        if (lista[i].lsz[x] == list[y].lsz)
                            a = true;

                        string b = "";
                        if (a)
                            list.Add(new summ(b));

                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Beolvasas();
            int a = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (int.Parse(lista[i].week) > int.Parse(lista[a].week))
                    a = i;
            }
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", lista[a].lsz1, lista[a].lsz2, lista[a].lsz3, lista[a].lsz4, lista[a].lsz5);
            most_common();
            Console.ReadKey();
        }
    }
}

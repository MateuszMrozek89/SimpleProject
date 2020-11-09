using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wisielec
{
    class Program
    {
        static string PelneHaslo;
        static char[] WidoczneHaslo;
        static string Dziedzina;
        static int Szanse = 5;
        static void PrzygotujRozgrywke()
        {
            List<string> tabHaslo = new List<string>();
            List<string> tabDziedzina = new List<string>();
            StreamReader sr = new StreamReader("wisielec.txt");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] slowa = s.Split('\t');
                tabHaslo.Add(slowa[0]);
                tabDziedzina.Add(slowa[1]);
            }
            sr.Close();

                Random r = new Random();
            int x = r.Next(tabHaslo.Count);
            PelneHaslo = tabHaslo[x];
            Dziedzina = tabDziedzina[x];
            WidoczneHaslo = PelneHaslo.ToCharArray();
            
            for (int i = 0; i < WidoczneHaslo.Length; i++)
            {
                if (char.IsLetter(WidoczneHaslo[i]))
                    WidoczneHaslo[i] = '_';
            }
        }
        static void RysujHaslo()
        {
            Console.Clear();
            Console.WriteLine("Próby: {0} \t\t\t\tDziedzina: {1}", Szanse, Dziedzina);
            Console.WriteLine();
            for (int i = 0; i < WidoczneHaslo.Length; i++)
                Console.Write(WidoczneHaslo[i]+" ");

            Console.WriteLine();
            Console.WriteLine("Jaką literę chcesz wprowadzić: ");
        }
        static void AktualizujHaslo(char znak)
        {
            bool jest = false;
            for (int i = 0; i < PelneHaslo.Length; i++)
            {
                if (PelneHaslo[i] == znak)
                {
                    WidoczneHaslo[i] = znak;
                    jest = true;
                }
            }
            if (!jest) Szanse--;
        }
       static bool SprawdzKoniec()
        {
            if (!WidoczneHaslo.Contains('_'))
            {
                RysujHaslo();
                Console.WriteLine("");
                Console.WriteLine("Gratulacje Wygrałeś !!! :-) ");
                return true;
            }
            if(Szanse<0)
            {
                Console.WriteLine("Przegrana");
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w grze wisielec 1.0 !!! :-) ");
            PrzygotujRozgrywke();
            while(true)
            {
                RysujHaslo();
                char znak = char.Parse(Console.ReadLine());
                AktualizujHaslo(znak);
                
                if (SprawdzKoniec())
                {
                    break;
                }
            }
            Console.ReadKey();          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma

{
    class Program
    {
        static void Main(string[] args)
        {
            string twojTekst;
            string zaszyfrowanyTekst;
            string deszyfrowanyTekst;
            char[] tekst;
            char[] zaszyfrowany;
            char[] deszyfrowany;

            char[] alfabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

            Console.WriteLine("Witaj w programie szyfrującym");
            Console.WriteLine();

            Console.WriteLine("Podaj pierwszą liczbę klucza: ");
            int z1 = int.Parse(Console.ReadLine());
            Random r1 = new Random(z1);

            Console.WriteLine("Podaj drugą liczbę klucza: ");
            int z2 = int.Parse(Console.ReadLine());
            Random r2 = new Random(z2);

            Console.WriteLine("Podaj trzecią liczbę klucza: ");
            int z3 = int.Parse(Console.ReadLine());
            Random r3 = new Random(z3);

            Console.WriteLine("Podaj czwartą liczbę klucza: ");
            int z4 = int.Parse(Console.ReadLine());
            Random r4 = new Random(z4);

            Console.WriteLine("Podaj piątą liczbę klucza: ");
            int z5 = int.Parse(Console.ReadLine());
            Random r5 = new Random(z5);

            Console.WriteLine();

            Console.WriteLine("Co chcesz zrobić z wprowadzonym tekstem ?\n[0] Szyfrowanie, [1] Deszyfrowanie: ");

            int wybor = int.Parse(Console.ReadLine());

            switch (wybor)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Podaj tekst do zaszyfrowania: ");

                    twojTekst = Console.ReadLine();
                    tekst = twojTekst.ToCharArray();
                    zaszyfrowany = new char[tekst.Length];

                    for (int i = 0; i < tekst.Length; i++)
                    {
                        for (int j = 0; j < alfabet.Length; j++)
                        {
                            if (tekst[i] == alfabet[j])
                            {
                                int x1 = r1.Next();
                                int x2 = r2.Next();
                                int x3 = r3.Next();
                                int x4 = r4.Next();
                                int x5 = r5.Next();
                                int klucz = Math.Abs(x1 + x2 + x3 + x4 + x5) % alfabet.Length;
                                zaszyfrowany[i] = alfabet[(j + klucz) % alfabet.Length];
                                break;
                            }
                            else
                            {
                                zaszyfrowany[i] = tekst[i];
                            }
                        }
                    }

                    zaszyfrowanyTekst = new string(zaszyfrowany);
                    
                    Console.WriteLine();
                    Console.WriteLine("Zaszyfrowany tekst: {0}", zaszyfrowanyTekst);
                    break;

                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Podaj tekst do odszyfrowania: ");

                    zaszyfrowanyTekst = Console.ReadLine();
                    zaszyfrowany = zaszyfrowanyTekst.ToCharArray();
                    deszyfrowany = new char[zaszyfrowany.Length];

                    for (int i = 0; i < zaszyfrowany.Length; i++)
                    {
                        for (int j = 0; j < alfabet.Length; j++)
                        {
                            if (zaszyfrowany[i] == alfabet[j])
                            {
                                int x1 = r1.Next();
                                int x2 = r2.Next();
                                int x3 = r3.Next();
                                int x4 = r4.Next();
                                int x5 = r5.Next();
                                int klucz = Math.Abs(x1 + x2 + x3 + x4 + x5) % alfabet.Length;
                                deszyfrowany[i] = alfabet[(alfabet.Length - klucz + j) % alfabet.Length];
                                break;
                            }
                            else
                            {
                                deszyfrowany[i] = zaszyfrowany[i];
                            }
                        }
                    }

                    deszyfrowanyTekst = new string(deszyfrowany);

                    Console.WriteLine();
                    Console.WriteLine("Odszyfrowany tekst: {0}", deszyfrowanyTekst);

                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Nie znam takiego polecenia.");
                    break;
            }
            Console.ReadKey();
        }
    }
}

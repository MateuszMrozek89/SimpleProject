using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Zdanie_b2_v2
{
    class Program
    {
        enum Kierunek { N, NE, E, SE, S, SW, W, NW }
        static void Main(string[] args)
        {
            bool koniec = false;
            do
            {
                bool zle = false;
                string[] tab = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
                Console.WriteLine("Dostępne kierunki to: N, NE, E, SE, S, SW, W, NW");
                Console.WriteLine("Podaj swój początkowy kierunek: ");
                string k = Console.ReadLine().ToUpper();
                for (int i = 0; i < tab.Length; i++)
                {
                    if (k == tab[i])
                    {                        
                        bool kat = false;
                        Kierunek a = (Kierunek)Enum.Parse(typeof(Kierunek), k);
                        Console.WriteLine("Twój aktualny kierunek to:\n{0,10}", a);                                                                                             
                        do
                        {
                            Console.WriteLine("Teraz podaj o ile stopni chcesz zmienić swój kierunek, pamiętaj by liczba była wielokrotnością liczby 45.");
                            int x = int.Parse(Console.ReadLine());
                            int c = (int)a;
                            int y = c + ((x / 45) % 8);
                            if ((x % 45) == 0)
                            {
                                Console.WriteLine("Twój nowy kierunek to:\n{0,10}", ((Kierunek)y));
                                Console.WriteLine();
                                koniec = true;
                                kat = true;
                            }
                            if ((x % 45) != 0)
                            {
                                Console.WriteLine("Wpisiałeś błędną wartość, spróbuj jeszcze raz");                                                            
                            }
                        } while (kat != true);
                        zle = true;
                    }                    
                }
                if (zle == false)
                {
                    Console.WriteLine("Podałeś błędny kierunek !!!");
                    Console.WriteLine("Podaj jeszcze raz swój aktualny kierunek");
                    Console.WriteLine();
                }
            } while (koniec != true);
            Console.WriteLine("Dziękuję za uwagę :)\n\nAby zamknąć wciśnij dowolny klawisz.\n\nMiłego Dnia!!!");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MyGuestbook
{
    class Program
    {

        static void Main(string[] args)
        {

            //Instansierar klassen GuestbookHandler
            GuestbookHandler guestbook = new();



            //När programmet startas 
            while (true)
            {

                Console.Clear(); Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("++===========Emmas Gästbok===========++");

                Console.WriteLine("\n1. Skriv i gästbok");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("\nX. Avsluta\n");
                Console.WriteLine(" -----------------------");
                Console.WriteLine(" |                     |");
                Console.WriteLine(" |    Emmas gästbok    |");
                Console.WriteLine(" |                     |");
                Console.WriteLine(" -----------------------\n");

                //Sätter i till 0
                int i = 0;
                //Loopar igenom inlägg och skriver ut i konsolen
                foreach (Post p in guestbook.GetPosts())
                {
                    Console.WriteLine("[" + i++ + "] " + p.Name + " - " + p.Content);
                }



                //Läser in användarens val
                int input = (int)Console.ReadKey(true).Key;

                //----------- Switch-sats--------------//
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        Console.CursorVisible = true;

                        //Namn
                        Console.Write("Ange ditt namn: ");
                        var name = Console.ReadLine();
                        if (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Namn måste fyllas i. Klicka på valfri knapp för att starta om");
                            Console.ReadKey();
                            break;
                        }

                        //Instansierar klassen Post
                        Post obj = new();
                        //Kontroll om namn inte är null
                        if (name is not null)
                        {
                            obj.Name = name;
                        }


                        Console.Write("Skriv inlägg: ");
                        var content = Console.ReadLine();
                        if (String.IsNullOrEmpty(content))
                        {
                            Console.WriteLine("Innehåll måste fyllas i");
                            Console.ReadKey();
                        }


                        //Kontroll om att content inte är null
                        if (content is not null)
                        {
                            obj.Content = content;
                        }

                        //Lägger till om varken namn eller innehåll är tomt
                        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(content))
                        { guestbook.AddPost(obj); }

                        break;

                    case '2':
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("Ange nummer att radera: ");
                        var index = Console.ReadLine();
                        if (index is not null)
                        {
                            guestbook.DeletePost(Convert.ToInt32(index));
                        }
                        else
                        {
                            Console.WriteLine("Ett nummer måste väljas");
                        }
                        break;
                    case 88:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }

            }


        }
    }
}
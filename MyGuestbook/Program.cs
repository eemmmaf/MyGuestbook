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
                Console.WriteLine("Emmas Gästbok");

                Console.WriteLine("\n1. Skriv i gästbok");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("\nX. Avsluta");

                //Sätter i till 0
                int i = 0;
                //Loopar igenom inlägg och skriver ut i konsolen
                foreach (Post p in guestbook.getPosts())
                {
                    Console.WriteLine("[" + i++ + "] " + p.Name + " - " + p.Content);

                }


                //----------- Switch-sats--------------//


                //Läser in användarens val
                int input = (int)Console.ReadKey(true).Key;


                switch (input)
                {
                    case '1':
                        Console.CursorVisible = true;

                        //Namn
                        Console.Write("Ange ditt namn: ");
                        var name = Console.ReadLine();
                        //Kontroll om namnet är tomt
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Namn måste fyllas i. Tryck på valfri knapp för att börja om");
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
                        if (string.IsNullOrEmpty(content))
                        {
                            Console.WriteLine("Inlägg måste fyllas i. Tryck på valfri knapp för att börja om");
                        }

                        //Kontroll om att content inte är null
                        if (content is not null)
                        {
                            obj.Content = content;
                        }
                        if (!String.IsNullOrEmpty(name)) guestbook.AddPost(obj);
                        break;
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange nummer att radera: ");
                        var index = Console.ReadLine();
                        guestbook.DeletePost(Convert.ToInt32(index));
                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }

            }


        }
    }
}
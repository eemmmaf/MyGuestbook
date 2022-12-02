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


                        //Tom textsträng för namn
                        string name = "";

                        //While-loop som körs medans name är tomt
                        while (String.IsNullOrEmpty(name))
                        {

                            //Läser in användarens input
                            Console.Write("Ange ditt namn: ");
                            name = Console.ReadLine();

                            //Skriver ut felmeddelande om namn fortfarande är tomt
                            if (String.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Namn måste fyllas i");
                                Console.ReadKey();
                            }

                        }


                        //Instansierar klassen Post
                        Post obj = new();
                        //Kontroll om namn inte är null
                        if (name is not null)
                        {
                            obj.Name = name;
                        }

                        //Tom textsträng för innehåll
                        string content = "";


                        //While-loop som körs medans textsträngen content är tom
                        while (String.IsNullOrEmpty(content))
                        {

                            //Läser in användarens input
                            Console.Write("Skriv inlägg: ");
                            content = Console.ReadLine();


                            //Skriver ut felmeddelande om textsträng fortfarande är tom
                            if (String.IsNullOrEmpty(content))
                            {
                                Console.WriteLine("Innehåll måste fyllas i");
                                Console.ReadKey();
                            }
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
                        Console.CursorVisible = true;
                        Console.Write("Ta bort ett inlägg genom att ange vilket nummer som ska raderas: ");
                        var index = Console.ReadLine();

                        if (String.IsNullOrEmpty(index))
                        {
                            Console.WriteLine("En siffra måste väljas");

                        }
                        if (index is not null)
                        {
                            guestbook.DeletePost(Convert.ToInt32(index));
                        }

                        Console.Clear();
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
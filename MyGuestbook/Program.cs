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
                Console.WriteLine("|++===========Emmas Gästbok===========++|");

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
                        Console.CursorVisible = true;


                        //Tom textsträng för namn
                        string name = "";

                        //While-loop som körs medans name är tomt
                        while (String.IsNullOrEmpty(name))
                        {

                            //Läser in användarens input
                            Console.Write("\nAnge ditt namn: ");
                            name = Console.ReadLine();

                            //Skriver ut felmeddelande om namn fortfarande är tomt
                            if (String.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Namn måste fyllas i. Tryck på valfri knapp för att försöka igen");
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
                                Console.WriteLine("Innehåll måste fyllas i. Tryck på valfri knapp för att försöka igen");
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


                    //Om användaren väljer siffran 2 för att ta bort ett inlägg
                    case '2':
                        Console.CursorVisible = true;
                        //Sätter index till en tom text-sträng
                        string inputIndex = "";

                        //While-loop som körs medans index är tom
                        while (String.IsNullOrEmpty(inputIndex))
                        {

                            //Frågar användaren om input
                            Console.Write("Ta bort ett inlägg genom att ange vilket nummer som ska raderas: ");
                            //Läser in
                            inputIndex = Console.ReadLine();


                            //Kontroll om index fortfarande är tomt
                            if (String.IsNullOrEmpty(inputIndex))
                            {
                                //Skriver ut felmeddelande
                                Console.WriteLine("Siffra måste väljas. Försök igen");
                                Console.ReadKey();
                            }
                        }

                        //Konverterar input från användare till int
                        int index = Convert.ToInt32(inputIndex);
                        //Anropar metoden DeletePost och konverterar input till int
                        guestbook.DeletePost(Convert.ToInt32(inputIndex));
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
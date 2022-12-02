using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

namespace MyGuestbook
{
    public class GuestbookHandler
    {

        //----------------- Fields ---------------//

        //Filens namn
        private string filename =  @"guestbook.json";

        //Lista
        private List<Post> posts = new();



        //-------------- Constructor ----------//
        public GuestbookHandler()
        {
            //Kontroll om filen existerar
            if (File.Exists( @"guestbook.json") == true)
            { // Läser in filen om filen existerar
                string jsonString = File.ReadAllText(filename);
            
                    posts = JsonSerializer.Deserialize<List<Post>>(jsonString);
                
            }
        }


        //------------ Metoder -----------------//

        //Lägga till inlägg
        public Post AddPost(Post post)
        {
            posts.Add(post);
            Store();
            return post;
        }


        //Ta bort inlägg
        public int DeletePost(int index)
        {
            posts.RemoveAt(index);
            Store();
            return index;
        }

        //Returnera alla inlägg
        public List<Post> GetPosts()
        {
            return posts;
        }

        private void Store()
        {
            // Serialiserar och sparar till filen
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }



    }

}

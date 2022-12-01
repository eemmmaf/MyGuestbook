using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

namespace MyGuestbook
{
    public class Post
    {
        //------------- Fields -----------------//

        //Namnet på inläggens ägare
        private string name = "";

        //Inläggets innehåll
        private string content = "";



        //---------- Getters och Setters --------//        
        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public string Content
        {
            set { this.content = value; }
            get { return this.content; }
        }
    }
}
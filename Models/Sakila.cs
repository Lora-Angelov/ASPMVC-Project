using System;
namespace ASPMVC.Models
{
    public class Sakila
    {
        public Sakila()
        {

        }
    }

    public class actor
    {
        public int actor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime last_update { get; set; }
    }

    public class film
    {
        public int film_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime release_year { get; set; }
        public int language_id { get; set; }
        public DateTime last_update { get; set; }
        // add more fields 
    }
}


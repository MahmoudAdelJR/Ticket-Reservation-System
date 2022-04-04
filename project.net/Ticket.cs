using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.net
{
    public class Ticket
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        public Movie movie;


        public Ticket()
        {
            movie = new Movie();
        }
        public override string ToString()
        {
            return $"id = {id}\n date = {date}\n Movie is {movie.Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.net
{
    public class Movie :IMovie
    {
        public Movie() { }
        public Movie(string _name, int _year, string _starts, int _id, string _description, int _tickets, DateTime _date, Genre _genre)
        {
            if (!(_name == null)) { Name = _name; } else Name = "";
            YearReleased = _year;
            Stars = _starts;
            Id = _id;
            if (!(_description == null)) { description = _description; } else description = "";
            tickets = _tickets;
            date = _date;
            genre = _genre;
        }

       
        public string Name { get; set; }
        public int YearReleased { get; set; }
        public string Stars { get; set; }
        public int Id { get; set; }
        public string description { get; set; }
        public Genre genre { get; set; }
        public int tickets { get; set; }
        public DateTime date { get; set; }
        public int getAvailable()
        {
            return 300 - tickets;
        }
        public override string ToString()
        {

            string result = $"{Name} with id --> {Id}\nreleased on : {YearReleased}\nMain stars are :  {Stars}\n{description}\nit is {genre} film \nnumber remaining is {getAvailable()}\nits is scheduled on {date} ";
            return result;
        }
    }

}





    







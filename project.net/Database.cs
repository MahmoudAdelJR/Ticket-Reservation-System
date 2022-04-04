using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace project.net
{
    

   
        static class Database
        {
        static SQLiteConnection con;
        static SQLiteCommand cmd;
        static SQLiteDataReader reader;

        public static void openConnection()
        {
            con = new SQLiteConnection(@"Data Source=E:\pro\Project (1).db;");
            cmd = new SQLiteCommand();
            cmd.Connection = con;
            con.Open();
        }

        public static void closeConnection()
        {
            con.Close();
        }

        public static void readMovie(Movie mov, int id)
        {
            string query = $"select * from movie where id = {id}";
           
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Read();
            mov.Name = reader["name"].ToString();
            mov.Id = int.Parse(reader["id"].ToString());
            mov.YearReleased = int.Parse(reader["year released"].ToString());
            mov.description = reader["description"].ToString();
            mov.tickets = int.Parse(reader["tickets"].ToString());
            mov.Stars = reader["stars"].ToString();
            mov.date = new DateTime(long.Parse(reader["date"].ToString()));
            mov.genre = (Genre)int.Parse(reader["genre"].ToString());
            reader.Close();

        }
        public static List<Movie> readAllMovies()
        {
            string query = "select * from movie ";
            
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            List<Movie> movies = new List<Movie>();
            string name, description, stars;
            int id, year, tickets;
            long ticks;
            Genre genre;
            while (reader.Read())
            {
                name = reader["name"].ToString();
                description = reader["description"].ToString();
                stars = reader["stars"].ToString();
                id = int.Parse(reader["id"].ToString());
                year = int.Parse(reader["year released"].ToString());
                tickets = int.Parse(reader["tickets"].ToString());
                ticks = long.Parse(reader["date"].ToString());
                genre = (Genre)int.Parse(reader["genre"].ToString());
                Movie m = new Movie(name, year, stars, id, description, tickets, new DateTime(ticks), genre);
               movies.Add(m);
            }
            reader.Close();
            return movies;
        }

        public static Ticket  readTicket( int ticketID)
        {
            
            Ticket ticket = new Ticket();
            string query = $"select * from ticket where id ={ticketID}";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Read();
            int movieID = int.Parse(reader["movie"].ToString());
            ticket.id = int.Parse(reader["id"].ToString());
            ticket.date = new DateTime(long.Parse(reader["date"].ToString()));
            Movie M = new Movie();
            ticket.movie = M;
            reader.Close();
            Database.readMovie(M, movieID);

            return ticket;
        }
        public static string listMoviesWithIDs()
        {
            string query = $"select id,name from movie";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            StringBuilder SB = new StringBuilder();
            SB.Append("ID --> Name\n");
            while (reader.Read())
            {
                SB.Append(reader["id"] + " --> " + reader["name"] + "\n");
            }
            reader.Close();
            return SB.ToString();
        }
        public static int getLastID()
        {

            string query = $"select max(id) as last from ticket";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Read();
            int result = reader.GetInt32("last");
            reader.Close();
            return result;
        }
        public static int insertTicket(Ticket t)
        {
           
            if (!(t.movie.getAvailable() > 0)) return 0;
            string query = $"insert into ticket (date,movie) values ({t.date.Ticks},{t.movie.Id});";
            cmd.CommandText = query;
            try
            {
                int inserted = cmd.ExecuteNonQuery();
                if (inserted > 0)
                {
                    t.id = getLastID();
                    return ((inserted > 0 ) ? 1 : -1);
                }

            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;
        }
        public  static bool  returnTicket(int id)
        {
            int Movie_ID;
            cmd.CommandText = $"select movie from ticket where id = {id}";
            reader = cmd.ExecuteReader();
            reader.Read();
            Movie_ID = int.Parse(reader["movie"].ToString());
            reader.Close();
            string query = $"delete from ticket where id = {id}";
            cmd.CommandText = query;
           int RowEffected= cmd.ExecuteNonQuery();
           
            if (RowEffected > 0) { return true; }
            else return false;

        }
    }
    

}

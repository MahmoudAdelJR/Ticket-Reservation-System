using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;
namespace project.net
{
   public static class Mnue
    {


        public static void startUp()
        {
           string n = "";
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Database.openConnection();
                Console.WriteLine("\t\t\t\t\t1- Display movies Details :");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t2- Check Movies with IDs :");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t3- Book ticket :");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t4- Canecl ticket:");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t5- Exist :");
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t\t\t\t\tChoose your opation :");
                Console.ResetColor();

                n = Console.ReadLine();

                switch (n)
                { 
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        DisplayMovies(Database.readAllMovies());
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(Database.listMoviesWithIDs());
                        break;
                    case "3":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        bookTickt();
                        break;
                    case "4":
                        Console.Clear();
                        ReturnTickt();
                        break;
                    case "5":
                       ExitProgram();
                        Console.ResetColor();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("invalid input please agian");
                        Console.WriteLine("----------------------------agian------------------------");
                        Console.ResetColor();
                        break;
                }
                
            } 
        }

        /*
         * display list of movies from class Movies*
         
         */
        public static void  DisplayMovies(List<Movie> Movies)
        {

          foreach (Movie obj in Movies)
            {
                Console.WriteLine(obj);
                Console.WriteLine() ;
                Console.WriteLine("********************************************************");
                Console.WriteLine();
            }
            
        }

        /*
         * *
          book Tickt 
         
         */
        public static Ticket bookTickt()
        {
            Ticket ticketObject = new Ticket();
            Movie movie = new Movie();
            int numberOfMioveID;
            Console.WriteLine("please enter id form list of movies");
            try {
                
              bool check=  int.TryParse(Console.ReadLine(),out numberOfMioveID);

                
            if (!check)
            {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("you enterd invild number");
                    Console.WriteLine("please try again");
                    bookTickt();
                    return null;
                }
                else
                {
                     Database.readMovie(movie,numberOfMioveID);
                    ticketObject.movie = movie;
                    ticketObject.date = movie.date;
                }
                /*
                 * 
                 * 
                 * **/
                int checkIfFoundTicket = Database.insertTicket(ticketObject);
               if (checkIfFoundTicket == 0 )
                {
                    Console.WriteLine("sorry this movie not found ticket for it");
                }
               else if(checkIfFoundTicket == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    #region Drow
                    Console.WriteLine(@"          
                                  (c).-.(c)    (c).-.(c)    (c).-.(c)    (c).-.(c)  
                                   / ._. \      / ._. \      / ._. \      / ._. \   
                                 __\( H )/__  __\( I )/__  __\( K )/__  __\( M )/__ 
                                (_.-/'-'\-._)(_.-/'-'\-._)(_.-/'-'\-._)(_.-/'-'\-._)
                                   || M ||      || K ||      || I ||      || H ||   
                                 _.' `-' '._  _.' `-' '._  _.' `-' '._  _.' `-' '._ 
                                (.-./`-'\.-.)(.-./`-'\.-.)(.-./`-'\.-.)(.-./`-'\.-.)
                                 `-'     `-'  `-'     `-'  `-'     `-'  `-'     `-' ");
                    #endregion
                    Console.WriteLine($"\t\t\t\tThank you the Booking succesfully : your tickt id : {ticketObject.id}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Oop.....! {ex.Message}");
                Console.ResetColor();

            }

            return ticketObject;
        }
        /*
         * return tickt if user retrive it after booking*
         
         */
        public static void ReturnTickt()
        {
            try
            {
                Console.WriteLine("please enter ticket that you booked it ");
                int numberOfTicktID ;
                bool check = int.TryParse(Console.ReadLine(), out numberOfTicktID);
                if (!check)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("you enterd invild number");
                    Console.ResetColor();
                    Console.WriteLine("please try again");
                    ReturnTickt();
                    return;
                }
                
                Ticket ticket = Database.readTicket(numberOfTicktID);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Iformtion your Tickt that you want return");
                Console.WriteLine($"tickt iD : {ticket.id}  Date tickt : {ticket.date}   name Movie :{ticket.movie.Name}  stars of Movie  :{ticket.movie.Stars}");
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Do you want to confirme Return (YES | NO )(Y | N )"); string st = Console.ReadLine();
                Console.ResetColor();
                if (st.ToUpper() == "YES" || st.ToUpper() == "Y")
                {
                    if (Database.returnTicket(numberOfTicktID))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("the Booking Return  succesfully  ");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("you enterd invaild Id please try again");
                        Console.ResetColor();

                        ReturnTickt();
                    }
                }
                else
                {
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Oop.....! {ex.Message}");
                Console.ResetColor();
            }
        }
        /*
         * exit Program
         * **/
        public static void ExitProgram()
        {
            Environment.Exit(0);

        }

    }
}

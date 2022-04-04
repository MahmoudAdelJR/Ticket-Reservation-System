using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.net
{
    interface IMovie
    {

        string Name { get; set; }
        int YearReleased { get; set; }
        string Stars { get; set; }
        int Id { get; set; }
        string description { get; set; }
        Genre genre { get; set; }
        int tickets { get; set; }
        DateTime date { get; set; }
    }
}

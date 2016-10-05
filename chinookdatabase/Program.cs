using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicEntityFrameworkDataAccess.Models;
using System.Data.Entity;

namespace chinookdatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<ChinookContext>(null);

            ChinookContext dbContext = new ChinookContext();
            //var artistSearch = "Accept";
            var artists = dbContext.Artist.Where(a => a.ArtistId==2);
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);
            }
            Console.ReadKey();
        }
    }
}

# LINQ / Entity Framework Exercises

###Learning Exercise
*Download and run the 101 LINQ examples from https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/view/SamplePack#content
*Look at the queries for "LINQ Query Examples" and "Link to SQL Query Examples". 

### Coding Exercise:
## Installing a local version of the Chinook Database
* We will be coding against the Chinook database.
* A sql script for installing can be downloaded from here. https://chinookdatabase.codeplex.com/
* Once you have downloaded the zip file. You will see several scripts.
* Open the one called "Chinook_SqlServer.sql"
* Open the file in a text editor. 
* Select and copy all of the text in the file.
* In Visual Studio open the "Sql Server Object Explorer Window"
* Right click on your server icon. It should be the same name as your computer.
* Choose "New Query"
* Paste the contents of "Chinook_SqlServer.sql" into the query window.
* Click the green arrow to the left of the window to run the sql.
* Once the code has executed successfully, refresh your server in the "Sql Server Object Explorer Window"
* You should now see the chinook database. 

Create an app to query the Chinook Database and practice various linq queries. 
* Create a console app.
* Go to "Tools/Nuget Package Manager and add "Entity Framework".
* Open your "App.config" file. You will need to add a connection string to your database. The easiest way to get the connection string is to right click on your chinook database in "Sql Server Object Explorer", you will need to add the following "connectionStrings" section to your app config file. You will need to modify the connection to match your local chinook database. 
 ```
 <connectionStrings>
    <add name="ChinookContext" connectionString="Data Source=alienware-pc\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"  providerName="System.Data.SqlClient" />
  </connectionStrings>
 ```
* Add a folder to your project and call it "Models".
* Add a class and call it "Artist", it will have properties that model your database table called "Artist"
```
namespace BasicEntityFrameworkDataAccess.Models
{
   public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}

```
* Add a class to the models folder called "Genre"
```
namespace BasicEntityFrameworkDataAccess.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
```

* Add a class and call it "ChinookContext"
* Add the following code:
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BasicEntityFrameworkDataAccess.Models
{
    public class ChinookContext: DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(c => c.ArtistId);


            modelBuilder.Entity<Genre>()
                .ToTable("Genre")
                .HasKey(c => c.GenreId);
        }


    }
}
```
* In program.cs instanciate an instance of the "ChinookContext" class. 
* Your code will look something like this:
```

        static void Main(string[] args)
        {
            Database.SetInitializer<ChinookContext>(null);

            ChinookContext dbContext = new ChinookContext();
            var artistSearch = "Sabbath";
            var artists = dbContext.Artist.Where(a => a.Name.Contains(artistSearch));
```
###Now you need to write linq queries that answer the following questions:
 * Bring back 100 artists and order by name
 * Is there a genre for TV show?
 * List the artist on a particular album you like(hint, will need to create a new model and set up in Chinook context)
 * List all of the albums by your favorite artist.
 * List the total bill and mailing address for the following customers with an id of (10, 38, 57)
 * Create a class that will hold information regarding concerts you would like to attend. Create a list containing
    your concerts of choice. Set up several properties. Query your favorite concert list.


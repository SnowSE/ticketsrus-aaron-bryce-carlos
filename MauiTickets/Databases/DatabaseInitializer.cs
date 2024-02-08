/*using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTickets.Databases;
public class LocalDB
{

    public static SQLiteConnection InitializeLocalDatabase(SQLiteConnection database, string databaseName, params Type[] tables)
    {
        if (database == null)
        {
            if (!Directory.Exists(BaseDataDirectory)) Directory.CreateDirectory(BaseDataDirectory);

            database = new SQLiteConnection(Path.Combine(BaseDataDirectory, databaseName));
        }

        database.CreateTables(CreateFlags.None, tables);

        return database;
    }

}*/
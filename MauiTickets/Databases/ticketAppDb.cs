
using Microsoft.EntityFrameworkCore;
using SQLite;
using TicketLibrary.Data;

namespace MauiTickets.Databases;

public class ticketAppDb : DbContext
{
    public SQLiteConnection Connection { get; set; }
    public string? baseDataDirectory { get; set; }
    public string databaseName { get; set; }
    Type[] tables { get; set; }
    public ticketAppDb()
    {
        baseDataDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
        "JC", "LocalDataStorage", "Data");

        databaseName = "TicketsAppDb";

        tables = new Type[]{typeof(Event), typeof(Ticket)};

        InitializeLocalDatabase();
    }

    public SQLiteConnection InitializeLocalDatabase()
    {
       
        if (Connection == null)
        {
            if (!Directory.Exists(baseDataDirectory)) Directory.CreateDirectory(baseDataDirectory);

            Connection = new SQLiteConnection(Path.Combine(baseDataDirectory, databaseName));
        }
        foreach (var t in tables)
        {
            Connection.CreateTable(t);            
        }

        return Connection;
    }
}

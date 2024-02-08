using Java.Sql;
using SQLite;

namespace MauiTickets.Data;

[Table("Event")]
public class LocalEvent
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string eventTitle { get; set; }

    public Date dateOfEvent { get; set; }

}

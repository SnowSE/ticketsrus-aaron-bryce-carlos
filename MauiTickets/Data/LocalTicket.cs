using Java.Sql;
using SQLite;
using SQLiteNetExtensions.Attributes;
//using System.ComponentModel.DataAnnotations.Schema;

namespace MauiTickets.Data;

[Table("Ticket")]
public class LocalTicket
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ForeignKey(typeof(LocalEvent))]
    public int eventId { get; set; }

    public string userEmail { get; set; }

    public bool isScaned { get; set; }

}

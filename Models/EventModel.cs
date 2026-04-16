using System.ComponentModel.Design;

namespace events.Models;

public enum Status {Active, Inactive, Deleted }
public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; }= string.Empty;
    public string Img { get; set; }= string.Empty;
    public string Description { get; set; }= string.Empty;
    public string Location { get; set; }= string.Empty;
    public Status Status { get; set; } = Status.Active;
    public DateTime Date { get; set; }
}
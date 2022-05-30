using ToDoList;
using Microsoft.EntityFrameworkCore;

public class ToDo
{
    public int? Id { get; set; }
    public string? Task { get; set; }
    public bool Status { get; set; }
}
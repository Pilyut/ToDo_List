using ToDoList;
using Microsoft.EntityFrameworkCore;

[Keyless]
public class ToDo
{
    public string? Task { get; set; }
    public bool Status { get; set; }
}
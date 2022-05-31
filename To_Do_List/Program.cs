using static System.Console;
using System.Text.Json;
using ToDoList;
using ToDoReadWrite;


ToDoService service = new ToDoService();
service.LoadAsync();

while (true)
{
    int action;
    bool allOk;
    Display();
    WriteLine(" 1 -- Добавить задачу в список \n 2 -- Удалить задачу из списка \n 3 -- Отметить задачу выполненной \n 0 -- Завершить работу");
    do
    {
        Write("\nВыберите действие: ");
        allOk = int.TryParse(Console.ReadLine(), out action);
    }
    while (allOk == false || action > 3);

    switch (action)
    {
        case 0:
            ExitProgramAsync();
            break;
        case 1:
            Add();
            break;
        case 2:
            Remove();
            break;
        case 3:
            IsCompleted();
            break;
    }

}

void Add()
{
    Write("\nВведите задачу: ");
    string? str = ReadLine();
    ToDo newToDo = new ToDo { Task = str, Status = false };
    service.Add(newToDo);
    Clear();
    WriteLine("\nЗадача успешно добавлена!\n");
}

void Remove()
{
    if (service.HasElement())
    {
        int delNum = 0;
        delNum = Checked("\nВыберите задачу которую нужно удалить: ");
        service.Remove(delNum);
        Clear();
        WriteLine("\nЗадача успешно удалена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

void IsCompleted()
{
    if (service.HasElement())
    {
        int taskNum = 0;
        taskNum = Checked("\nВыберите задачу которую нужно отметить: ");
        service.IsCompleted(taskNum);
        Clear();
        WriteLine("\nЗадача отмечена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

void Display()
{
    
    WriteLine("Список задач:\n");
    List<ToDo> list = service.GetAll(); 
    for (var j = 0; j < list.Count; j++)
    {
        if (list[j].Status == false)
        {
            WriteLine($"{j + 1} - {list[j].Task}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine($"{j + 1} - {list[j].Task}, - Выполнено!");
            Console.ResetColor();
        }
    }
    WriteLine();
}

int Checked(string str)
{
    int s;
    bool allOk;
    do
    {
        Write(str);
        allOk = int.TryParse(Console.ReadLine(), out s);
    }
    while (!allOk || !service.CheckCount(s) || s <= 0);
    return s;
}

void ExitProgramAsync()
{
    service.SaveAsync();
    WriteLine("===================\nПрограмма завершена\n===================");
    Environment.Exit(0);
}
using static System.Console;
using System.Text.Json;
using ToDoList;
using ToDoReadWrite;

ToDoService service = new ToDoService();
service.GetAllAsync();

while (true)
{
    int action;
    bool allOk;
    Display();
    WriteLine(" 1 -- Добавить задачу в список \n 2 -- Удалить задачу из списка \n 3 -- Отметить задачу выполненной \n 4 -- Изменить задачу \n 0 -- Завершить работу");
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
            Delete();
            break;
        case 3:
            MarkComtleted();
            break;
        case 4:
            Update();
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

void Delete()
{
    if (service.HasElement())
    {
        int taskNum = 0;
        taskNum = Checked("\nВыберите задачу которую нужно удалить: ");
        service.Delete(taskNum);
        Clear();
        WriteLine("\nЗадача успешно удалена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

void Update()
{

}

void MarkComtleted()
{
    if (service.HasElement())
    {
        int taskNum = 0;
        taskNum = Checked("\nВыберите задачу которую нужно отметить: ");
        service.MarkComtleted(taskNum);
        Clear();
        WriteLine("\nЗадача отмечена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

async void Display()
{
    
    WriteLine("Список задач:\n");
    List<ToDo> list = await service.GetAllAsync();
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
    WriteLine("===================\nПрограмма завершена\n===================");
    Environment.Exit(0);
}


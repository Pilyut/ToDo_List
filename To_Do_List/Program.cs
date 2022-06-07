using static System.Console;
using System.Text.Json;
using ToDoList;
//using ToDoReadWrite;

ToDoService service = new ToDoService();
await service.GetAllAsync();

while (true)
{
    int action;
    bool allOk;
    await Display();
    WriteLine(" 1 -- Добавить задачу в список \n 2 -- Удалить задачу из списка \n 3 -- Отметить задачу выполненной \n 4 -- Изменить задачу \n 0 -- Завершить работу");
    do
    {
        Write("\nВыберите действие: ");
        allOk = int.TryParse(Console.ReadLine(), out action);
    }
    while (allOk == false || action > 4);

    switch (action)
    {
        case 0:
            ExitProgramAsync();
            break;
        case 1:
            await Add();
            break;
        case 2:
            await Delete();
            break;
        case 3:
            await MarkComtleted();
            break;
        case 4:
            await Update();
            break;
    }

}

async Task Add()
{
    Write("\nВведите задачу: ");
    string? str = ReadLine();
    ToDo newToDo = new ToDo { Task = str, Status = false };
    await service.Add(newToDo);
    Clear();
    WriteLine("\nЗадача успешно добавлена!\n");
}

async Task Delete()
{
    if (service.HasElement())
    {
        int taskNum = 0; 
        taskNum = Checked("\nВыберите задачу которую нужно удалить: ");
        await service.Delete(taskNum);
        Clear();
        WriteLine("\nЗадача успешно удалена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

async Task Update()
{
    if (service.HasElement())
    {
        int taskNum = 0;
        taskNum = Checked("\nВыберите задачу которую нужно изменить ");
        Write("\nВведите задачу: ");
        string? str = Console.ReadLine();
        await service.Update(taskNum, str);
        Clear();
        WriteLine("\nЗадача изменена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

async Task MarkComtleted()
{
    if (service.HasElement())
    {
        int taskNum = 0;
        taskNum = Checked("\nВыберите задачу которую нужно отметить: ");
        await service.MarkComtleted(taskNum);
        Clear();
        WriteLine("\nЗадача отмечена!\n");
    }
    else
    {
        Clear();
        return;
    }
}

async Task Display()
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


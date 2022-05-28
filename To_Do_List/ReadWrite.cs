using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ToDoList;

namespace ToDoReadWrite
{
    public class ReadWriteService : IToDoStorage
    {
        string path;
        public ReadWriteService(string path)
        {
            this.path = path;
        }
        public async Task<List<ToDo>> LoadAsync()
        {
            List<ToDo> toDos = new List<ToDo>();
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        ToDo? newToDo = JsonSerializer.Deserialize<ToDo>(line);
                        toDos.Add(newToDo);
                    }
                }
            }
            return toDos;
        }

        public async Task SaveAsync(List<ToDo> list)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                
                foreach (var todo in list)
                {
                    string? json = JsonSerializer.Serialize(todo);
                    await writer.WriteLineAsync(json);
                }
            }
        }
    }
}
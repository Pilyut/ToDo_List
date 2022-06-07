using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public interface IToDoService
    {
        Task Add(ToDo list);
        Task Delete(int taskNum);
        Task Update(int taskNum, string str);
        Task MarkComtleted(int taskNum);
        Task<List<ToDo>> GetAllAsync();
    }
}

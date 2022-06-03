using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public interface IToDoService
    {
        void Add(ToDo list);
        void Delete(int taskNum);
        void Update(int taskNum);
        void MarkComtleted(int taskNum);
        Task<List<ToDo>> GetAllAsync();
    }
}

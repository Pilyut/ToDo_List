using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationContext _database;
        public ToDoService(ApplicationContext database)
        {
            _database = database;
        }
        public async Task Add(ToDo list)
        {
            await _database.Tasks.AddAsync(list);
            await _database.SaveChangesAsync();
        }
        public async Task Delete(int taskId)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new Exception("Delete don't work");
            }
            _database.Tasks.Remove(task);
            await _database.SaveChangesAsync();
        }
        public async Task Update(int taskId, string str)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new Exception("Update don't work");
            }
            task.Task = str;
            task.Status = false;
            _database.Tasks.Update(task);
            await _database.SaveChangesAsync();
        }
        public async Task MarkComplete(int taskId)
        {
            var task = await _database.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new Exception("Mark don't work");
            }
            task.Status = true;
            await _database.SaveChangesAsync();
        }
        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _database.Tasks.ToListAsync();
        }
        public bool HasElement()
        {
            return _database.Tasks.Any();
        }
        public bool CheckCount(int s)
        {
            return _database.Tasks.Count() >= s;
        }
    }
}
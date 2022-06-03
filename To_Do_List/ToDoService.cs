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
        ApplicationContext db = new ApplicationContext();
        public async void Add(ToDo list)
        {
            await db.Tasks.AddAsync(list);
            await db.SaveChangesAsync();
        }
        public async void Delete(int taskNum)
        {
            var number = await db.Tasks.FirstOrDefaultAsync(x => x.Id == taskNum);
            db.Tasks.Remove(number);
            await db.SaveChangesAsync();
        }
        public void Update(int taskNum)
        {

        }
        public async void MarkComtleted(int taskNum)
        {
            var number = await db.Tasks.FindAsync(taskNum);
            number.Status = true;
            await db.SaveChangesAsync();
        }
        public async Task<List<ToDo>> GetAllAsync()
        {
            var list = await db.Tasks.ToListAsync();
            return list;
        }
        public bool HasElement()
        {
            return db.Tasks.Any();
        }
        public bool CheckCount(int s)
        {
            if (db.Tasks.Count() >= s)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class DataBase : IToDoStorage
    {
        ApplicationContext db = new ApplicationContext();
        public async Task<List<ToDo>> LoadAsync()
        {   
            var list = await db.Users.ToListAsync();
            return list;
        }
        public async Task SaveAsync(List<ToDo> list)
        {
            db.Users.RemoveRange();
            await db.AddAsync(list);
            await db.SaveChangesAsync();
        }
    }
}
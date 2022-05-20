using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoReadWrite;
using System.Text.Json;

namespace ToDoList
{
    public class ToDoService
    {
        private List<ToDo> _TodoList = new List<ToDo>();
        private ReadWriteService _readWriteService;
        public ToDoService()
        {
            _readWriteService = new ReadWriteService(@"C:\Users\1123\Desktop\ToDoList.json");
        } 
        public bool CheckCount(int s)
        {
            if ( _TodoList.Count >=  s)
                return true;
            else
                return false;
        }
        public List<ToDo> GetAll()
        {
            return _TodoList;
        }
        public void Add(ToDo newToDo)
        {
            _TodoList.Add(newToDo);
        }
        public void Remove(int delNum)
        {
            _TodoList.RemoveAt(delNum - 1);
        }
        public void IsCompleted(int taskNum)
        {
            _TodoList[taskNum - 1].Status = true;
        }
        public async void LoadAsync()
        {
            List<ToDo> list = await _readWriteService.ReadJsonAsync();
            _TodoList.AddRange(list);
        }
        public async void SaveAsync()
        {
            await _readWriteService.WriteJsonAsync(_TodoList);
        }
        public bool HasElement()
        {
            return _TodoList.Any();
        }
    }
}

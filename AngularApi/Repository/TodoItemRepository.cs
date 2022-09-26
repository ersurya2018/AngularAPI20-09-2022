using AngularApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Repository
{
    public class TodoItemRepository: ITodoItemRepository
    {
        private readonly TodoContext _db;
        List<TodoItem> TodoModelObj = new List<TodoItem>();
        public TodoItemRepository(TodoContext todoContext)
        {
            _db = todoContext;
        }

        public IList<TodoItem> GetAllUserData()
        {
            var res = _db.TodoItems.Where(x => x.IsActive == true).ToList();

            
            if (res == null)
            {
                return TodoModelObj;
            }
            else
            {
                foreach (var item in res)
                {
                    TodoModelObj.Add(new TodoItem
                    {
                        Id = item.Id,
                        First_Name = item.First_Name,
                        Last_Name = item.Last_Name,
                        Email = item.Email,
                        Password = item.Password,
                        IsActive = item.IsActive
                    });
                }
            }

            return TodoModelObj;
        }
        public TodoItem GetAllUserData(long id)
        {
            try
            {
                var result = _db.TodoItems.Find(id);
                if (result == null)
                {
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TodoItem> CreateTodoItem(TodoItem _object)
        {
            _object.IsActive = true;
            var obj = await _db.TodoItems.AddAsync(_object);
            _db.SaveChanges();
            return obj.Entity;
        }


    }
}

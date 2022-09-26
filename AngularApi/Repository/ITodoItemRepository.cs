using AngularApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Repository
{
    public interface ITodoItemRepository
    {
        public IList<TodoItem> GetAllUserData();
        public TodoItem GetAllUserData(long id);
        public Task<TodoItem> CreateTodoItem(TodoItem _object);

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Model
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<TodoItem> TodoItems { set; get; } = null!;
    }
}

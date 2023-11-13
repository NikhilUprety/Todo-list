using Microsoft.EntityFrameworkCore;
using nikhiltodolist.Models;
using System.Collections.Generic;

namespace nikhiltodolist.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }


        public DbSet<WorkList> gaipuja { get; set; }

    }
}

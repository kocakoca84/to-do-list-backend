using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model;
using ToDoList.Repository.Interfaces;

namespace ToDoList.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ToDoListDbContext _toDoListDbContext;

        public ToDoListRepository(IServiceProvider services)
        {
            var serviceScope = services.CreateScope();
            _toDoListDbContext = serviceScope.ServiceProvider.GetRequiredService<ToDoListDbContext>();
        }

        public IList<ToDoTask> Get()
        {
            return _toDoListDbContext.ToDoTasks.ToList();
        }

        public async Task<int> Create(ToDoTask toDoTask)
        {
            _toDoListDbContext.ToDoTasks.Add(toDoTask);
            var numberOfItemsCreated = await _toDoListDbContext.SaveChangesAsync();
            return numberOfItemsCreated == 1 ? _toDoListDbContext.ToDoTasks.Max(t => t.Id) : 0;
        }

        public async Task Update(int toDoTaskId)
        {
            var task = _toDoListDbContext.ToDoTasks.SingleOrDefault(t => t.Id == toDoTaskId);
            if (task != null)
            {
                task.Completed = !task.Completed;
                await _toDoListDbContext.SaveChangesAsync();
            }
        }
    }
}

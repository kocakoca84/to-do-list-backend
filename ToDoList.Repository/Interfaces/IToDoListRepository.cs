using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Repository.Interfaces
{
    public interface IToDoListRepository
    {
        IList<ToDoTask> Get();
        Task<int> Create(ToDoTask toDoTask);
        Task Update(int toDoTaskId);
    }
}

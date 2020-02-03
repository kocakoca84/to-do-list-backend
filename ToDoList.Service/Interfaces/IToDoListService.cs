using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Service.Interfaces
{
    public interface IToDoListService
    {
        IList<ToDoTask> Get();
        Task<int> Create(string toDoTaskDescription);
        Task Update(int toDoTaskId);
    }
}

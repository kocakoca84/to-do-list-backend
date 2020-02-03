using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Model;
using ToDoList.Repository.Interfaces;
using ToDoList.Service.Interfaces;

namespace ToDoList.Service
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;
        
        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public IList<ToDoTask> Get()
        {
            var result = _toDoListRepository.Get();
            return result;
        }

        public async Task<int> Create(string toDoTaskDescription)
        {
            var task = new ToDoTask
            {
                Description = toDoTaskDescription,
                Completed = false
            };
            var success = await _toDoListRepository.Create(task);
            return success;
        }

        public async Task Update(int toDoTaskId)
        {
            await _toDoListRepository.Update(toDoTaskId);
        }
    }
}

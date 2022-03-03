using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Models;

namespace TasksAPI
{
    public interface ITasksService
    {
        Task<List<Tareas>> GetTareas();
        Task<Tareas> GetByIdAsync(string id);
        Task<Tareas> CreateAsync(Tareas tarea);
        Task UpdateAsync(string id, Tareas tarea);
        Task DeleteAsync(string id);

    }
}

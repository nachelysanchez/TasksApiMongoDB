using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Models;

namespace TasksAPI.Services
{
    public class TasksService : ITasksService
    {
        private readonly IMongoCollection<Tareas> Tasks;

        private readonly TasksDatabaseSettings settings;

        public TasksService(IOptions<TasksDatabaseSettings> set)
        {
            settings = set.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Tasks = database.GetCollection<Tareas>(settings.TasksCollectionName);
        }

        public async Task<List<Tareas>> GetTareas()
        {
            return await Tasks.Find(c => true).ToListAsync();
        }

        public async Task<Tareas> GetByIdAsync(string id)
        {
            return await Tasks.Find<Tareas>(c => c.TareaId == id).FirstOrDefaultAsync();
        }
        public async Task<Tareas> CreateAsync(Tareas tareas)
        {
            await Tasks.InsertOneAsync(tareas);
            return tareas;
        }
        public async Task UpdateAsync(string id, Tareas tareas)
        {
            await Tasks.ReplaceOneAsync(c => c.TareaId == id, tareas);
        }
        public async Task DeleteAsync(string id)
        {
            await Tasks.DeleteOneAsync(c => c.TareaId == id);
        }

        //public TasksService(IOptions<TasksDatabaseSettings> tasksDatabaseS)
        //{
        //    var mongoClient = new MongoClient(
        //        tasksDatabaseS.Value.ConnectionString);

        //    var mongoDatabase = mongoClient.GetDatabase(
        //        tasksDatabaseS.Value.DatabaseName);

        //    tasksCollection = mongoDatabase.GetCollection<Tareas>(
        //        tasksDatabaseS.Value.TasksCollectionName);
        //}

        //public async Task<List<Tareas>> GetTareasAsync() =>
        //    await tasksCollection.Find(x => true).ToListAsync();

        //public async Task<Tareas> GetTareasAsync(string id) =>
        //    await tasksCollection.Find(x => x.TareaId == id).FirstOrDefaultAsync();

        //public async Task CreateAsync(Tareas tarea) =>
        //    await tasksCollection.InsertOneAsync(tarea);

        //public async Task UpdateAsync(string id, Tareas tarea) =>
        //    await tasksCollection.ReplaceOneAsync(x => x.TareaId == id, tarea);

        //public async Task RemoveAsync(string id) => await tasksCollection.DeleteOneAsync(x => x.TareaId == id);

    }
}

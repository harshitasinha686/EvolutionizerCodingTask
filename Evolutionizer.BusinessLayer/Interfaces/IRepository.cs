
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Evolutionizer.BusinessLayer.Entities;


namespace Evolutionizer.BusinessLayer.Interfaces
{
    public interface IRepository
    {
        Task AddProgram(Entity.Program program);
        Task AddProject(Entity.Project project);
        Task AddTask(Entity.Task task);

        Task<Entity.Program> GetProgramById(int id);
        Task<Entity.Project> GetProjectById(int id , bool includeChildTask = false);
        Task<Entity.Task> GetTaskById(int id);

        Task<List<Entity.Program>> GetAllPrograms();

        Task DeleteProgram(Entity.Program program);
        Task DeleteProject(Entity.Project project);
        Task DeleteTask(Entity.Task task);

        Task UpdateProgram(Entity.Program program);
        Task UpdateProject(Entity.Project project);
        Task UpdateTask(Entity.Task task);

        Task<List<BusinessLayer.Entities.Task>> GetTasksByIds(List<int> ids);
    }
}

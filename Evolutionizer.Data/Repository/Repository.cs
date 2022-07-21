using Evolutionizer.BusinessLayer.Entities;
using Evolutionizer.BusinessLayer.Interfaces;
using Evolutionizer.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Evolutionizer.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly EvolutionizerCodingTaskDbContext _dbContext;
        public Repository(EvolutionizerCodingTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProgram(Program program)
        {
            await _dbContext.Set<Program>().AddAsync(program);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddProject(Project project)
        {
            await _dbContext.Set<Project>().AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTask(BusinessLayer.Entities.Task task)
        {
            await _dbContext.Set<BusinessLayer.Entities.Task>().AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Program> GetProgramById(int id)
        {

            return await _dbContext.Set<Program>().Include(x => x.Projects).ThenInclude(y => y.Tasks).FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<Project> GetProjectById(int id, bool includeChildTask = false)
        //{
        //    if(!includeChildTask)
        //        return await _dbContext.Set<Project>().Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == id);
        //    else
        //        return await _dbContext.Set<Project>().Include(x => x.Tasks).ThenInclude(z => z.ChildTaskDependency).ThenInclude(z => z.ChildTask).FirstOrDefaultAsync(x => x.Id == id);
        //}

        public async Task<Project> GetProjectById(int id, bool includeChildTask = false)
        {
            //conditional query approach
            IQueryable<Project> query = _dbContext.Set<Project>();
            if (includeChildTask)
            {
                query = query.Include(x => x.Tasks).ThenInclude(z => z.ChildTaskDependency).ThenInclude(z => z.ChildTask);
            }
            else
            {
                query = query.Include(x => x.Tasks);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BusinessLayer.Entities.Task> GetTaskById(int id)
        {
            return await _dbContext.Set<BusinessLayer.Entities.Task>().Include(y => y.ChildTaskDependency).ThenInclude(z => z.ChildTask).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Program>> GetAllPrograms()
        {
            return await _dbContext.Set<Program>().Include(x => x.Projects).ThenInclude(y => y.Tasks).ToListAsync();
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _dbContext.Set<Project>().Include(x => x.Tasks).ToListAsync();
        }

        public async Task DeleteProgram(Program program)
        {
             _dbContext.Set<Program>().Remove(program);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(Project project)
        {
            _dbContext.Set<Project>().Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTask(BusinessLayer.Entities.Task task)
        {
            _dbContext.Set<BusinessLayer.Entities.Task>().Remove(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProgram(Program program)
        {
            _dbContext.Entry(program).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
            await SaveChangesWithConcurrency();
        }
        public async Task UpdateProject(Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
            await SaveChangesWithConcurrency();
        }
        public async Task UpdateTask(BusinessLayer.Entities.Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
            await SaveChangesWithConcurrency();
        }

        public async Task<List<BusinessLayer.Entities.Task>> GetTasksByIds(List<int> ids)
        {
            return await _dbContext.Set<BusinessLayer.Entities.Task>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }
        private async Task SaveChangesWithConcurrency()
        {
            try
            {
               await _dbContext.SaveChangesAsync();
                // move on
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

    }
}

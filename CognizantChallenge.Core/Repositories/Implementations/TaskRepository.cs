using CognizantChallenge.Core.Database;
using CognizantChallenge.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CognizantChallenge.DAL.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext context;

        public TaskRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Core.Database.Entities.Task entity)
        {
            context.Tasks.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Core.Database.Entities.Task entity)
        {
            context.Tasks.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Core.Database.Entities.Task>> FindAsync(Expression<Func<Core.Database.Entities.Task, bool>> predicate)
        {
            var tasks = await context
                .Tasks
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
            return tasks;
        }

        public async Task<IEnumerable<Core.Database.Entities.Task>> GetAllAsync()
        {
            var tasks = await context
                .Tasks
                .AsNoTracking()
                .ToListAsync();
            return tasks;
        }

        public async Task<Core.Database.Entities.Task> GetByIdAsync(int id)
        {
            var task = await context
               .Tasks
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id);
            return task;
        }

        public async Task UpdateAsync(Core.Database.Entities.Task entity)
        {
            context.Tasks.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

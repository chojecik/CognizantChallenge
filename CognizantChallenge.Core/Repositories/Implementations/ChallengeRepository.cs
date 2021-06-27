using CognizantChallenge.Core.Database;
using CognizantChallenge.Core.Database.Entities;
using CognizantChallenge.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CognizantChallenge.DAL.Repositories.Implementations
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly DataContext context;

        public ChallengeRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Challenge entity)
        {
            context.Challenges.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Challenge entity)
        {
            context.Challenges.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Challenge>> FindAsync(Expression<Func<Challenge, bool>> predicate)
        {
            var challenges = await context
               .Challenges
               .Include(x => x.Task)
               .AsNoTracking()
               .Where(predicate)
               .ToListAsync();
            return challenges;
        }

        public async Task<IEnumerable<Challenge>> GetAllAsync()
        {
            var challenges = await context
                .Challenges
                .Include(x => x.Task)
                .AsNoTracking()
                .ToListAsync();
            return challenges;
        }

        public async Task<Challenge> GetByIdAsync(int id)
        {
            var challenge = await context
              .Challenges
              .Include(x => x.Task)
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);
            return challenge;
        }

        public async Task UpdateAsync(Challenge entity)
        {
            context.Challenges.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

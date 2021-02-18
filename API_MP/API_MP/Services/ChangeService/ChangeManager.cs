using API_MP.Data;
using API_MP.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.ChangeService
{
    public class ChangeManager : IChangeManager
    {
        private ApplicationDbContext _context;
        public ChangeManager (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Change>> ListAllChanges()
        {
            return await _context.Changes.ToListAsync();
        }
        public async Task<Change> Create(Change input)
        {
            Change newChange = new Change
            {
                Description = input.Description,
                ChangeType = input.ChangeType
            };
            _context.Changes.Add(newChange);
            await _context.SaveChangesAsync();
            return newChange;
        }

        public Task<Change> Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Change> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Change> Update(int id, Change input)
        {
            throw new NotImplementedException();
        }
    }
}

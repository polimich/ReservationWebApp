using API_MP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.ChangeService
{
    public interface IChangeManager
    {
        Task<ICollection<Change>> ListAllChanges();
        Task<Change> Create(Change input);
        Task<Change> Delete(int id);
        Task<Change> Update(int id, Change input);
        Task<Change> Read(int id);

    }
}

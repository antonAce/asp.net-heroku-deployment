using System.Linq;
using System.Threading.Tasks;
using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Domain.Interfaces.Repositories
{
    public interface IModelRepository
    {
        Task Create(Model model);
        Task<IQueryable<Model>> Fetch(int limit, int offset);
        Task<Model> GetById(int id);
        Task Update(Model model);
        Task Drop(int id);
    }
}
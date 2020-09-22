using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Domain.Interfaces.Repositories;
using AutoDock.Catalog.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoDock.Catalog.Data.EF.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private AutoDockContext Context { get; }

        public ModelRepository(AutoDockContext context) =>
            Context = context;

        public async Task CreateAsync(Model model, CancellationToken token) =>
            await Context.Models.AddAsync(model, token);

        public async Task<IReadOnlyCollection<Model>> FetchAsync(int limit, int offset, CancellationToken token) =>
            await Context.Models.Skip(offset).Take(limit).AsNoTracking().ToArrayAsync(token);

        public async Task<Model> FindByIdAsync(int id, CancellationToken token) =>
            await Context.Models.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id, token);

        public async Task UpdateAsync(Model model, CancellationToken token)
        {
            var existingModel = await FindByIdAsync(model.Id, token);

            if (existingModel != null)
                Context.Models.Update(existingModel);
        }

        public async Task DropAsync(int id, CancellationToken token)
        {
            var existingModel = await FindByIdAsync(id, token);

            if (existingModel != null)
                Context.Models.Remove(existingModel);
        }
    }
}
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
    public class ManufacturerRepository : IManufacturerRepository
    {
        private AutoDockContext Context { get; }

        public ManufacturerRepository(AutoDockContext context) =>
            Context = context;
        
        public async Task CreateAsync(Manufacturer manufacturer, CancellationToken token) =>
            await Context.Manufacturers.AddAsync(manufacturer, token);

        public async Task<IReadOnlyCollection<Manufacturer>> FetchAsync(int limit, int offset, CancellationToken token) =>
            await Context.Manufacturers.Skip(offset).Take(limit).ToArrayAsync(token);

        public async Task<Manufacturer> FindByIdAsync(int id, CancellationToken token) =>
            await Context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id, token);

        public async Task UpdateAsync(Manufacturer manufacturer, CancellationToken token)
        {
            var existingManufacturer = await FindByIdAsync(manufacturer.Id, token);

            if (existingManufacturer != null)
                Context.Manufacturers.Update(existingManufacturer);
        }

        public async Task DropAsync(int id, CancellationToken token)
        {
            var existingManufacturer = await FindByIdAsync(id, token);

            if (existingManufacturer != null)
                Context.Manufacturers.Remove(existingManufacturer);
        }
    }
}
using MainAppBackend.Domain.Entities.ClientLookup;
using MainAppBackend.Domain.Entities.Product;
using MainAppBackend.Domain.Interfaces.Product;
using MainAppBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Infrastructure.Repositories.ClientLookup
{
    public class ClientLookupRepository : IClientLookupRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientLookupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task CreateAsync(Domain.Entities.ClientLookup.ClientLookup  input)
        {
            await _context.ClientLookups.AddAsync(input);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, Domain.Entities.ClientLookup.ClientLookup input)
        {
            _context.ClientLookups.Update(input);
            await _context.SaveChangesAsync();
        }

       
        async Task<Domain.Entities.ClientLookup.ClientLookup> IClientLookupRepository.GetByIdAsync(Guid id)
        {
            return await _context.ClientLookups.FindAsync(id);
        }

        async Task<List<Domain.Entities.ClientLookup.ClientLookup>> IClientLookupRepository.GetAllAsync()
        {
            return await _context.ClientLookups.ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.ClientLookups.FindAsync(id);

            if (entity == null)
                throw new Exception("ClientLookup not found");

            _context.ClientLookups.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}


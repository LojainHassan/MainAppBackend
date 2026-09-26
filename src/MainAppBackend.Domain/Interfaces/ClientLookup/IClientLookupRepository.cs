using MainAppBackend.Domain.Entities.ClientLookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Domain.Entities.ClientLookup;

public interface IClientLookupRepository
{
    Task<ClientLookup?> GetByIdAsync(Guid id);
    Task<List<ClientLookup>> GetAllAsync();
    Task CreateAsync(ClientLookup input);
    Task UpdateAsync(Guid id, ClientLookup input);
    Task DeleteAsync(Guid id);
}

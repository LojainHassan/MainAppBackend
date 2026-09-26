using MainAppBackend.Application.Dtos.ClientLookup;
using MainAppBackend.Application.Dtos.Product.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using MainAppBackend.Application.Dtos.ClientLookup;
namespace MainAppBackend.Application.Interfaces.ClientLookup
{
    public interface IClientLookupService
    {
        Task<PagedResultDto<ClientLookupDto>> GetAllAsync(int skip = 0, int take = 10);

        Task<ClientLookupDto> GetByIdAsync(Guid id);

        Task<ClientLookupDto> CreateAsync(UpdateCreateClientLookupDto input);

        Task<ClientLookupDto> UpdateAsync(Guid id, UpdateCreateClientLookupDto input);

        Task DeleteAsync(Guid id);
    }
}

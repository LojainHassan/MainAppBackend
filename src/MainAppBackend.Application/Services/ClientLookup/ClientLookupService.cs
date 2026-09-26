using AutoMapper;
using MainAppBackend.Application.Dtos.ClientLookup;
using MainAppBackend.Application.Dtos.Product.ProductCategory;
using MainAppBackend.Application.Interfaces.ClientLookup;
using MainAppBackend.Domain.Entities.ClientLookup;
using MainAppBackend.Domain.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using MainAppBackend.Domain.Entities.ClientLookup;
namespace MainAppBackend.Application.Services.ClientLookup
{
    public class ClientLookupService : IClientLookupService
    {
        private readonly IClientLookupRepository _repository;
        private readonly IMapper _mapper;

        public ClientLookupService(IClientLookupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ClientLookupDto> CreateAsync(UpdateCreateClientLookupDto input)
        {
            var entity = _mapper.Map<MainAppBackend.Domain.Entities.ClientLookup.ClientLookup>(input);
            await _repository.CreateAsync(entity);
            return _mapper.Map<ClientLookupDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("ClientLookup not found");

            await _repository.DeleteAsync(id);
        }



        public async Task<ClientLookupDto> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category is null ? null : _mapper.Map<ClientLookupDto>(category);
        }

        public async Task<ClientLookupDto> UpdateAsync(Guid id, UpdateCreateClientLookupDto input)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("ClientLookup not found.");

            _mapper.Map(input, entity);

            await _repository.UpdateAsync(id, entity);

            return _mapper.Map<ClientLookupDto>(entity);
        }
        public async Task<PagedResultDto<ClientLookupDto>> GetAllAsync(int skip = 0, int take = 10)
        {
            var categories = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ClientLookupDto>>(categories);

            return new PagedResultDto<ClientLookupDto>(
                totalCount: dtos.Count,
                items: dtos
            );
        }
    }
}

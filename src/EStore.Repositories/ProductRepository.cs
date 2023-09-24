using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _dao;
        private readonly IMapper _mapper;
        public ProductRepository(ProductDAO dao, IMapper mapper)
        {

            _dao = dao;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO entity)
        {
            return _mapper.Map<ProductDTO>(await _dao.CreateAsync(_mapper.Map<Product>(entity)).ConfigureAwait(false));
        }

        public async Task DeleteAsync(ProductDTO entity)
        {
            await _dao.DeleteAsync(_mapper.Map<Product>(entity)).ConfigureAwait(false);
        }

        public async Task<IList<ProductDTO>> FindAllAsync()
        {
            return _mapper.Map<IList<ProductDTO>>(await _dao.FindAllAsync().ConfigureAwait(false));
        }

        public async Task<ProductDTO?> FindByIdAsync(int entityId)
        {
            return _mapper.Map<ProductDTO?>(await _dao.FindByIdAsync(entityId).ConfigureAwait(false));
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO entity)
        {
            return _mapper.Map<ProductDTO>(await _dao.UpdateAsync(_mapper.Map<Product>(entity)).ConfigureAwait(false));
        }
    }
}

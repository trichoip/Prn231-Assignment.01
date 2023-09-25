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
            var en = _mapper.Map<Product>(entity);
            en = await _dao.CreateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<ProductDTO>(en);
            return enDTO;
        }

        public async Task<IList<ProductDTO>> FindAllAsync()
        {
            var entities = await _dao.FindAllAsync().ConfigureAwait(false);
            var entityDTOs = _mapper.Map<IList<ProductDTO>>(entities);
            return entityDTOs;
        }

        public async Task<ProductDTO?> FindByIdAsync(int entityId)
        {
            var entity = await _dao.FindByIdAsync(new object?[] { entityId }).ConfigureAwait(false);
            var entityDTO = _mapper.Map<ProductDTO?>(entity);
            return entityDTO;
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO entity)
        {
            var en = _mapper.Map<Product>(entity);
            en = await _dao.UpdateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<ProductDTO>(en);
            return enDTO;
        }

        public async Task DeleteAsync(ProductDTO entity)
        {
            var en = _mapper.Map<Product>(entity);
            await _dao.DeleteAsync(en).ConfigureAwait(false);
        }
    }
}

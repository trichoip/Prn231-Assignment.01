using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly CategoryDAO _dao;
        private readonly IMapper _mapper;
        public CategoryRepository(CategoryDAO dao, IMapper mapper)
        {

            _dao = dao;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO entity)
        {
            var en = _mapper.Map<Category>(entity);
            en = await _dao.CreateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<CategoryDTO>(en);
            return enDTO;
        }

        public async Task<IList<CategoryDTO>> FindAllAsync()
        {
            var entities = await _dao.FindAllAsync().ConfigureAwait(false);
            var entityDTOs = _mapper.Map<IList<CategoryDTO>>(entities);
            return entityDTOs;
        }

        public async Task<CategoryDTO?> FindByIdAsync(int entityId)
        {
            var entity = await _dao.FindByIdAsync(new object?[] { entityId }).ConfigureAwait(false);
            var entityDTO = _mapper.Map<CategoryDTO?>(entity);
            return entityDTO;
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO entity)
        {
            var en = _mapper.Map<Category>(entity);
            en = await _dao.UpdateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<CategoryDTO>(en);
            return enDTO;
        }

        public async Task DeleteAsync(CategoryDTO entity)
        {
            var en = _mapper.Map<Category>(entity);
            await _dao.DeleteAsync(en).ConfigureAwait(false);
        }

    }
}

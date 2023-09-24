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
            return _mapper.Map<CategoryDTO>(await _dao.CreateAsync(_mapper.Map<Category>(entity)).ConfigureAwait(false));
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _dao.FindByIdAsync(id).ConfigureAwait(false);
            await _dao.DeleteAsync(p).ConfigureAwait(false);
        }

        public async Task<IList<CategoryDTO>> FindAllAsync()
        {
            return _mapper.Map<IList<CategoryDTO>>(await _dao.FindAllAsync().ConfigureAwait(false));
        }

        public async Task<CategoryDTO?> FindByIdAsync(int entityId)
        {
            return _mapper.Map<CategoryDTO?>(await _dao.FindByIdAsync(entityId).ConfigureAwait(false));
        }

        public async Task<CategoryDTO> UpdateAsync(int id, CategoryDTO productRespond)
        {
            var p = await _dao.FindByIdAsync(id).ConfigureAwait(false);

            _mapper.Map(productRespond, p);

            return _mapper.Map<CategoryDTO>(await _dao.UpdateAsync(p).ConfigureAwait(false));
        }

    }
}

using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private readonly OrderDetailDAO _dao;
        private readonly IMapper _mapper;
        public OrderDetailRepository(OrderDetailDAO dao, IMapper mapper)
        {

            _dao = dao;
            _mapper = mapper;
        }
        public async Task<OrderDetailDTO> CreateAsync(OrderDetailDTO entity)
        {
            var en = _mapper.Map<OrderDetail>(entity);
            en = await _dao.CreateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<OrderDetailDTO>(en);
            return enDTO;
        }

        public async Task<IList<OrderDetailDTO>> FindAllAsync()
        {
            var entities = await _dao.FindAllAsync().ConfigureAwait(false);
            var entityDTOs = _mapper.Map<IList<OrderDetailDTO>>(entities);
            return entityDTOs;
        }

        public async Task<OrderDetailDTO?> FindByIdAsync(int entityId, int entityId2)
        {
            var entity = await _dao.FindByIdAsync(new object?[] { entityId, entityId2 }).ConfigureAwait(false);
            var entityDTO = _mapper.Map<OrderDetailDTO?>(entity);
            return entityDTO;
        }

        public async Task<OrderDetailDTO> UpdateAsync(OrderDetailDTO entity)
        {
            var en = _mapper.Map<OrderDetail>(entity);
            en = await _dao.UpdateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<OrderDetailDTO>(en);
            return enDTO;
        }

        public async Task DeleteAsync(OrderDetailDTO entity)
        {
            var en = _mapper.Map<OrderDetail>(entity);
            await _dao.DeleteAsync(en).ConfigureAwait(false);
        }
    }
}

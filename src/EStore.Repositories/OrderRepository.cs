using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrderDAO _dao;
        private readonly IMapper _mapper;
        public OrderRepository(OrderDAO dao, IMapper mapper)
        {

            _dao = dao;
            _mapper = mapper;
        }

        public async Task<OrderDTO> CreateAsync(OrderDTO entity)
        {
            var en = _mapper.Map<Order>(entity);
            en = await _dao.CreateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<OrderDTO>(en);
            return enDTO;
        }

        public async Task<IList<OrderDTO>> FindAllAsync()
        {
            var entities = await _dao.FindAllAsync().ConfigureAwait(false);
            var entityDTOs = _mapper.Map<IList<OrderDTO>>(entities);
            return entityDTOs;
        }

        public async Task<OrderDTO?> FindByIdAsync(int entityId)
        {
            var entity = await _dao.FindByIdAsync(new object?[] { entityId }).ConfigureAwait(false);
            var entityDTO = _mapper.Map<OrderDTO?>(entity);
            return entityDTO;
        }

        public async Task<OrderDTO> UpdateAsync(OrderDTO entity)
        {
            var en = _mapper.Map<Order>(entity);
            en = await _dao.UpdateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<OrderDTO>(en);
            return enDTO;
        }

        public async Task DeleteAsync(OrderDTO entity)
        {
            var en = _mapper.Map<Order>(entity);
            await _dao.DeleteAsync(en).ConfigureAwait(false);
        }
    }
}

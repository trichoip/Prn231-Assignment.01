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
            return _mapper.Map<OrderDTO>(await _dao.CreateAsync(_mapper.Map<Order>(entity)).ConfigureAwait(false));
        }

        public async Task DeleteAsync(OrderDTO entity)
        {
            await _dao.DeleteAsync(_mapper.Map<Order>(entity)).ConfigureAwait(false);
        }

        public async Task<IList<OrderDTO>> FindAllAsync()
        {
            return _mapper.Map<IList<OrderDTO>>(await _dao.FindAllAsync().ConfigureAwait(false));
        }

        public async Task<OrderDTO?> FindByIdAsync(int entityId)
        {
            return _mapper.Map<OrderDTO?>(await _dao.FindByIdAsync(entityId).ConfigureAwait(false));
        }

        public async Task<OrderDTO> UpdateAsync(OrderDTO entity)
        {
            return _mapper.Map<OrderDTO>(await _dao.UpdateAsync(_mapper.Map<Order>(entity)).ConfigureAwait(false));
        }
    }
}

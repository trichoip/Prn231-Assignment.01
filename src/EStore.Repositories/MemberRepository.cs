using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public class MemberRepository : IMemberRepository
    {

        private readonly MemberDAO _dao;
        private readonly IMapper _mapper;
        public MemberRepository(MemberDAO dao, IMapper mapper)
        {

            _dao = dao;
            _mapper = mapper;
        }

        public async Task<MemberDTO> LoginAsync(string email, string password)
        {
            return _mapper.Map<MemberDTO>(await _dao.Login(email, password).ConfigureAwait(false));
        }

        public async Task<MemberDTO> CreateAsync(MemberDTO entity)
        {
            var en = _mapper.Map<Member>(entity);
            en = await _dao.CreateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<MemberDTO>(en);
            return enDTO;
        }

        public async Task<IList<MemberDTO>> FindAllAsync()
        {
            var entities = await _dao.FindAllAsync().ConfigureAwait(false);
            var entityDTOs = _mapper.Map<IList<MemberDTO>>(entities);
            return entityDTOs;
        }

        public async Task<MemberDTO?> FindByIdAsync(int entityId)
        {
            var entity = await _dao.FindByIdAsync(new object?[] { entityId }).ConfigureAwait(false);
            var entityDTO = _mapper.Map<MemberDTO?>(entity);
            return entityDTO;
        }

        public async Task<MemberDTO> UpdateAsync(MemberDTO entity)
        {
            var en = _mapper.Map<Member>(entity);
            en = await _dao.UpdateAsync(en).ConfigureAwait(false);
            var enDTO = _mapper.Map<MemberDTO>(en);
            return enDTO;
        }

        public async Task DeleteAsync(MemberDTO entity)
        {
            var en = _mapper.Map<Member>(entity);
            await _dao.DeleteAsync(en).ConfigureAwait(false);
        }

    }
}

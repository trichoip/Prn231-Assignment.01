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

        public async Task<MemberDTO> CreateAsync(MemberDTO entity)
        {
            return _mapper.Map<MemberDTO>(await _dao.CreateAsync(_mapper.Map<Member>(entity)).ConfigureAwait(false));
        }

        public async Task DeleteAsync(MemberDTO entity)
        {
            await _dao.DeleteAsync(_mapper.Map<Member>(entity)).ConfigureAwait(false);
        }

        public async Task<IList<MemberDTO>> FindAllAsync()
        {
            return _mapper.Map<IList<MemberDTO>>(await _dao.FindAllAsync().ConfigureAwait(false));
        }

        public async Task<MemberDTO?> FindByIdAsync(int entityId)
        {
            return _mapper.Map<MemberDTO?>(await _dao.FindByIdAsync(entityId).ConfigureAwait(false));
        }

        public async Task<MemberDTO> LoginAsync(string email, string password)
        {
            return _mapper.Map<MemberDTO>(await _dao.Login(email, password).ConfigureAwait(false));
        }

        public async Task<MemberDTO> UpdateAsync(MemberDTO entity)
        {
            return _mapper.Map<MemberDTO>(await _dao.UpdateAsync(_mapper.Map<Member>(entity)).ConfigureAwait(false));
        }
    }
}

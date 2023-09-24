using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface IMemberRepository
    {
        Task<MemberDTO> LoginAsync(string email, string password);
        Task<IList<MemberDTO>> FindAllAsync();
        Task<MemberDTO> CreateAsync(MemberDTO entity);
        Task<MemberDTO> UpdateAsync(MemberDTO entity);
        Task DeleteAsync(MemberDTO entity);
        Task<MemberDTO?> FindByIdAsync(int entityId);
    }
}

using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public interface IMemberRepository
    {
        bool Login(string email, string password);
        void AddMember(MemberDTO m);

        Member GetMemberByID(int id);

        void UpdateMember(int id, MemberDTO m);

        List<Member> GetMembers();

        void DeleteMember(Member member);
    }
}

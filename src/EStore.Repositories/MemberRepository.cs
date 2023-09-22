using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public class MemberRepository : IMemberRepository
    {

        private readonly MemberDAO _memberDAO;
        public MemberRepository(MemberDAO memberDAO) => _memberDAO = memberDAO;

        public bool Login(string email, string password) => _memberDAO.Login(email, password);
        public void AddMember(MemberDTO m) => _memberDAO.AddMember(m);

        public void DeleteMember(Member member) => _memberDAO.DeleteMember(member);

        public Member GetMemberByID(int id) => _memberDAO.FindMemberById(id);

        public List<Member> GetMembers() => _memberDAO.GetAllMembers();

        public void UpdateMember(int id, MemberDTO m) => _memberDAO.UpdateMember(id, m);

    }
}

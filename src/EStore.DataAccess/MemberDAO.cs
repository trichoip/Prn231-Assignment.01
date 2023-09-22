using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.DataAccess
{
    public class MemberDAO
    {
        private readonly FstoreDbContext context;

        public MemberDAO(FstoreDbContext _context) => context = _context;

        public bool Login(string email, string password)
        {
            bool isLogin = false;
            try
            {

                var mem = context.Members.FirstOrDefault(i => i.Email == email && i.Password == password);
                if (mem != null)
                {
                    isLogin = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isLogin;
        }

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            try
            {
                members = context.Members.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public Member FindMemberById(int pid)
        {
            Member p = new Member();
            try
            {
                p = context.Members.SingleOrDefault(p => p.MemberId == pid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public void AddMember(MemberDTO memberRespond)
        {
            try
            {
                var member = new Member
                {
                    Email = memberRespond.Email,
                    CompanyName = memberRespond.CompanyName,
                    City = memberRespond.City,
                    Country = memberRespond.Country,
                    Password = memberRespond.Password,
                };
                context.Members.Add(member);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(int id, MemberDTO memberRespond)
        {
            try
            {
                var memberUpdate = context.Members.SingleOrDefault(p => p.MemberId == id);
                memberUpdate.Email = memberRespond.Email;
                memberUpdate.CompanyName = memberRespond.CompanyName;
                memberUpdate.City = memberRespond.City;
                memberUpdate.Country = memberRespond.Country;
                memberUpdate.Password = memberRespond.Password;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                var mem = context.Members.SingleOrDefault(m => m.MemberId == member.MemberId);
                context.Members.Remove(mem);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

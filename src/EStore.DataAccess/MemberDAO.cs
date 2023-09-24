using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace EStore.DataAccess
{
    public class MemberDAO : BaseDAO<Member>, IBaseDAO<Member>
    {
        private readonly FstoreDbContext context;

        public MemberDAO(FstoreDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<Member> Login(string email, string password)
        {

            if (await context.Members.FirstOrDefaultAsync(m => m.Email == email && m.Password == password) is not { } member)
                throw new Exception("Invalid email or password");

            return member;
        }

    }
}

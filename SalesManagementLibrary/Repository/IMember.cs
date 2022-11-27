using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public interface IMember
    {
        Member MemberLogin(string email, string password);

        Member GetMemberId(int id);

        IEnumerable<Member> GetMember();

        void Insert(Member member);

        void Update(Member member);

        void Delete(Member member);
    }
}

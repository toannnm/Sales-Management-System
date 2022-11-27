using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public class MemberRepo : IMember
    {
        private SalesManagementDbContext db;
        public MemberRepo(SalesManagementDbContext db)
        {
            this.db = db;
        }
        public MemberRepo()
        {
            db = new();
        }
        public void Delete(Member member)
        {
            try
            {
                var mem = db.Members.SingleOrDefault(c => c.MemberId == member.MemberId);
                db.Remove(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Member> GetMember()
        {
            return db.Members.ToList();
        }

        public Member GetMemberId(int id)
        {
            var mem = db.Members.SingleOrDefault(c => c.MemberId.Equals(id));
            return mem;
        }

        public void Insert(Member member)
        {
            try
            {
                db.Add(member);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Member member)
        {
           var mem = db.Members.SingleOrDefault(c => c.MemberId == member.MemberId);
            mem.Email = member.Email;
            mem.CompanyName = member.CompanyName;
            mem.City = member.City;
            mem.Country = member.Country;
            mem.Password = member.Password;

            db.SaveChanges();
        }

        public Member MemberLogin(string email, string password)
        {
            Member? member = db.Members.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            return member;
        }
    }
}

using RepoRapport.Data;
using RepoRapport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Services
{
    public class MemberServices
    {
        private readonly Guid _userId;

        public MemberServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMember(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    MemberID = model.MemberID,
                    OwnerId = _userId,
                    Title = model.Title,
                    Name = model.Name,
                   Skillset = model.Skillset
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MemberListItem> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Members
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MemberListItem
                                {
                                    MemberID = e.MemberID,

                                    Title = e.Title,

                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }
        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.MemberID == id && e.OwnerId == _userId);
                return
                    new MemberDetail
                    {
                        MemberID = entity.MemberID,
                        OwnerId = _userId,
                        Title = entity.Title,
                        Name = entity.Name,
                        Skillset = entity.Skillset
                        

                    };
            }
        }

        public bool UpdateMember(MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.MemberID == model.MemberID && e.OwnerId == _userId);



                entity.Skillset = model.Skillset;
                entity.Title = model.Title;
                entity.Name = model.Name;



                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMember(int memberID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.MemberID == memberID && e.OwnerId == _userId);

                ctx.Members.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

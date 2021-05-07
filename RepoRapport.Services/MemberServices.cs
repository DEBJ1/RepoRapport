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
        public bool CreateReport(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    MemberID = MemberID,
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

            IEnumerable<MemberListItem> GetAllMembers()
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
                                Title = e.Title
                            }
                            );
                    return query.ToArray();
                }
    }
}

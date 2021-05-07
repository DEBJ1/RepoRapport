using RepoRapport.Data;
using RepoRapport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Services
{
    public class ReportServices
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public ReportServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReport(ReportCreate model)
        {
            var entity =
                new Report()
                {
                    ReportID = model.ReportID,
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    Created = DateTimeOffset.Now,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
             IEnumerable<ReportListItem> GetAllReports()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Reports
                        .Where(e =>e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ReportListItem
                            {
                                ReportID = e.ReportID,
                                Title = e.Title
                            }
                            );
                    return query.ToArray();
              
                }
            }
        }
    }
}

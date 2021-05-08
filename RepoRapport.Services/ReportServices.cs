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
                        MemberId = model.MemberId,
                        JobId = model.JobId
                    
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Reports.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<ReportListItem> GetReports()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Reports
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new ReportListItem
                                    {
                                        ReportID = e.ReportID,
                                        
                                        Title = e.Title,
                                      
                                        Created = DateTimeOffset.Now,
                                        MemberId = e.MemberId,
                                        JobId = e.JobId
                                    }
                            );

                    return query.ToArray();
                }
            }
            public ReportDetail GetReportById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reports
                            .Single(e => e.ReportID == id && e.OwnerId == _userId);
                    return
                        new ReportDetail
                        {
                            ReportID = entity.ReportID,
                            OwnerId = _userId,
                            Title = entity.Title,
                
                            Content = entity.Content,
                            Created = entity.Created,
                            MemberId = entity.MemberId,
                            JobId = entity.JobId
                            
                            
                        };
                }
            }

            public bool UpdateReport(ReportEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reports
                            .Single(e => e.ReportID == model.ReportID && e.OwnerId == _userId);
                    
                    
                   
                    entity.Content = model.Content;
                    entity.Title = model.Title;
                    entity.MemberId = model.MemberId;
                    entity.JobId = model.JobId;




                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteReport(int reportID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Reports
                            .Single(e => e.ReportID == reportID && e.OwnerId == _userId);

                    ctx.Reports.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

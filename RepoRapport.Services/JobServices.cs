using RepoRapport.Data;
using RepoRapport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Services
{
    public class JobServices
    {
        private readonly Guid _userId;

        public JobServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    JobID = model.JobID,
                    OwnerId =_userId,
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = DateTimeOffset.Now,
                    MemberID = model.MemberID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobID = e.JobID,

                                    Title = e.Title,

                                   Completed = e.Completed,
                                   MemberID = e.MemberID
                                }
                        );

                return query.ToArray();
            }
        }
        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobID == id && e.OwnerId == _userId);
                return
                    new JobDetail
                    {
                        JobID = entity.JobID,
                        OwnerId = _userId,
                        Title = entity.Title,
                        Description = entity.Description,
                        StartDate = entity.StartDate,
                        Completed = entity.Completed,
                        MemberID = entity.MemberID

                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobID == model.JobID && e.OwnerId == _userId);



                entity.Description = model.Description;
                entity.Title = model.Title;
                entity.Completed = model.Completed;
                entity.MemberID = model.MemberID;



                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteJob(int jobID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobID == jobID && e.OwnerId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

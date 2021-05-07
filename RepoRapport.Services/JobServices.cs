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
                    JobID = JobID,
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Completed = model.Completed,
                    EndDate = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            IEnumerable<JobListItem> GetAllJobs()
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
                                Title = e.Title
                            }
                            );
                    return query.ToArray();
                }
    }
}

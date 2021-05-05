using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Data
{
    public class Job
    {
        [Key]
        public int? JobID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool Completed { get; set; }

        [ForeignKey("Member")]
        public int? MemberID { get; set; }
        public virtual Member Member {get; set;}
    }
}

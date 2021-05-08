using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Data
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }

        [ForeignKey(nameof(Member))] 
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        [ForeignKey(nameof(Job))] 
        public int? JobId { get; set; }
       
        public virtual Job Job { get; set; }
    }
}

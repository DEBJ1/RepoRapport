using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class ReportCreate
    {
        [Required]
        public string Title { get; set; }
        [Key]
        public int ReportID { get; set; }
        public string Content { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset Created { get; set; }
        public int? JobId { get; set; }
        public int? MemberId { get; set; }
    }
}

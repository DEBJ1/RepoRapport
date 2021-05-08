using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class ReportEdit
    {
        [Key]
        public int ReportID { get; set; }

        public string Title { get; set; }
       
        public string Content { get; set; }
        
        public DateTimeOffset Created { get; set; }

        public int? MemberId { get; set; }
        public int? JobId { get; set; }
      
    }
}

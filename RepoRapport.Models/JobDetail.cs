using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class JobDetail
    {
        [Key]
        public int JobID { get; set; }
    
        public Guid OwnerId { get; set; }

       
        public string Title { get; set; }

        public string Description { get; set; }

  
        public DateTimeOffset StartDate { get; set; }
 
        public DateTimeOffset EndDate { get; set; }

    
        public bool Completed { get; set; }

       
        public int? MemberID { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class JobListItem
    {
        [Key]
        public int JobID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}

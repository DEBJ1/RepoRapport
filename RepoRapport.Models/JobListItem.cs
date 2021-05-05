using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class JobListItem
    {

        public int? JobID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}

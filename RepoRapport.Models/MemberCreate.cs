using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
    public class MemberCreate
    {
        [Required]
        public string Title { get; set; }
        public string Name { get; set; }
        public string Skillset { get; set; }
    }
}

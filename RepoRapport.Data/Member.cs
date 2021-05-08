using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Data
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set;  }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Skillset { get; set; }
    }
}

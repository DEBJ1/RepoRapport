using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoRapport.Models
{
   public class MemberListItem
    {
        [Key]
        public int MemberID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

    }
}

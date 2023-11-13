using System.ComponentModel.DataAnnotations;

namespace nikhiltodolist.Models
{
    public class WorkList
    {
       
        
            [Key]
            public int Id { get; set; }
            public string worktitle { get; set; }
            public string time { get; set; }
            public string category { get; set; }
     
        }
    }

using System.ComponentModel.DataAnnotations;

namespace simple_todoapi.Models
{

    public class Todo
    {
        [Key] 
        public int Id {get;set;}
        [Required] 
        public String Name {get; set;}
        [Required] 
        public String Status {get; set;}
    }

}
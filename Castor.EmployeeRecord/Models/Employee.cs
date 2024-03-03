using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Castor.EmployeeRecord.Models
{
    [Table("Employee")]
    public class Employee
    {

        [Key]
        public int? id { get; set; }
        [Required]
        public int dni { get; set; }
        [Required]
        public string name { get; set; }
        public string? photo { get; set; }
        [Required]
        public int idPosition { get; set; }
        [NotMapped]
        public Position? Position { get; set; }

    }
}

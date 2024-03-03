using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Castor.EmployeeRecord.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public int idPosition { get; set; }
        public string name { get; set; }
        [NotMapped]
        public ICollection<Employee>? Employees { get; set;}
    }
}

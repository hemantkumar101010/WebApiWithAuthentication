using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDataLib.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int EmpId { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string? EmpName { get; set; }

        [Column(TypeName = "char(10)")]
        public string? EmpPhone { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string? EmpAddress { get; set; }

        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string? EmpEmail { get; set; }

        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string? Password { get; set; }

        [Required]
        public RoleType Role { get; set; }

    }

    public enum RoleType
    {
        Admin = 1,
        User,
        SalesMan
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumApbdNumer2.Models;
[Table("Employee")]
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = null!;

    [MaxLength(100)] public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public ICollection<Responsible> Responsibles { get; set; } = null!;
}
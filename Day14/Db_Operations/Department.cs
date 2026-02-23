using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    [Key]
    [Column("DEPTNO")]
    public int DeptNo { get; set; }

    [Column("DNAME")]
    public string? DName { get; set; }

    [Column("LOC")]
    public string? Loc { get; set; }

    // Navigation Property
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

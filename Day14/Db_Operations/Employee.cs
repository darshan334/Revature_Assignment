using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    [Column("EMPNO")]
    public int EmpNo { get; set; }

    [Column("ENAME")]
    public string? EName { get; set; }

    [Column("JOB")]
    public string? Job { get; set; }

    [Column("MGR")]
    public int? Mgr { get; set; }

    [Column("HIREDATE")]
    public DateTime HireDate { get; set; }

    [Column("SAL")]
    public decimal Sal { get; set; }

    [Column("COMM")]
    public decimal? Comm { get; set; }

    [Column("DEPTNO")]
    public int DeptNo { get; set; }

    // Navigation Property
    public Department? Department { get; set; }
}

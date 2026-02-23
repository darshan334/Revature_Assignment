using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        var employees = context.Employees
            .Include(e => e.Department)
            .ToList();

        foreach (var emp in employees)
        {
            Console.WriteLine(
                $"EmpNo: {emp.EmpNo}, Name: {emp.EName}, Dept: {emp.Department?.DName}");
        }
    }
}

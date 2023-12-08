using System.Collections.Generic;
using System.Reflection.Emit;
using TNTA_TEST.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
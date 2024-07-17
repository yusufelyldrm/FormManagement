using FormManagementWebApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FormManagementWebApp.Data;

public class FormDbContext : DbContext
{
    public FormDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Field> Fields { get; set; }
}
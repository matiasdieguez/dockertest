using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class DockerTestDbContext : DbContext
{
    public DbSet<Dummy> Dummies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle(@"Data Source=192.168.0.84:1521/XE;User Id=C##DOCKERTEST;Password=Tecnocode2022$");
    }
}

public class Dummy
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
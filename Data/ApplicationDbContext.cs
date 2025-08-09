using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using GestionGym.Models.Domain;
namespace GestionGym.Data;


public class ApplicationDbContext:IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }


    public DbSet<Member> Members { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Trainer> Trainers { get; set; }

    public DbSet<Class> Classes { get; set; }

}

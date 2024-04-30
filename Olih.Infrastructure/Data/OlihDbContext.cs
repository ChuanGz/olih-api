using Microsoft.EntityFrameworkCore;
using Olih.Domain.Entities;

namespace Olih.Infrastructure.Data;

public class OlihDbContext : DbContext
{
    public OlihDbContext(DbContextOptions<OlihDbContext> options) : base(options)
    {
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<BusinessPartner> BusinessPartners { get; set; }
    public DbSet<BusinessPlace> BusinessPlaces { get; set; }
    public DbSet<Product> Products { get; set; }
}

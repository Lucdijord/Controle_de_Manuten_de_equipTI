using ITMaintenanceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ITMaintenanceManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Tabelas no banco de dados
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MaintenanceTicket> MaintenanceTickets { get; set; }
    }
}
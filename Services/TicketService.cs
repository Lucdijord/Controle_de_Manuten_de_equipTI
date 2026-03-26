using ITMaintenanceManager.Data;
using ITMaintenanceManager.DTOs;
using ITMaintenanceManager.Models;
using ITMaintenanceManager.Strategies;
using Microsoft.EntityFrameworkCore;

namespace ITMaintenanceManager.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketResponseDTO?> CreateTicketAsync(TicketCreateDTO dto)
        {
            var equipment = await _context.Equipments.FindAsync(dto.EquipmentId);
            
            if (equipment == null) return null;

            var ticket = new MaintenanceTicket
            {
                Title = dto.Title,
                Description = dto.Description,
                EquipmentId = dto.EquipmentId
            };

            ISlaCalculationStrategy slaStrategy = equipment.Category.ToLower() switch
            {
                "servidor" => new ServerSlaStrategy(),
                "desktop" or "notebook" => new DesktopSlaStrategy(),
                _ => new PeripheralSlaStrategy()
            };

            ticket.SetSlaDeadline(slaStrategy);

            _context.MaintenanceTickets.Add(ticket);
            await _context.SaveChangesAsync();

            return new TicketResponseDTO(
                ticket.Id, ticket.Title, ticket.Description, ticket.Status, 
                ticket.OpenDate, ticket.Deadline, equipment.Name);
        }

        public async Task<IEnumerable<TicketResponseDTO>> GetAllTicketsAsync()
        {
            return await _context.MaintenanceTickets
                .Include(t => t.Equipment)
                .Select(t => new TicketResponseDTO(
                    t.Id, t.Title, t.Description, t.Status, 
                    t.OpenDate, t.Deadline, t.Equipment!.Name))
                .ToListAsync();
        }
    }
}
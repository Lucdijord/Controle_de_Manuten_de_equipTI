using ITMaintenanceManager.Data;
using ITMaintenanceManager.DTOs;
using ITMaintenanceManager.Models;
using ITMaintenanceManager.Strategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITMaintenanceManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceTicketController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintenanceTicketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketCreateDTO dto)
        {
            var equipment = await _context.Equipments.FindAsync(dto.EquipmentId);
            if (equipment == null)
            {
                return NotFound(new { message = "Equipamento não encontrado." });
            }

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

            var response = new TicketResponseDTO(
                ticket.Id, ticket.Title, ticket.Description, ticket.Status, 
                ticket.OpenDate, ticket.Deadline, equipment.Name);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _context.MaintenanceTickets
                .Include(t => t.Equipment) 
                .Select(t => new TicketResponseDTO(
                    t.Id, t.Title, t.Description, t.Status, 
                    t.OpenDate, t.Deadline, t.Equipment!.Name))
                .ToListAsync();

            return Ok(tickets);
        }
    }
}
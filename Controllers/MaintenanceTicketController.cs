using ITMaintenanceManager.DTOs;
using ITMaintenanceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITMaintenanceManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceTicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        // injetando Service invés do BD diretamente
        public MaintenanceTicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketCreateDTO dto)
        {
            var response = await _ticketService.CreateTicketAsync(dto);

            if (response == null)
            {
                return NotFound(new { message = "Equipamento não encontrado." });
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Service
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                return NotFound(new { message = "Chamado de manutenção não encontrado." });
            }

            return Ok(ticket);
        }
    }
}
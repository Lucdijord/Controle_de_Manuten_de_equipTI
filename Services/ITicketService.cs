using ITMaintenanceManager.DTOs;

namespace ITMaintenanceManager.Services
{
    public interface ITicketService
    {
        Task<TicketResponseDTO?> CreateTicketAsync(TicketCreateDTO dto);
        Task<IEnumerable<TicketResponseDTO>> GetAllTicketsAsync();
    }
}
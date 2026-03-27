using ITMaintenanceManager.DTOs;

namespace ITMaintenanceManager.Services
{
    public interface ITicketService
    {
        Task<TicketResponseDTO?> CreateTicketAsync(TicketCreateDTO dto);
        Task<IEnumerable<TicketResponseDTO>> GetAllTicketsAsync();
        Task<TicketResponseDTO?> GetTicketByIdAsync(int id);
        Task<TicketResponseDTO?> CloseTicketAsync(int id);
    }
}
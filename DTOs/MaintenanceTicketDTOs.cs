namespace ITMaintenanceManager.DTOs
{
    public record TicketCreateDTO(string Title, string Description, int EquipmentId);

    public record TicketResponseDTO(
        int Id, 
        string Title, 
        string Description, 
        string Status, 
        DateTime OpenDate, 
        DateTime Deadline, 
        string EquipmentName
    );
}
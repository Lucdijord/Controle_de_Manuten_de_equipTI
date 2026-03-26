namespace ITMaintenanceManager.DTOs
{
    public record EquipmentCreateDTO(string Name, string Category, DateTime PurchaseDate);

    public record EquipmentResponseDTO(int Id, string Name, string Category, DateTime PurchaseDate, bool IsActive);
}
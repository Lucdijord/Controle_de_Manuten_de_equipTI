namespace ITMaintenanceManager.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Ex: "Intel Core i5-11400F"
        public string Category { get; set; } = string.Empty; // Ex: "Processador", "Cooler", "Placa-mãe"
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Quando um equipamento tiver mais manutencoes
        public List<MaintenanceTicket> MaintenanceTickets { get; set; } = new();
    }
}
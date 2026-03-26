using ITMaintenanceManager.Strategies;

namespace ITMaintenanceManager.Models
{
    public class MaintenanceTicket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OpenDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; private set; } // O prazo calculado
        public DateTime? CloseDate { get; set; } 
        public string Status { get; set; } = "Aberto"; 

        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        // Strategy
        public void SetSlaDeadline(ISlaCalculationStrategy slaStrategy)
        {
            // Define o cálculo para a estratégia injetada
            this.Deadline = slaStrategy.CalculateDeadline(this.OpenDate);
        }
    }
}
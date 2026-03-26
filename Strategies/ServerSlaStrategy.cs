namespace ITMaintenanceManager.Strategies
{
    public class ServerSlaStrategy : ISlaCalculationStrategy
    {
        public DateTime CalculateDeadline(DateTime openDate)
        {
            return openDate.AddHours(4); // Servidores
        }
    }
}
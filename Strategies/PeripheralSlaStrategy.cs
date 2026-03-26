namespace ITMaintenanceManager.Strategies
{
    public class PeripheralSlaStrategy : ISlaCalculationStrategy
    {
        public DateTime CalculateDeadline(DateTime openDate)
        {
            return openDate.AddHours(48); // Periféricos
        }
    }
}
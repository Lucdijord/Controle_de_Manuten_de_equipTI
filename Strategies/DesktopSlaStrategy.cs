namespace ITMaintenanceManager.Strategies
{
    public class DesktopSlaStrategy : ISlaCalculationStrategy
    {
        public DateTime CalculateDeadline(DateTime openDate)
        {
            return openDate.AddHours(24); //PCs
        }
    }
}
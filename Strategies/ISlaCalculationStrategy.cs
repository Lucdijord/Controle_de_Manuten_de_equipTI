namespace ITMaintenanceManager.Strategies
{
    public interface ISlaCalculationStrategy
    {
        DateTime CalculateDeadline(DateTime openDate);
    }
}
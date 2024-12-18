using CNCSwebApiProject.Dto;
using static CNCSwebApiProject.Dto.ChartsDto;

public interface IWorkloadStatisticsService
{

    Task<IEnumerable<TransactionDto>> GetWorkloadStatistics();
    Task<ProductSummaryChartDto> GetProductSummaryChartData(DateTime startDate, DateTime endDate);
    Task<ProductSummaryChartTotalDto> GetProductSummaryChartTotal(DateTime startDate, DateTime endDate);
    Task<TransactionPerDayDto> GetTransactionPerDay(DateTime startDate, DateTime endDate);
    Task<UserCountSummaryChartDto> GetUserCountChartData(DateTime startDate, DateTime endDate);
    Task<UserCountSummaryChartDto> GetUserCountChartTotal();
    Task<DescriptionTableDto> GetDescriptionTable(DateTime startDate, DateTime endDate);

}

using CNCSwebApiProject.Dto;
using static CNCSwebApiProject.Dto.ChartsDto;

namespace CNCSwebApiProject.Services.WorkloadStatistics
{
    public interface IWorkloadStatisticsService
    {
        Task<IEnumerable<TransactionDto>> GetWorkloadStatistics();
        Task<ProductSummaryChartDto> GetProductSummaryChartData();
        Task<ProductSummaryChartTotalDto> GetProductSummaryChartTotal();
        Task<TransactionPerDayDto> GetTransactionPerDay();
        Task<UserCountSummaryChartDto> GetUserCountChartData();
        Task<UserCountSummaryChartDto> GetUserCountChartTotal();
        Task<DescriptionTableDto> GetDescriptionTable();
    }
}

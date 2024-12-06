using CNCSwebApiProject.Dto;
using static CNCSwebApiProject.Dto.ChartsDto;

namespace CNCSwebApiProject.Services.WorkloadStatistics
{
    public interface IWorkloadStatisticsService
    {
        Task<IEnumerable<TransactionDto>> GetWorkloadStatistics();
        Task<ProductSummaryChartDto> GetProductSummaryChartData();
        Task<UserCountSummaryChartDto> GetUserCountChartData();
    }
}

using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static CNCSwebApiProject.Dto.ChartsDto;

namespace CNCSwebApiProject.Services.WorkloadStatistics
{
    public class WorkloadStatisticsService : IWorkloadStatisticsService
    {
        private readonly CncssystemContext _dbContext;

        public WorkloadStatisticsService(CncssystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductSummaryChartDto> GetProductSummaryChartData()
        {
            var data = await _dbContext.TblTransactions
                .Where(t => t.IsDeleted == false) // Exclude deleted transactions
                .GroupBy(t => t.ProductVendor.ProductVendor) // Group by ProductVendor name
                .Select(g => new { Label = g.Key, Y = g.Count() }) // Counting the number of transactions per vendor
                .ToListAsync();

            return new ProductSummaryChartDto
            {
                DataPoints = data.Select(d => new ChartDataPoint
                {
                    Label = d.Label,
                    Y = d.Y
                }).ToList()
            };
        }

        public async Task<UserCountSummaryChartDto> GetUserCountChartData()
        {
            var data = await _dbContext.TblTransactions
                .Where(t => t.IsDeleted == false)
                .GroupBy(t => t.RepliedBy) // Group by user
                .Select(g => new
                {
                    User = g.Key,
                    CallCount = g.Count(t => t.TransactionType == "Phone"),
                    MailCount = g.Count(t => t.TransactionType == "Email")
                })
                .ToListAsync();

            return new UserCountSummaryChartDto
            {
                DataPoints = data.Select(d => new UserChartDataPoint
                {
                    User = d.User,
                    CallCount = d.CallCount,
                    MailCount = d.MailCount
                }).ToList()
            };
        }

        public Task<IEnumerable<TransactionDto>> GetWorkloadStatistics()
        {          
            throw new NotImplementedException();
        }
    }
}

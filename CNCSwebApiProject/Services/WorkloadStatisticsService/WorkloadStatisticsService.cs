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

        public async Task<DescriptionTableDto> GetDescriptionTable()
        {
            var data = await _dbContext.TblTransactions
                .Where(t => t.IsDeleted == false) // Exclude deleted transactions
               .Include(p => p.ProductVendor)
                .Include(t => t.Description)
               .GroupBy(t => t.ProductVendor.ProductVendor) // Group by product vendor
               .Select(g => new
               {
                   Product = g.Key,
                   CallTotal = g.Count(t => t.TransactionType == "Phone"),
                   EmailTotal = g.Count(t => t.TransactionType == "Email"),
                   QQCount = g.Count(t => t.TransactionType == "QQ")
               })
               .ToListAsync();

            return new DescriptionTableDto
            {
                DataPoints = data.Select(d => new DescriptionDataPoint
                {
                    Description = d.Product,
                    CallCount = d.CallTotal,
                    EMailCount = d.EmailTotal,
                    QQCount = d.QQCount,
                    Total = d.CallTotal + d.EmailTotal + d.QQCount
                }).ToList()
            };
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

        public async Task<ProductSummaryChartTotalDto> GetProductSummaryChartTotal()
        {
            var data = await _dbContext.TblTransactions
                 .Where(t => t.IsDeleted == false) // Exclude deleted transactions
                 .Include(p => p.ProductVendor)
                 .Include(t => t.Description)
                .GroupBy(t => t.ProductVendor.ProductVendor) // Group by product vendor
                .Select(g => new
                {
                    Product = g.Key,
                    CallTotal = g.Count(t => t.TransactionType == "Phone"),
                    EmailTotal = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ")
                })
                .ToListAsync();

            return new ProductSummaryChartTotalDto
            {
                DataPoints = data.Select(d => new ChartDataTableTotalDataPoint
                {
                    Product = d.Product,
                    CallTotal = d.CallTotal,
                    EmailTotal = d.EmailTotal,
                    QQCount = d.QQCount,
                    Total = d.CallTotal + d.EmailTotal + d.QQCount
                }).ToList()
            };
        }
        public async Task<TransactionPerDayDto> GetTransactionPerDay()
        {
            var data = await _dbContext.TblTransactions
                .Where(t => t.IsDeleted == false) // Exclude deleted transactions
                .GroupBy(t => t.DateAdded.Value.Day) // Extract day value
                .Select(g => new
                {
                    Day = g.Key,
                    CallTotal = g.Count(t => t.TransactionType == "Phone"),
                    EmailTotal = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ"),
                    Total = g.Count()
                })
                .ToListAsync();

            return new TransactionPerDayDto
            {
                DataPoints = data.Select(d => new TransactionPerDayDataPoint
                {
                    Day = d.Day,
                    CallTotal = d.CallTotal,
                    EmailTotal = d.EmailTotal,
                    QQCount = d.QQCount,
                    Total = d.Total
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
                    MailCount = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t=> t.TransactionType == "QQ"),
                    Total = g.Count()
                    
                })
                .ToListAsync();

            return new UserCountSummaryChartDto
            {
                DataPoints = data.Select(d => new UserChartDataPoint
                {
                    User = d.User,
                    CallCount = d.CallCount,
                    EMailCount = d.MailCount,
                    QQCount = d.QQCount,
                    Total = d.Total
                }).ToList()
            };
        }

        public Task<UserCountSummaryChartDto> GetUserCountChartTotal()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionDto>> GetWorkloadStatistics()
        {          
            throw new NotImplementedException();
        }
          
     
    }
}

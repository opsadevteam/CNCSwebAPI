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

        public async Task<DescriptionTableDto> GetDescriptionTable(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.TblTransactions
                .Where(t => !t.IsDeleted &&
                    t.TakeOffDate.HasValue &&
                    t.TakeOffDate.Value.Date >= startDate.Date &&
                    t.TakeOffDate.Value.Date <= endDate.Date)
                .Include(t => t.ProductVendor)
                .GroupBy(t => new { t.ProductVendor.ProductVendor, t.TakeOffDate })
                .Select(g => new
                {
                    Product = g.Key.ProductVendor,
                    CallTotal = g.Count(t => t.TransactionType == "Phone"),
                    EmailTotal = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ"),
                    TakeOffDate = g.Key.TakeOffDate
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
                    Total = d.CallTotal + d.EmailTotal + d.QQCount,
                    TakeOffDate = d.TakeOffDate.HasValue ? DateOnly.FromDateTime(d.TakeOffDate.Value) : null
                }).ToList()
            };
        }

        public async Task<ProductSummaryChartDto> GetProductSummaryChartData(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.TblTransactions
                .Where(t => !t.IsDeleted &&
                    t.TakeOffDate.HasValue &&
                    t.TakeOffDate.Value.Date >= startDate.Date &&
                    t.TakeOffDate.Value.Date <= endDate.Date)
                .GroupBy(t => new { t.ProductVendor.ProductVendor, TakeOffDate = t.TakeOffDate.Value.Date })
                .Select(g => new
                {
                    Label = g.Key.ProductVendor,
                    Y = g.Count(),
                    TakeOffDate = g.Key.TakeOffDate
                })
                .ToListAsync();

            return new ProductSummaryChartDto
            {
                DataPoints = data.Select(d => new ChartDataPoint
                {
                    Label = d.Label,
                    Y = d.Y,
                    TakeOffDate = DateOnly.FromDateTime(d.TakeOffDate)
                }).ToList()
            };
        }

        public async Task<ProductSummaryChartTotalDto> GetProductSummaryChartTotal(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.TblTransactions
                .Where(t => !t.IsDeleted &&
                    t.TakeOffDate.HasValue &&
                    t.TakeOffDate.Value.Date >= startDate.Date &&
                    t.TakeOffDate.Value.Date <= endDate.Date)
                .Include(p => p.ProductVendor)
                .GroupBy(t => new { t.ProductVendor.ProductVendor, t.TakeOffDate })
                .Select(g => new
                {
                    Product = g.Key.ProductVendor,
                    CallTotal = g.Count(t => t.TransactionType == "Phone"),
                    EmailTotal = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ"),
                    TakeOffDate = g.Key.TakeOffDate
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
                    Total = d.CallTotal + d.EmailTotal + d.QQCount,
                    TakeOffDate = d.TakeOffDate.HasValue ? DateOnly.FromDateTime(d.TakeOffDate.Value) : null
                }).ToList()
            };
        }

        public async Task<TransactionPerDayDto> GetTransactionPerDay(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.TblTransactions
                .Where(t => !t.IsDeleted &&
                    t.TakeOffDate.HasValue &&
                    t.TakeOffDate.Value.Date >= startDate.Date &&
                    t.TakeOffDate.Value.Date <= endDate.Date)
                .GroupBy(t => new { t.ProductVendor.ProductVendor, t.TakeOffDate })
                .Select(g => new
                {
                    Day = g.Key.TakeOffDate.Value.Day,
                    CallTotal = g.Count(t => t.TransactionType == "Phone"),
                    EmailTotal = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ"),
                    Total = g.Count(),
                    TakeOffDate = g.Key.TakeOffDate
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
                    Total = d.Total,
                    TakeOffDate = d.TakeOffDate.HasValue ? DateOnly.FromDateTime(d.TakeOffDate.Value) : null
                }).ToList()
            };
        }

        public async Task<UserCountSummaryChartDto> GetUserCountChartData(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.TblTransactions
                .Where(t => !t.IsDeleted &&
                    t.TakeOffDate.HasValue &&
                    t.TakeOffDate.Value.Date >= startDate.Date &&
                    t.TakeOffDate.Value.Date <= endDate.Date)
                .GroupBy(t => new { t.RepliedBy, t.TakeOffDate })
                .Select(g => new
                {
                    User = g.Key.RepliedBy,
                    CallCount = g.Count(t => t.TransactionType == "Phone"),
                    MailCount = g.Count(t => t.TransactionType == "Email"),
                    QQCount = g.Count(t => t.TransactionType == "QQ"),
                    Total = g.Count(),
                    TakeOffDate = g.Key.TakeOffDate
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
                    Total = d.Total,
                    TakeOffDate = d.TakeOffDate.HasValue ? DateOnly.FromDateTime(d.TakeOffDate.Value) : null
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

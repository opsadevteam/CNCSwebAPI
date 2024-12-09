using CNCSwebApiProject.Services.WorkloadStatistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static CNCSwebApiProject.Dto.ChartsDto;

namespace CNCSwebApiProject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkloadStatisticsController : ControllerBase
    {
        private readonly IWorkloadStatisticsService _workloadStatisticsService;

        public WorkloadStatisticsController(IWorkloadStatisticsService workloadStatisticsService)
        {
            _workloadStatisticsService = workloadStatisticsService;
        }

        // GET api/v1/workloadstatistics/productsummary
        [HttpGet("productsummary")]
        public async Task<IActionResult> GetProductSummaryChartData()
        {
            var data = await _workloadStatisticsService.GetProductSummaryChartData();
            return Ok(data);
        }

        // GET api/v1/workloadstatistics/productsummary/total
        [HttpGet("productsummary/total")]
        public async Task<IActionResult> GetProductSummaryChartTotal()
        {
            var data = await _workloadStatisticsService.GetProductSummaryChartTotal();
            return Ok(data);
        }

        // GET api/v1/workloadstatistics/usercount
        [HttpGet("usercount")]
        public async Task<IActionResult> GetUserCountChartData()
        {
            var data = await _workloadStatisticsService.GetUserCountChartData();
            return Ok(data);
        }

        // WorkloadStatisticsController.cs
        [HttpGet("transactionperday")]
        public async Task<IActionResult> GetTransactionPerDay()
        {
            var data = await _workloadStatisticsService.GetTransactionPerDay();
            return Ok(data); // Return grouped data by day
        }

        // Endpoint to fetch the description table
        [HttpGet("description-table")]
        public async Task<ActionResult<DescriptionTableDto>> GetDescriptionTable()
        {
            try
            {
                var result = await _workloadStatisticsService.GetDescriptionTable();
                return Ok(result); // Return the result as a 200 OK response
            }
            catch (Exception ex)
            {
                // Log error (for example, using a logging framework like Serilog or NLog)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}

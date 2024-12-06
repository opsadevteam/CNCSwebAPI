using CNCSwebApiProject.Services.WorkloadStatistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return Ok(data); // Return Product Summary Chart data
        }

        // GET api/v1/workloadstatistics/usercount
        [HttpGet("usercount")]
        public async Task<IActionResult> GetUserCountChartData()
        {
            var data = await _workloadStatisticsService.GetUserCountChartData();
            return Ok(data); // Return User Count Chart data
        }

        // Optionally, you can add other chart-related endpoints here.
    }
}

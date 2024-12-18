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
        public async Task<IActionResult> GetProductSummaryChartData(DateTime startDate, DateTime endDate)
        {
            var data = await _workloadStatisticsService.GetProductSummaryChartData(startDate, endDate);
            return Ok(data);
        }

        //[HttpGet("productsummary")]
        //public async Task<IActionResult> GetProductSummaryChartData([FromQuery] string startDate, [FromQuery] string endDate)
        //{
        //    try
        //    {
        //        DateTime parsedStartDate = _workloadStatisticsService.ParseDateTime(startDate);
        //        DateTime parsedEndDate = _workloadStatisticsService.ParseDateTime(endDate);

        //        var result = await _workloadStatisticsService.GetProductSummaryChartData(parsedStartDate, parsedEndDate);
        //        return Ok(result);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message); // Return error if date format is invalid
        //    }
        //}


        // GET api/v1/workloadstatistics/productsummary/total
        [HttpGet("productsummary/total")]
        public async Task<IActionResult> GetProductSummaryChartTotal(DateTime startDate, DateTime endDate)
        {
            var data = await _workloadStatisticsService.GetProductSummaryChartTotal(startDate, endDate);
            return Ok(data);
        }

        // GET api/v1/workloadstatistics/usercount
        [HttpGet("usercount")]
        public async Task<IActionResult> GetUserCountChartData(DateTime startDate, DateTime endDate)
        {
            var data = await _workloadStatisticsService.GetUserCountChartData(startDate, endDate);
            return Ok(data);
        }

        // GET api/v1/workloadstatistics/transactionperday
        [HttpGet("transactionperday")]
        public async Task<IActionResult> GetTransactionPerDay(DateTime startDate, DateTime endDate)
        {
            var data = await _workloadStatisticsService.GetTransactionPerDay(startDate, endDate);
            return Ok(data);
        }

        // GET api/v1/workloadstatistics/description-table
        [HttpGet("description-table")]
        public async Task<ActionResult<DescriptionTableDto>> GetDescriptionTable(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _workloadStatisticsService.GetDescriptionTable(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

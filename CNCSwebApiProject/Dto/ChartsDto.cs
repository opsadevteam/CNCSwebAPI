namespace CNCSwebApiProject.Dto
{
    public class ChartsDto
    {
        public class ProductSummaryChartDto
        {
            public List<ChartDataPoint> DataPoints { get; set; } = new();
        }

        public class UserCountSummaryChartDto
        {
            public List<UserChartDataPoint> DataPoints { get; set; } = new();
        }

        public class ChartDataPoint
        {
            public string Label { get; set; }
            public int Y { get; set; }
        }

        public class UserChartDataPoint
        {
            public string User { get; set; }
            public int CallCount { get; set; }
            public int MailCount { get; set; }
        }

    }

}

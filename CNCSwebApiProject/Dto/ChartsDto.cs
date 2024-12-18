namespace CNCSwebApiProject.Dto
{
    public class ChartsDto
    {
        public class ProductSummaryChartDto
        {
            public List<ChartDataPoint> DataPoints { get; set; } = new();
        }

        public class ProductSummaryChartTotalDto
        {
            public List<ChartDataTableTotalDataPoint> DataPoints { get; set; } = new();
        }

        public class UserCountSummaryChartDto
        {
            public List<UserChartDataPoint> DataPoints { get; set; } = new();
        }

        public class TransactionPerDayDto
        {
            public List<TransactionPerDayDataPoint> DataPoints { get; set; } = new();
        }

        public class DescriptionTableDto
        {
            public List<DescriptionDataPoint> DataPoints { get; set; } = new();
        }

        public class ChartDataPoint
        {
            public string Label { get; set; }
            public int Y { get; set; }
            public DateOnly? TakeOffDate { get; set; }
        }


        public class ChartDataTableTotalDataPoint
        {
            public string Product { get; set; }
            public int CallTotal { get; set; }
            public int EmailTotal { get; set; }
            public int QQCount { get; set; }
            public int Total { get; set; }
            public DateOnly? TakeOffDate { get; set; }
        }

        public class TransactionPerDayDataPoint
        {
            public int Day { get; set; }
            public int CallTotal { get; set; }
            public int EmailTotal { get; set; }
            public int QQCount { get; set; }
            public int Total { get; set; }
            public DateOnly? TakeOffDate { get; set; }
        }


        public class UserChartDataPoint
        {
            public string User { get; set; }
            public int CallCount { get; set; }
            public int EMailCount { get; set; }
            public int QQCount { get; set; }
            public int Total { get; set; }
            public DateOnly? TakeOffDate { get; set; }
        }

        public class DescriptionDataPoint
        {
            public string Description { get; set; }
            public int CallCount { get; set; }
            public int EMailCount { get; set; }
            public int QQCount { get; set; }
            public int Total { get; set; }
            public DateOnly? TakeOffDate { get; set; }
        }

    }

}

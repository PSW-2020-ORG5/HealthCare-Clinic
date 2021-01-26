namespace IntegrationAdapters.Dtos
{
    public class PeriodDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public PeriodDto()
        {
        }

        public PeriodDto(string startDate, string endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}

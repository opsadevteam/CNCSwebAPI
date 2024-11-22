namespace CNCSwebApiProject.Dto
{
    public class ProductVendorDto
    {
        public int Id { get; set; }

        public string? ProductVendor { get; set; }

        public string? AddedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public bool? IsDeleted { get; set; }

        public string? LogId { get; set; }
    }
}

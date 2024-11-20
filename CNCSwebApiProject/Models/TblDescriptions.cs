using System;
using System.Collections.Generic;

namespace CNCSwebApiProject.Models;

public partial class TblDescriptions
{
    public int Id { get; set; }

    public int? ProductVendorId { get; set; }

    public string? Description { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LogId { get; set; }

    public virtual TblProductVendor? ProductVendor { get; set; }

    public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; } = new List<TblTransactionLogs>();

    public virtual ICollection<TblTransactions> TblTransactions { get; set; } = new List<TblTransactions>();
}

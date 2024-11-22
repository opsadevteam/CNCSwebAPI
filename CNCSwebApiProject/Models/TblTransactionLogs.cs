using System;
using System.Collections.Generic;

namespace CNCSwebApiProject.Models;

public partial class TblTransactionLogs
{
    public int Id { get; set; }

    public string? TransactionId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? PickUpDate { get; set; }

    public DateTime? TakeOffDate { get; set; }

    public long? Duration { get; set; }

    public int? ProductVendorId { get; set; }

    public int? DescriptionId { get; set; }

    public string? Remark { get; set; }

    public string? RepliedBy { get; set; }

    public string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? Shift { get; set; }

    public string? TransactionType { get; set; }

    public string? LogId { get; set; }

    public string? LogBy { get; set; }

    public DateTime? LogDate { get; set; }

    public string? LogType { get; set; }

    public virtual TblDescriptions? Description { get; set; }

    public virtual TblProductVendor? ProductVendor { get; set; }
}

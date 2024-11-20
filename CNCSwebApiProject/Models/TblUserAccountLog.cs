using System;
using System.Collections.Generic;

namespace CNCSwebApiProject.Models;

public partial class TblUserAccountLog
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserGroup { get; set; }

    public string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? LogId { get; set; }

    public string? LogType { get; set; }

    public string? LogUser { get; set; }

    public DateTime? LogDate { get; set; }
}

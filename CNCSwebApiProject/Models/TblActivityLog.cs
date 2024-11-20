using System;
using System.Collections.Generic;

namespace CNCSwebApiProject.Models;

public partial class TblActivityLog
{
    public int Id { get; set; }

    public string? LogActivity { get; set; }

    public string? LogUser { get; set; }

    public DateTime? LogTime { get; set; }

    public string? LogDetails { get; set; }

    public string? LogLocation { get; set; }

    public string? UserGroup { get; set; }
}

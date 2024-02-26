using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string? ReportContent { get; set; }
        public int? Product { get; set; }
        public int? ReportBy { get; set; }

        public virtual Product? ProductNavigation { get; set; }
        public virtual User? ReportByNavigation { get; set; }
    }
}

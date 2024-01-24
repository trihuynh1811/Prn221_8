using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public class Report
    {
        [Key]
        [Column("report_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }

        public string? ReportContent { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey("Product")]
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
    }
}

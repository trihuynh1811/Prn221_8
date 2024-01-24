using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public bool Status { get; set; } = true;

        [JsonIgnore]
        public ICollection<Report>? ReportSet { get; set; }

        [JsonIgnore]
        public ICollection<Auction>? AuctionSet { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetail>? OrderDetailsSet { get; set; }
    }
}


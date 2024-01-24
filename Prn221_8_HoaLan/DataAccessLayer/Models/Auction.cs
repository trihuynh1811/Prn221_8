using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public class Auction
    {
        [Key]
        [Column("auction_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuctionId { get; set; }

        public string? AuctionName { get; set; }

        public bool Status { get; set; } = true;

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public ICollection<AuctionDetail>? AuctionDetailsSet { get; set; }

    }
}

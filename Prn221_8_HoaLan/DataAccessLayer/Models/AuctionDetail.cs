using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public class AuctionDetail
    {
        [Key]
        [Column("auction_detail_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuctionDetailId { get; set; }

        [Column("Host")]
        [JsonIgnore]
        public int HostId { get; set; }

        [Column("Winner")]
        [JsonIgnore]
        public int WinnerId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey("AuctionId")]
        [JsonIgnore]
        public int AuctionId { get; set; }

        [JsonIgnore]
        public Auction? Auction { get; set; }
    }
}

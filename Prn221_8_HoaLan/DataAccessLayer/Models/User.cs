using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? UserEmail { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool Status { get; set; } = true;

        [ForeignKey("Role")]
        [Column("Role")]
        [JsonIgnore]
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }

        [JsonIgnore]
        public ICollection<Report>? ReportSet { get; set; }

        [JsonIgnore]
        public ICollection<Order>? OrderSet { get; set; }

        [JsonIgnore]
        public ICollection<AuctionDetail>? AuctionParticipant { get; set; }


    }
}

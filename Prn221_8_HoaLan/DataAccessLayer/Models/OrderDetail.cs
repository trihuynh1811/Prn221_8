using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
    public class OrderDetail
    {
        [Key]
        [Column("order_detail_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore]
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }        
        
        [ForeignKey("ProductId")]
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}

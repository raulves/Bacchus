using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class Bid : DomainEntityId
    {
        public Guid ItemId { get; set; }
        
        [MinLength(1)]
        [MaxLength(64)]
        public string ItemName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(64)]
        [Required]
        public string UserName { get; set; } = default!;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BidAmount { get; set; } = default!;
        
        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ItemEndDate { get; set; }
    }
}
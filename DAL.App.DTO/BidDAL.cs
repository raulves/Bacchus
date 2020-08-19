using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace DAL.App.DTO
{
    public class BidDAL : DomainEntityId
    {
        public Guid ItemId { get; set; }
        
        public string ItemName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(64)]
        public string UserName { get; set; } = default!;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal BidAmount { get; set; } = default!;
        
        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ItemEndDate { get; set; }
    }
}
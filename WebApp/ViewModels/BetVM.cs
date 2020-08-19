using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class BetVM
    {
        public Guid ItemId { get; set; }
        
        [MinLength(1)]
        [MaxLength(64)]
        [Display(Name = "Item name:")]
        public string ItemName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(64)]
        [Required]
        [Display(Name = "Username:")]
        public string UserName { get; set; } = default!;

        [Required]
        [Display(Name = "Bet:")]
        [Range(0, 10000, ErrorMessage = "Bid price should be in range of {0} to {1}.")]
        public decimal BidAmount { get; set; }
        
        [Display(Name = "Bid date:")]
        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }
    }
}
using System;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ItemBLL : DomainEntityId
    {
        public string ItemName { get; set; } = default!;
        
        public string ItemDescription { get; set; } = default!;
        
        public string ItemCategory { get; set; } = default!;

        public DateTime BiddingEndDate { get; set; }
        
        public string TimeLeft { get; set; } = default!;
    }
}
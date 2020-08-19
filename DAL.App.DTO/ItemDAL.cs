using System;
using Domain.Base;

namespace DAL.App.DTO
{
    public class ItemDAL : DomainEntityId
    {
        public string ItemName { get; set; } = default!;
        
        public string ItemDescription { get; set; } = default!;
        
        public string ItemCategory { get; set; } = default!;

        public DateTime BiddingEndDate { get; set; }
        
        public string TimeLeft { get; set; } = default!;

    }
}
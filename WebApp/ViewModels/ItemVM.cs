using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Domain.Base;

namespace WebApp.ViewModels
{
    public class ItemVM : DomainEntityId
    {
        public string ItemName { get; set; } = default!;
        
        public string ItemDescription { get; set; } = default!;
        
        public string ItemCategory { get; set; } = default!;

        public DateTime BiddingEndDate { get; set; }
        
        public string TimeLeft { get; set; } = default!;
    }
}
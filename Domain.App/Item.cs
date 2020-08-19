using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Domain.Base;

namespace Domain.App
{
    public class Item : DomainEntityId
    {
        [JsonPropertyName("productId")]
        public override Guid Id { get; set; }

        [JsonPropertyName("productName")]
        public string ItemName { get; set; } = default!;
        
        [JsonPropertyName("productDescription")]
        public string ItemDescription { get; set; } = default!;
        
        [JsonPropertyName("productCategory")]
        public string ItemCategory { get; set; } = default!;
        
        [JsonPropertyName("biddingEndDate")]
        public string JsonDate { get; set; } = default!;
        
        public DateTime BiddingEndDate =>
            DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.CurrentCulture);

        public string TimeLeft => GetTimeLeft();

        public string GetTimeLeft()
        {
            var timeLeft = BiddingEndDate.Subtract(DateTime.Now);
            var result = "";
            if (timeLeft.Days > 0)
            {
                result += timeLeft.Days == 1 ? timeLeft.Days + " day " : timeLeft.Days + " days ";
            }

            if (timeLeft.Hours > 0)
            {
                result += timeLeft.Hours == 1 ? timeLeft.Hours + " hour " : timeLeft.Hours + " hours ";
            }

            if (timeLeft.Minutes > 0)
            {
                result += timeLeft.Minutes == 1 ? timeLeft.Minutes + " minute " : timeLeft.Minutes + " minutes ";
            }

            if (timeLeft.Seconds > 0)
            {
                result += timeLeft.Seconds == 1 ? timeLeft.Seconds + " second " : timeLeft.Seconds + " seconds ";
            }

            return result;
        }

    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ShowItemsVM
    {
        public IEnumerable<ItemVM>? Items { get; set; }
        public SelectList? CategorySelectList { get; set; }

        public string? Category { get; set; }
        public string? Search { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels;
using WebApp.ViewModels.Mappers;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppBLLHttpClient _bll;
        private readonly ItemVMMapper _mapper = new ItemVMMapper();
        
        public HomeController(IAppBLLHttpClient bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index(ShowItemsVM vm, string? message)
        {
            if (message != null)
            {
                ModelState.AddModelError("message", message);
            }
            
            vm.Items = (await _bll.Items.GetItemsForViewAsync(vm.Category, vm.Search)).Select(e => _mapper.Map(e));
            var categories = _bll.Items.GetAllAsync().Result.Select(a => a.ItemCategory).Distinct().OrderBy(a => a.Substring(0, 1)).ToList();
            vm.CategorySelectList = new SelectList(categories);
            return View(vm);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
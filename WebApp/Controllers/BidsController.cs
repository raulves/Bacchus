using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using WebApp.ViewModels.Mappers;

namespace WebApp.Controllers
{
    public class BidsController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly IAppBLLHttpClient _bllHttpClient;
        private readonly BidVMMapper _mapper = new BidVMMapper();
        
        public BidsController(IAppBLL bll, IAppBLLHttpClient bllHttpClient)
        {
            _bll = bll;
            _bllHttpClient = bllHttpClient;
        }
        
        // GET: Bids
        public async Task<IActionResult> Index()
        {
            return View((await _bll.Bids.GetAllAsync()).Select(e => _mapper.Map(e)));

        }

        // GET: Bids/Create
        public async Task<IActionResult> Create(Guid id)
        {
            var item = await _bllHttpClient.Items.FirstOrDefaultAsync(id);
            
            if (item == null)
            {
                return RedirectToAction("Index", "Home", new {message = "Item is no longer available!"});
            }
            
            var vm = new BetVM()
            {
                ItemId = id,
                ItemName = item.ItemName
            };
            return View(vm);
        }
        
        // POST: Bids/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BetVM vm)
        {
            var item = await _bllHttpClient.Items.FirstOrDefaultAsync(vm.ItemId);
            
            if (item == null)
            {
                return RedirectToAction("Index", "Home", new {message = "Item is no longer available!"});
            }
            
            if (ModelState.IsValid)
            {
                var bllEntity = _mapper.Map(vm);
                bllEntity.ItemEndDate = item.BiddingEndDate;
                bllEntity.BidDate = DateTime.Now;
                _bll.Bids.Add(bllEntity);
                await _bll.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(vm);
        }
    }
}
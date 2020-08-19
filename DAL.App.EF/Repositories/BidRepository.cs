using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BidRepository : EFBaseRepository<AppDbContext, Bid, BidDAL>, IBidRepository
    {
        private const int BidsHistoryDays = 5;
        public BidRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Bid, BidDAL>())
        {
            
        }

        public override async Task<IEnumerable<BidDAL>> GetAllAsync()
        {
            // p.ItemEndDate.AddDays(BidsHistoryDays) > DateTime.Now && 
            var query = RepoDbSet
                .Where(p => p.ItemEndDate < DateTime.Now && p.ItemEndDate.AddDays(BidsHistoryDays) > DateTime.Now)
                .OrderBy(b => b.ItemName)
                .ThenByDescending(b => b.BidAmount);
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
    }
}
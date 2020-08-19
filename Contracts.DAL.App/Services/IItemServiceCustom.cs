using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Services
{
    public interface IItemServiceCustom : IItemServiceCustom<ItemDAL>
    {
        
    }
    
    public interface IItemServiceCustom<TItemDAL>
    {
        Task<IEnumerable<TItemDAL>> GetItemsForViewAsync(string? category, string? search);
    }
}
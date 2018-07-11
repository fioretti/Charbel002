using System.Collections.Generic;
using System.Threading.Tasks;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Contracts.Services.Data
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync();
    }
}

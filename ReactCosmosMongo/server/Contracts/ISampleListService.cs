using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMongo.Models;

namespace WebApiMongo.Contracts
{
    public interface ISampleListService
    {
        Task<ListItem> AddItemAsync(ListItem item);
        Task<long> DeleteItemAsync(string id);
        Task<IEnumerable<ListItem>> GetItemsAsync();
    }
}
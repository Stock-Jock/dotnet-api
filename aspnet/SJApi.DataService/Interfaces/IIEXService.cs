using System.Collections;
using System.Threading.Tasks;

namespace SJApi.DataService.Interfaces
{
    public interface IIEXService
    {
        Task<IEnumerable> RetrieveSymbolsIEX();
    }
}
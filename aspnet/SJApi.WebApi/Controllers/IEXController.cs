using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SJApi.DataService.Interfaces;

namespace SJApi.WebApi.Controllers
{
    /// </summary>
    /// Handles retrieval of data from IEX api
    /// </summary>
    [ApiController]
    [Route("rest/stockjock/[controller]")]
    public class IEXController : ControllerBase
    {
        private readonly IIEXService _iex;
        public IEXController(IIEXService iex)
        {
            _iex = iex;
        }

        /// </summary>
        /// Retrieves all stock symbols from IEX
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSymbols() =>
            Ok(await _iex.RetrieveSymbols());
    }
}
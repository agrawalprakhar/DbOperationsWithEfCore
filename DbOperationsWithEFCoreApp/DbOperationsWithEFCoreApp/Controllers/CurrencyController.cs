using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public IActionResult GetAllCurencies() 
        {
            //var result = _appDbContext.Currencies.ToList();
            var result = (from currencies in  _appDbContext.Currencies
                         select currencies).ToList();

            return Ok(result);
        }
    }
}

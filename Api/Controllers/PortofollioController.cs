using Api.Extensions;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/portofolio")]
    [ApiController]
    public class PortofollioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortofolioRepository _portofolioRepository;

        public PortofollioController(UserManager<AppUser> userManager, 
            IStockRepository stockRepository,
            IPortofolioRepository portofolioRepository)
        {
            this._userManager = userManager;
            this._stockRepository = stockRepository;
            this._portofolioRepository = portofolioRepository;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortofolio()
        {
            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);
            var userPortofolio = await this._portofolioRepository.GetUserPortofolio(appUser);

            return Ok(userPortofolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortofolio([FromBody] string symbol)
        {
            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);
            var stock = await this._stockRepository.GetBySymbol(symbol);

            if (stock is null)
            {
                return NotFound();
            }

            var userPortofolio = await this._portofolioRepository.GetUserPortofolio(appUser);

            if (userPortofolio.Any(x => x.Symbol.Equals(symbol)))
            {
                return BadRequest("Cannot add same stock to portofolio");
            }

            var portofolio = new Portofolio()
            {
                AppUserId = appUser.Id,
                StockId = stock.Id,
            };

            await _portofolioRepository.CreatePortofolioAsync(portofolio);
            return Ok();
        }
    }
}

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

    }
}

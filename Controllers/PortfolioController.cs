using CArch_V1.Interface;
using CArch_V1.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CArch_V1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioRepository _repo;

        public PortfolioController(IPortfolioRepository repo) :base()
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listData = await _repo.GetAll();
                return Ok(listData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcel()
        {
            var listData = await _repo.GetAll();
            var fileName = $"DataPortfolio_{DateTime.Now:ddmmyyyy}.xlsx";
            var fileBytes = ExcelHelper.ExportToExcel(listData);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}

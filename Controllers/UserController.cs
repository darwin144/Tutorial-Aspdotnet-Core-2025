using CArch_V1.Dtos;
using CArch_V1.Interface;
using CArch_V1.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CArch_V1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository repository) : base() 
        {
            _userRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            try { 
            var response = new UserDto();
            var data =  await _userRepository.GetById(id);
            if(data == null)
            {
                return BadRequest(null);
            }
            response.Id = data.Id;
            response.Username = data.Username;
            return Ok(response);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }

}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listData = await _userRepository.GetAll();
                return Ok(listData);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcel()
        {
            var listData = await _userRepository.GetAll();
            var fileName = $"DataUsers_{DateTime.Now:ddmmyyyy_HHmmss}.xlsx";
            var fileBytes = ExcelHelper.ExportToExcel(listData);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}

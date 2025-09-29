using GArch_Web.Models;
using GArch_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GArch_Web.Controllers
{

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<UserVM> GetDataRaw()
        {
            var listData = new List<UserVM>();

            var random = new Random();
            listData = Enumerable.Range(1, 30).Select(i => new UserVM
            {
                Id = i,
                Username = $"User{i}",
                Password = $"pass{random.Next(1000, 9999)}"
            }).ToList();

            return listData;
        }

        [HttpPost]
        public IActionResult GetData()
        {
            var form = Request.Form;

            int start = int.Parse(form["start"]);
            int length = int.Parse(form["length"]);
            string searchValue = form["search[value]"];
            int draw = int.Parse(form["draw"]);

            // Simulasi data
            var allData = GetDataRaw();

            // Filter

            var filteredData = string.IsNullOrEmpty(searchValue)
                    ? allData
                    : allData.Where(u => u.Username.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();

            // Paging
            var pagedData = allData.Skip(start).Take(length).ToList();

            return Json(new
            {
                draw = draw,
                recordsTotal = allData.Count,
                recordsFiltered = filteredData.Count,
                data = pagedData
            });
        }

        [HttpGet]
        public IActionResult GetPartial(string vm)
        {
            switch (vm)
            {
                case "User":
                    return PartialView("_CreateForm", new UserVM());
                case "Order":
                    return PartialView("_OrderForm", new OrderVM());
                default:
                    return BadRequest("Unknown ViewModel");
            }
        }

       

        [HttpPost]
        public IActionResult SubmitDynamicForm(string viewModelType, object formData)
        {
            // Handle submit berdasarkan tipe (contoh: simpan ke DB)
            switch (viewModelType)
            {
                case "Order":
                    var orderVM = formData as OrderVM;
                    if (ModelState.IsValid)
                    {
                        // Simpan logic, misalnya _context.Orders.Add(...);
                        return Json(new { success = true, message = "Order saved!" });
                    }
                    break;
                case "User":
                    var userVM = formData as UserVM;
                    if (ModelState.IsValid)
                    {
                        // Simpan logic
                        return Json(new { success = true, message = "Approval saved!" });
                    }
                    break;
                // Serupa untuk yang lain...
                default:
                    return BadRequest("Invalid type.");
            }
            // Jika invalid, return partial lagi untuk tampilkan error
            return PartialView($"_Partial/{viewModelType}Form", formData);
        }

    }
}

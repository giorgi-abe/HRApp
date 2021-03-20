using HRApplicationMVC.Models;
using HRApplicationMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplicationMVC.Controllers
{
    public class EmployeeController : Controller { 
        public async Task<IActionResult> List([FromServices] ApiEmployeeService _apiService,string searchString)
        {
            var ModelList = await _apiService.GetDataAsync();
            if(searchString != null)
            {
                ModelList = ModelList.Where(s => s.Name.Contains(searchString)
                       || s.Surname.Contains(searchString));
            }
            return View(ModelList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ApiEmployeeService _apiService, Employee employee)
        {
            var returned = await _apiService.PostAsync(employee);
            if (returned == null)
            {
                return RedirectToAction("ExistInfo");
            }
            return RedirectToAction("List");
        }
        public IActionResult ExistInfo()
        {
            TempData["alertMessage"] = "This Employee already exist";
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete([FromServices] ApiEmployeeService _apiService,int Id)
        {
            var Idstring = Id.ToString();
            await _apiService.DeleteAsync(Idstring);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Update([FromServices] ApiEmployeeService _apiService, int id)
        {
            var employee = await _apiService.GetDataByAsync(id.ToString());
            ViewBag.Message = id;
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromServices] ApiEmployeeService _apiService, Employee employee,int Id)
        {
            var returned = await _apiService.PutAsync(employee, Id.ToString());
            if (returned == null)
            {
                return RedirectToAction("ExistInfo");
            }
            return RedirectToAction("List");
        }
    }
}

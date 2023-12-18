using Microsoft.AspNetCore.Mvc;
using SurveySystem.Contract;
using SurveySystem.Models;
using System.Runtime.CompilerServices;

namespace SurveySystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var depts =departmentRepository.GetAll();
            return View(depts);
        }
        public IActionResult Details(int id)
        {
            var dept =departmentRepository.GetById(id);
            return View(dept);
        }
    
     
        public IActionResult Edit(int id)
        {
            var dept = departmentRepository.GetById(id);
            return View(dept);
        }
        [HttpPost]
     
        public IActionResult Edit(int id ,Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Update(id, department);
               return RedirectToAction("Index");
            }
           
                return View(department);
            
        }
        public IActionResult Delete(int id)
        {
            var item =departmentRepository.GetById(id); 
            if (item != null)
            {
                departmentRepository.Delete(id);
            }
            return RedirectToAction("Index");                           

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid )
            {
                departmentRepository.Insert(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}

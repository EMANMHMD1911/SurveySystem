using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveySystem.Contract;
using SurveySystem.Infrastructure;
using SurveySystem.Models;
using SurveySystem.ViewModel;

namespace SurveySystem.Controllers
{
    public class TblKPIController : Controller
    {
        private readonly ITbIKPIRepository _TbIKPIRepository;
        private readonly IDepartmentRepository departmentRepository;

        public TblKPIController(ITbIKPIRepository _TbIKPIRepository, IDepartmentRepository departmentRepository)
        {
            this._TbIKPIRepository = _TbIKPIRepository;
            this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var items= _TbIKPIRepository.GetAll();
            TempData["total"] = _TbIKPIRepository.gettotal(items);

            return View(items);

        }
        public IActionResult Details(int id)
        {
            var item = _TbIKPIRepository.GetById(id);
            return View(item);
        }
        public IActionResult Delete(int id)
        {
            _TbIKPIRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            ViewBag.dept=departmentRepository.GetAll();
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Create(TblKPI tblKPI)
        {
            if (ModelState.IsValid)
            {
                if (tblKPI.MeasurementUnit == false)
                {
                    List<TblKPI> list = _TbIKPIRepository.GetByDeptId(tblKPI.DepNO);
                    double sum = 0,sumnum=0;

                    foreach(var item in list)

                    {
                        if(item.MeasurementUnit == false)
                        sum += item.TargetValue;
                        else sumnum += item.TargetValue;
                    }
                    if (sum + tblKPI.TargetValue > 100)
                    {
                        ModelState.AddModelError("TargetValue", "The Targeted Values of  the “percentage”  indicator KPI should not be more 100% for on department");
                        ViewBag.dept = departmentRepository.GetAll();

                        return View(tblKPI);

                    }
                    else if (sumnum==0)
                    {
                        ModelState.AddModelError("MeasurementUnit", "there is no kpi in this department ,the target value of the first KPI  should be  number");
                        ViewBag.dept = departmentRepository.GetAll();

                        return View(tblKPI);
                    }
                    else
                    {
                        _TbIKPIRepository.Insert(tblKPI);
                        return RedirectToAction("Index");
                    }
                }
                _TbIKPIRepository.Insert(tblKPI);
                return RedirectToAction("Index");
            }
            ViewBag.dept = departmentRepository.GetAll();

            return View(tblKPI);
        }
        public IActionResult Edit(int id)
        {
             var item =   _TbIKPIRepository.GetById(id);
            ViewBag.dept = departmentRepository.GetAll();

            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int id, TblKPI tblKPI)
        {
            if(ModelState.IsValid)
            {
                _TbIKPIRepository.Update(id, tblKPI);
                return RedirectToAction("Index");
            }
            return View(tblKPI); ;
        }
        public IActionResult GetByDeptId(int deptid)
        {
            var items = _TbIKPIRepository.GetByDeptId(deptid);
           
            TempData["total"] = _TbIKPIRepository.gettotal(items);
            return PartialView("_KPIList",items);

        }
        
        

    }


      
   
    
}

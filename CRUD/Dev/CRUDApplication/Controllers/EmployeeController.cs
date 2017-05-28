using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDApplicationBO;
using System.Data;
using EntitiesVO;
using System.Net;

namespace CRUDApplication.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBO objEmployeeBO;
        EmployeeVO objEmployeeVO;
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            objEmployeeVO = new EmployeeVO();
            objEmployeeVO.ID = 0;

            objEmployeeBO = new EmployeeBO();
            List<EmployeeVO> obj = objEmployeeBO.GetAllEmployeeDetails(objEmployeeVO);

            return View(obj);
        }

        private List<DepartmentVO> BindDepartment()
        {
            objEmployeeBO = new EmployeeBO();
            DataTable dtDepDetails = objEmployeeBO.GetDepratment();

            var ListDepartment = (from DataRow dr in dtDepDetails.AsEnumerable()
                                  select new DepartmentVO
                                  {
                                      ID = Convert.ToInt32(dr["ID"]),
                                      Name = Convert.ToString(dr["Name"])
                                  });

            return ListDepartment.ToList();
        }

        private List<SelectListItem> BindFruits()
        {
            objEmployeeBO = new EmployeeBO();
            List<FruitsVO> objFruits = objEmployeeBO.GetAllFruits();
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < objFruits.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = objFruits[i].FruitName,
                    Value = Convert.ToString(objFruits[i].FruitID)
                });
            }

            return items;
        }

        private List<DesignationVO> BindDesignation()
        {
            objEmployeeBO = new EmployeeBO();
            DataTable dtDetails = objEmployeeBO.GetDesignationDetails();

            var ListDesignation = (from DataRow dr in dtDetails.AsEnumerable()
                                   select new DesignationVO
                                   {
                                       ID = Convert.ToInt32(dr["ID"]),
                                       Name = Convert.ToString(dr["Name"])
                                   });

            return ListDesignation.ToList();
        }

        private List<SelectListItem> BindDesignationList()
        {
            List<SelectListItem> lstDesignation = new List<SelectListItem>();
            objEmployeeBO = new EmployeeBO();
            DataTable dtDetails = objEmployeeBO.GetDesignationDetails();

            for (int i = 0; i < dtDetails.Rows.Count; i++)
            {
                lstDesignation.Add(new SelectListItem
                {
                    Text = Convert.ToString(dtDetails.Rows[i]["Name"]),
                    Value = Convert.ToString(dtDetails.Rows[i]["ID"])
                });
            }

            return lstDesignation;
        }

        private List<FruitsVO> BindFruitsList()
        {
            objEmployeeBO = new EmployeeBO();
            return objEmployeeBO.GetAllFruits();
        }
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                objEmployeeVO = new EmployeeVO();
                objEmployeeVO.ID = Convert.ToInt32(ID);

                objEmployeeBO = new EmployeeBO();
                EmployeeVO obj = objEmployeeBO.GetEditEmployeeDetails(objEmployeeVO);

                ViewBag.Department = new SelectList(BindDepartment(), "ID", "Name", obj.Department.ID);
                ViewBag.Designation = new SelectList(BindDesignation(), "ID", "Name", obj.Designation.ID);
                return View(obj);
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeVO objEmployeeVO)
        {
            if (ModelState.IsValid)
            {
                objEmployeeBO = new EmployeeBO();
                objEmployeeBO.EditEmployeeDetails(objEmployeeVO);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Department = new SelectList(BindDepartment(), "ID", "Name");
                ViewBag.Designation = new SelectList(BindDesignation(), "ID", "Name");
            }
            return View();
        }

        public ActionResult Create()
        {/*one eg using strongly type and another using view bag*/
            EmployeeVO obj = new EmployeeVO();
            obj.ListDesignation = BindDesignationList();
            obj.ListFruits = BindFruitsList();

            ViewBag.Department = new SelectList(BindDepartment(), "ID", "Name");
            ViewBag.Fruits = BindFruits();
            return View("Create", obj);
        }

        [HttpPost]
        public ActionResult Create(EmployeeVO objEmployeeVO)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            if (ModelState.IsValid)
            {
                string strFruits = "";
                for (int i = 0; i < objEmployeeVO.ListFruits.Count;i++)
                {
                    if (objEmployeeVO.ListFruits[i].IsSelected)
                    {
                        strFruits += objEmployeeVO.ListFruits[i].FruitName + ",";
                    }
                }

                objEmployeeVO.Fruits=strFruits.TrimEnd(',');
                objEmployeeBO = new EmployeeBO();
                objEmployeeBO.AddEmployeeDetails(objEmployeeVO);

                return RedirectToAction("Index");
            }
            else
            {
                EmployeeVO obj = new EmployeeVO();
                obj.ListDesignation = BindDesignationList();
                obj.ListFruits = BindFruitsList();

                //ViewBag.Designation = new SelectList(BindDesignation(), "ID", "Name");
                ViewBag.Department = new SelectList(BindDepartment(), "ID", "Name");
                ViewBag.Fruits = BindFruits();
                return View("Create",obj);
            }
        }

        public ActionResult Delete(int? ID)
        {
            if (ID != null)
            {
                objEmployeeVO = new EmployeeVO();
                objEmployeeVO.ID = Convert.ToInt32(ID);

                objEmployeeBO = new EmployeeBO();
                EmployeeVO obj = objEmployeeBO.GetEditEmployeeDetails(objEmployeeVO);

                return View(obj);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "ID")]EmployeeVO objEmployeeVO)
        {
            objEmployeeBO = new EmployeeBO();
            objEmployeeBO.DeleteEmployee(objEmployeeVO);

            return RedirectToAction("Index");
        }
    }
}
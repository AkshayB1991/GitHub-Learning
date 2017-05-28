using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntitiesVO
{
    public class EmployeeVO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(20, ErrorMessage = "The name must be 3 characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        public string Fruits { get; set; }

        [Required(ErrorMessage = "Select valid designation")]

        private DesignationVO objDesignation = new DesignationVO();
        public DesignationVO Designation
        {
            get { return objDesignation; }
            set { objDesignation = value; }
        }

        [Required(ErrorMessage = "Select valid department")]
        private DepartmentVO objDepartmentVO = new DepartmentVO();
        public DepartmentVO Department
        {
            get { return objDepartmentVO; }
            set { objDepartmentVO = value; }
        }        

        private List<SelectListItem> lstDesignation=new List<SelectListItem>();
        public List<SelectListItem> ListDesignation
        {
            get { return lstDesignation; }
            set { lstDesignation= value; }
        }

        private List<FruitsVO> lstFruits=new List<FruitsVO>();

        public List<FruitsVO> ListFruits
        {
            get { return lstFruits; }
            set { lstFruits=value; }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDApplicationDO;
using System.Data;
using EntitiesVO;

namespace CRUDApplicationBO
{
    public class EmployeeBO
    {
        EmployeeDO objEmployeeDO;
        public DataTable GetEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetEmployeeDetails(objEmployeeVO);
        }

        public void EditEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            objEmployeeDO.EditEmployeeDetails(objEmployeeVO);
        }

        public EmployeeVO GetEditEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetEditEmployeeDetails(objEmployeeVO);
        }

        public DataTable GetDesignationDetails()
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetDesignationDetails();
        }

        public DataTable GetDepratment()
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetDepartmentDetails();
        }

        public void AddEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            objEmployeeDO.AddEmployeeDetails(objEmployeeVO);
        }

        public List<EmployeeVO> GetAllEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetAllEmployeeDetails(objEmployeeVO);
        }

        public void DeleteEmployee(EmployeeVO objEmployeeVO)
        {
            objEmployeeDO = new EmployeeDO();
            objEmployeeDO.DeleteEmployee(objEmployeeVO);
        }

        public List<FruitsVO> GetAllFruits()
        {
            objEmployeeDO = new EmployeeDO();
            return objEmployeeDO.GetAllFruits();
        }
    }
}

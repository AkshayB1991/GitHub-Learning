using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesVO;

namespace CRUDApplicationDO
{
    public class EmployeeDO
    {
        private string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConStrDev"].ConnectionString;
        }
        public DataTable GetEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            DataTable dtDetails = new DataTable();
            SqlConnection sqlCon = new SqlConnection(ConnectionString());

            try
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_ManageEmployeeDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objEmployeeVO.ID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDetails);

                cmd.Dispose();
                da.Dispose();
                
                sqlCon.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dtDetails;
        }

        public List<EmployeeVO> GetAllEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            List<EmployeeVO> lstEmployeeDetails = new List<EmployeeVO>();
            SqlConnection sqlCon = new SqlConnection(ConnectionString());

            try
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_ManageEmployeeDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objEmployeeVO.ID);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while(sdr.Read())
                    {
                        EmployeeVO objEmployee = new EmployeeVO();
                        objEmployee.ID = Convert.ToInt32(sdr["EmployeeID"]);
                        objEmployee.Name = Convert.ToString(sdr["EmployeeName"]);
                        objEmployee.Designation.Name = Convert.ToString(sdr["DesignationName"]);
                        objEmployee.Department.Name = Convert.ToString(sdr["Departmentname"]);
                        objEmployee.Department.ID = Convert.ToInt32(sdr["DepartmentID"]);
                        objEmployee.Designation.ID = Convert.ToInt32(sdr["DesignationID"]);

                        lstEmployeeDetails.Add(objEmployee);
                    }
                }

                sqlCon.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return lstEmployeeDetails;
        }

        public EmployeeVO GetEditEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            EmployeeVO obj = new EmployeeVO();
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            try
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_ManageEmployeeDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID",objEmployeeVO.ID);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        obj.ID = Convert.ToInt32(sdr["EmployeeID"]);
                        obj.Name = Convert.ToString(sdr["EmployeeName"]);
                        obj.Designation.Name = Convert.ToString(sdr["DesignationName"]);
                        obj.Department.Name = Convert.ToString(sdr["Departmentname"]);
                        obj.Department.ID =Convert.ToInt32(sdr["DepartmentID"]);
                        obj.Designation.ID =Convert.ToInt32(sdr["DesignationID"]);
                    }
                }

                cmd.Dispose();
                sdr.Close();
                sdr.Dispose();

                sqlCon.Close();
            }
            catch (Exception)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return obj;
        }

        public void EditEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            try
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_EditEmployeeDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objEmployeeVO.ID);
                cmd.Parameters.AddWithValue("@Name", objEmployeeVO.Name);
                cmd.Parameters.AddWithValue("@DesignationID", objEmployeeVO.Designation.ID);
                cmd.Parameters.AddWithValue("@DepartmentID", objEmployeeVO.Department.ID);
                cmd.ExecuteNonQuery();
                
                sqlCon.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        public DataTable GetDesignationDetails()
        {
            DataTable dtDetails = new DataTable();
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            try
            {
                sqlCon.Open();
                
                SqlCommand cmd = new SqlCommand("usp_GetDesignation", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDetails);

                cmd.Dispose();
                da.Dispose();

                sqlCon.Close();
            }
            catch (Exception)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                throw;
            }

            return dtDetails;
        }

        public DataTable GetDepartmentDetails()
        {
            DataTable dtDetails = new DataTable();
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            try
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_GetDepartment", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDetails);

                cmd.Dispose();
                da.Dispose();

                sqlCon.Close();
            }
            catch (Exception)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                throw;
            }

            return dtDetails;
        }

        public void AddEmployeeDetails(EmployeeVO objEmployeeVO)
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionString());
            try
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("usp_AddEmployeeDetails", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objEmployeeVO.ID);
                cmd.Parameters.AddWithValue("@Name", objEmployeeVO.Name);
                cmd.Parameters.AddWithValue("@DesignationID", objEmployeeVO.Designation.ID);
                cmd.Parameters.AddWithValue("@DepartmentID", objEmployeeVO.Department.ID);
                cmd.Parameters.AddWithValue("@Fruits", objEmployeeVO.Fruits);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }

        public void DeleteEmployee(EmployeeVO objEmployeeVO)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("usp_DeleteEmployee", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objEmployeeVO.ID);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        public List<FruitsVO> GetAllFruits()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString());
            List<FruitsVO> lstFruits = new List<FruitsVO>();
            FruitsVO objFruitsVO = null;
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("usp_GetAllFruits", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        objFruitsVO = new FruitsVO();
                        objFruitsVO.FruitID = Convert.ToInt32(sdr["FruitID"]);
                        objFruitsVO.FruitName = Convert.ToString(sdr["FruitName"]);
                        objFruitsVO.IsSelected = false;
                        lstFruits.Add(objFruitsVO);
                    }
                }

                cmd.Dispose();
                sdr.Close();
                sdr.Dispose();
                sqlCon.Close();
            }
            catch (Exception)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return lstFruits;
        }

    }
}

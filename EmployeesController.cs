using ModelBindingAndDBCode.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingAndDBCode.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> list = new List<Employee>();

            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

            sql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sql;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Employees ";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                list.Add(new Employee
                {
                    EmpNo = (int)dr["EmpNo"],
                    Name = (string)dr["Name"],

                    Basic = (decimal)dr["Basic"],
                 
                    DeptNo = (int)dr["DeptNo"]
                });

            }

           // sql.Close();

            return View(list);
           // return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
            //Employee objEmp = new Employee();
            //objEmp.EmpNo = 10;
            //objEmp.Name = "Sumit";
            //objEmp.Basic = 12200;
            //objEmp.DeptNo = 20;
            //return View(objEmp);

            Employee emp = new Employee();

            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

            sql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sql;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Employees where EmpNo = "+id;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                emp.EmpNo = (int)dr["EmpNo"];

                emp.Name = (string)(dr["Name"]);

                emp.Basic = (decimal)dr["Basic"];


                emp.DeptNo = (int)dr["DeptNo"];

            }

            sql.Close();

            return View(emp);

        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee objEmp)
        {
            try
            {
                // TODO: Add insert logic here
                //string Name = objEmp.Name;
                int empno = objEmp.EmpNo;
                string name = objEmp.Name;
                decimal basic = objEmp.Basic;
                int deptno = objEmp.DeptNo;
             //   return RedirectToAction("Index");
               
                SqlConnection sql = new SqlConnection();

                sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False";

                sql.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sql;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into Employees values(@Empno,@Name,@Basic,@Deptno)";

                cmd.Parameters.AddWithValue("@EmpNo", empno);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Basic", basic);
                cmd.Parameters.AddWithValue("@DeptNo", deptno);


                int count = cmd.ExecuteNonQuery();

                sql.Close();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5

        // GET: Employee/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Employee emp = new Employee();

            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False";

            sql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sql;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Employees where EmpNo = " + id;

            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                emp.EmpNo = (int)dr["EmpNo"];

                emp.Name = (string)(dr["Name"]);

                emp.Basic = (decimal)dr["Basic"];

                emp.DeptNo = (int)dr["DeptNo"];

            }

            dr.Close();

            sql.Close();


            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Employee objemp)
        {

            int empno = objemp.EmpNo;
            string name = objemp.Name;
            decimal basic = objemp.Basic;          
            int deptno = objemp.DeptNo;

            //Employee emp = new Employee();

            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False";

            sql.Open();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sql;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Employees set Name = @Name , Basic = @Basic , DeptNo = @DeptNo where EmpNo = @EmpNo";


                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Basic", basic);
                cmd.Parameters.AddWithValue("@DeptNo", deptno);
                cmd.Parameters.AddWithValue("@EmpNo", empno);

                int count = cmd.ExecuteNonQuery();
                
                sql.Close();

                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }


        }

        public ActionResult Delete(int id=0)
        {
            Employee emp = new Employee();

            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False";

            sql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sql;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Employees where EmpNo = " + id;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                emp.EmpNo = (int)dr["EmpNo"];

                emp.Name = (string)(dr["Name"]);

                emp.Basic = (decimal)dr["Basic"];

                emp.DeptNo = (int)dr["DeptNo"];

            }

            dr.Close();

            sql.Close();


            return View(emp);

        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Employee emp)
        {
            try
            {
                // TODO: Add delete logic here
                int empno = emp.EmpNo;
                string name = emp.Name;
                decimal basic = emp.Basic;
                int deptno = emp.DeptNo;

                SqlConnection sql = new SqlConnection();

                sql.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False";

                sql.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = sql;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from Employees where EmpNo = @EmpNo";

                //SqlDataReader dr = cmd.ExecuteReader();

                cmd.Parameters.AddWithValue("@EmpNo", empno);

                int count = cmd.ExecuteNonQuery();

                sql.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

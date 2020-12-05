using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que1
{
    class Program
    {
        static void Main1(string[] args)
        {
            object[] arr1 = new object[1];
            Employees[] arr = new Employees[3];
            Employees emp1 = new Employees(1, "Mohan", 3200000);
            Employees emp2 = new Employees(2, "Vinay", 5200000);
            Employees emp3 = new Employees(3, "Anna", 22000);



            arr[0] = emp1;
            arr[1] = emp2;
            arr[2] = emp3;

           
            //Method 1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].EmpSal > arr[j + 1].EmpSal)
                    {

                        Employees temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].EmpSal == arr[arr.Length - 1].EmpSal)
                    Console.WriteLine(arr[i].EmpId + " " + arr[i].EmpName + "  " + arr[i].EmpSal);
            }


            int eno = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].EmpId == eno)
                    Console.WriteLine(arr[i].EmpId + " " + arr[i].EmpName + "  " + arr[i].EmpSal);
            }





            Console.ReadLine();
        }

    }

    class Employees
    {
        private int empId;

        private string empName;
        private decimal empSal;

        public int EmpId
        {
            get;
            set;
        }
        public string EmpName { get; set; }
        public decimal EmpSal { get; set; }

        public Employees(int empId, string empName, decimal empSal)
        {
            this.EmpId = empId;
            this.EmpName = empName;
            this.EmpSal = empSal;
        }

    }
}
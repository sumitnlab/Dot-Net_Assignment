using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Manager");
            Manager mg = new Manager("Hello", "Amol", 11, 17000000);
            Console.WriteLine(mg.Name + "   " + mg.BasicSal);
            Console.WriteLine("Net sal : " + mg.calcNetSalary());


            Console.WriteLine("----------------------------------------");
            Console.WriteLine("General Manager");
            GeneralManager gmg = new GeneralManager("Hello", "Hello", "Amol", 12, 16000000);
            Console.WriteLine(gmg.Name + "   " + gmg.BasicSal);
            Console.WriteLine("Net sal : " + gmg.calcNetSalary());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("CEO");
            CEO c = new CEO("Amol", 13, 20000000);
            Console.WriteLine(c.Name + "   " + c.BasicSal);
            Console.WriteLine("Net sal : " + c.calcNetSalary());


            Console.WriteLine("----------------------------------------");
            IDbFunctions i1 = new Manager();
            i1.Delete();
            i1.Update();

            Console.WriteLine("----------------------------------------");
            IDbFunctions i2 = new GeneralManager();
            i2.Insert();

            Console.WriteLine("----------------------------------------");
            IDbFunctions i3 = new CEO();
            i3.Delete();
            i3.Update();

            Console.ReadLine();

        }
        public interface IDbFunctions
        {
            void Insert();
            void Update();
            void Delete();

        }
        public abstract class Employee : IDbFunctions
        {
            private string name;
            private int empNO;
            public static int id;
            private short deptNo;
            private decimal basicSal;
            public abstract decimal calcNetSalary();
            public Employee()
            {

            }
            public void Insert()
            {
                Console.WriteLine("Insert Employee !!");
            }

            public void Update()
            {
                Console.WriteLine("Update Employee !!");
            }

            public void Delete()
            {
                Console.WriteLine("Delete Employee !!");
            }

            public string Name
            {
                get { return name; }
                set { if (value == null) Console.WriteLine("invalid name"); else name = value; }
            }
            public int EmpNo
            {
                get;
            }

            public short DeptNo
            {
                get { return deptNo; }
                set { if (value > 0) deptNo = value; else Console.WriteLine("invalid dept id"); }
            }
            public abstract decimal BasicSal
            {
                get;
                set;
            }
            public Employee(string name = "NA", short deptNo = 11, decimal basicSal = 1120000)
            {
                id++;
                this.EmpNo = id;
                this.Name = name;
                this.DeptNo = deptNo;
                this.BasicSal = basicSal;
            }
        }
        public class Manager : Employee, IDbFunctions
        {
            private string designation;
            public string Designation
            {
                get { return designation; }
                set { if (value == null) Console.WriteLine("invalid name"); else designation = value; }
            }

            public override decimal BasicSal { get; set; }

            public Manager(string designation = "NA", string name = "NA", short deptNo = 11, decimal basicSal = 120000) : base(name, deptNo, basicSal)
            {
                this.Designation = designation;
            }

            public Manager()
            {
            }

            public override decimal calcNetSalary()
            {
                double Diduction = 2000;
                decimal netSal = BasicSal - (decimal)Diduction;
                return netSal;
            }
            void IDbFunctions.Insert()
            {
                Console.WriteLine("Insert Manager !!");
            }

            public new void Update()
            {
                Console.WriteLine("Update Manager !!");
            }

            public new void Delete()
            {
                Console.WriteLine("Delete Manager !!");
            }
        }

        public class GeneralManager : Manager, IDbFunctions
        {
            private string perks;
            public string Perks
            {
                get { return perks; }
                set { perks = value; }
            }

            public GeneralManager(string perks = "NA", string designation = "NA", string name = "NA", short deptNo = 11, decimal basicSal = 120000) : base(designation, name, deptNo, basicSal)
            {
                this.Perks = perks;
            }

            public GeneralManager()
            {
            }

            public override decimal calcNetSalary()
            {
                double Diduction = 2000;
                decimal netSal = BasicSal - (decimal)Diduction;
                return netSal;
            }
            public new void Insert()
            {
                Console.WriteLine("Insert GeneralManager !!");
            }

            public new void Update()
            {
                Console.WriteLine("Update GeneralManager !!");
            }

            public new void Delete()
            {
                Console.WriteLine("Delete GeneralManager !!");
            }
        }

        public class CEO : Employee, IDbFunctions
        {
            public CEO(string name = "NA", short deptNo = 11, decimal basicSal = 120000) : base(name, deptNo, basicSal)
            {

            }

            public override decimal BasicSal { get; set; }

            public sealed override decimal calcNetSalary()
            {
                double Diduction = 2000;
                decimal netSal = BasicSal - (decimal)Diduction;
                return netSal;
            }
            public new void Insert()
            {
                Console.WriteLine("Insert CEO !!");
            }

            public new void Update()
            {
                Console.WriteLine("Update CEO !!");
            }

            public new void Delete()
            {
                Console.WriteLine("Delete CEO !!");
            }
        }
    }
}

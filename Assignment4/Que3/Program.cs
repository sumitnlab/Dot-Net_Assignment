using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que3
{
    class Program
    {
        static void Main4()
        {

            Console.ReadLine();
        }

    }
    public struct Student
    {
        private string name;
        private int rollNo;
        private decimal marks;

        // public string Name { get { return name; } set { if (value == null) Console.WriteLine("Invalid Name "); else name = value; } }
        public string Name { get; set; }
        // public int RollNo { get { return rollNo; } set { if (value > 0) rollNo = value; else Console.WriteLine("Invalid RollNo"); } }
        public int RollNo { get; set; }
        public decimal Marks { get; set; }

        public Student(string name, int rollNo, decimal marks)
        {
            this.Name = name;
            this.RollNo = rollNo;
            this.Marks = marks;
        }
    }
}
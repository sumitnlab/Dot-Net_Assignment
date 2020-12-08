using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que2
{
    public struct Student
    {

        private string name;

          public string StudName
        {
            set
            {
                 if(value!=null)
                {
                    name = value;
                    
                }
                 else
                {
                     Console.WriteLine("Invalid name");
                }

            }
            get
            {
                return name;
            }
        }


        private int rollno;

        public int studrollno
        {
            set
            {
                if(value>=0)
                {
                    rollno = value;
                }
            }

            get
            {
                return rollno;
            }
        }

        private decimal marks;

            public decimal studMarks
        {
            set
            {
                if(value!=0)
                {
                    marks = value;
                }
                else
                {
                    Console.WriteLine("Marks are Invalid");
                }
            }
            get
            {
                return marks;
            }
        }

        public Student(string name1 , int rollno1 , decimal marks1) : this()
        {
           
            this.StudName = name1;
            this.studrollno = rollno1;
            this.studMarks = marks1;


        }


        public void show()
        {
            
            Console.WriteLine(StudName);
            Console.WriteLine(studrollno);
            Console.WriteLine(studMarks);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many student you want : ");

            int capacity = int.Parse(Console.ReadLine());

            Student[] s1 = new Student[capacity];

            for(int i = 0; i<s1.Length;i++)
            {
                Console.WriteLine("\nEnter Student name : ");

                string name = Console.ReadLine();

                Console.WriteLine("\nEnter Student rollno : ");

                int rollno = int.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter Student Marks : ");

                decimal marks = decimal.Parse(Console.ReadLine());

                Student temp = new Student(name, rollno, marks);

                s1[i] = temp;
            }

            Console.WriteLine("\n*****Details of Student*****\n");
             
              for(int i = 0; i<s1.Length;i++)
            {
                s1[i].show();
            }

            Console.ReadLine();
        }

         
    }
}

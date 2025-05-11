/*
Ունենք Group և Student կլասները
ընդ որում Group -ը ունի List<Student> զանգվածը
իրականացնել հետևյալ operator-ների գերբեռնումը
true/false => եթե խմբում առկա են ուսանողներ
Group+Group => նոր խումբ, որտեղ ուսանողները միավորված են
Group-Group => Առաջին խմբից հեռացնել այն ուսանողներին,
որոնք առկա են նաև երկրորդ խմբում, ստացված ուսանողներից ձևավորել նոր խումբ
*/

using System;
using System.Collections.Generic;

namespace GroupStudent
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }
    }

    public class Group
    {
        public string GroupName { get; set; }
        public List<Student> Students { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
            Students = new List<Student>();
        }

        public static bool operator true(Group g)
        {
            return g.Students != null && g.Students.Count > 0;
        }

        public static bool operator false(Group g)
        {
            return g.Students == null || g.Students.Count == 0;
        }

        public static Group operator +(Group g1, Group g2)
        {
            Group result = new Group($"{g1.GroupName} + {g2.GroupName}");
            result.Students.AddRange(g1.Students);
            result.Students.AddRange(g2.Students);
            return result;
        }

        public static Group operator -(Group g1, Group g2)
        {
            Group result = new Group($"{g1.GroupName} - {g2.GroupName}");
            foreach (Student s in g1.Students)
            {
                if (!g2.Students.Contains(s))
                {
                    result.Students.Add(s);
                }
            }
            return result;
        }

        public void Print()
        {
            Console.WriteLine($"\nGroup: {GroupName}");
            if (Students.Count == 0)
            {
                Console.WriteLine("No students in this group.");
            }
            else
            {
                foreach (Student s in Students)
                {
                    Console.WriteLine($"{s.Name} // {s.Age}");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Group groupA = new Group("A");
            groupA.Students.Add(new Student("Anna", 20));
            groupA.Students.Add(new Student("David", 22));

            Group groupB = new Group("B");
            groupB.Students.Add(new Student("Anna", 20)); 
            groupB.Students.Add(new Student("Monte", 14));

            
            if (groupA ? true : false)
                Console.WriteLine("Group A has students.");

            if (!(groupB ? true : false))
                Console.WriteLine("Group B is empty.");
            else
                Console.WriteLine("Group B has students.");

            Group added = groupA + groupB;
            added.Print();

            Group removed = groupA - groupB;
            removed.Print();
        }
    }
}


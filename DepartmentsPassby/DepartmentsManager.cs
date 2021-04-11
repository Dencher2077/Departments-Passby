using System.Collections.Generic;
using DepartmentsPassby.Models;

namespace DepartmentsPassby
{
    public class DepartmentsManager
    {
        public Department[] Departments { get; }

        public int Length => Departments.Length;

        public Dictionary<string, int> DepartmentsMapper { get; }

        public DepartmentsManager(Department[] departments)
        {
            Departments = departments;
            DepartmentsMapper = CreateDepartmentsMapper(Departments);
        }

        public Department this[int index]
        {
            get => Departments[index];
            set => Departments[index] = value;
        }
        
        public Department this[string title]
        {
            get => Departments[ DepartmentsMapper[title] ];
            set => Departments[ DepartmentsMapper[title] ] = value;
        }

        public int IndexOf(string title) => DepartmentsMapper[title];

        private Dictionary<string, int> CreateDepartmentsMapper(Department[] departments)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < departments.Length; i++)
            {
                result.Add(departments[i].Title, i);
            }

            return result;
        }
    }
}